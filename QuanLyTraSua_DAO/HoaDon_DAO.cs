using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client; // Thư viện Oracle
using System.Data;

namespace QuanLyTraSua.QuanLyTraSua_DAO
{
    // DAO: Data Access Object - Truy cập dữ liệu
    public class HoaDon_DAO // DAO cho Quản lý Hóa Đơn
    {
        // Lấy tất cả hóa đơn
        public DataTable GetAllHoaDon()
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;

            // Truy vấn lấy tất cả hóa đơn, sắp xếp theo Ngày Lập giảm dần
            string query = "SELECT MaHD, NgayLap, TongTien, MaNV, RAWTOHEX(ChuKySo) AS ChuKySo " +
                "FROM HOADON " +
                "ORDER BY NgayLap DESC";

            DataTable dt = DataProvider.ThucThiTruyVan(query, conn);

            DataProvider.DongKetNoi(conn);

            return dt;
        }

        // Ký số hóa đơn
        public string KySoHoaDon(string maHD)
        {
            OracleConnection conn = DataProvider.MoKetNoi();

            if (conn == null) return "Lỗi kết nối CSDL";

            string ketQua = "Lỗi không xác định";

            try
            { // Gọi thủ tục lưu trữ để ký số hóa đơn
                using (OracleCommand cmd = new OracleCommand("SP_KySoHoaDon", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_maHD", maHD));
                    OracleParameter p_ketQua = new OracleParameter("p_ketQua", OracleDbType.Varchar2, 1000, null, ParameterDirection.Output);
                    cmd.Parameters.Add(p_ketQua);
                    cmd.ExecuteNonQuery();
                    ketQua = p_ketQua.Value.ToString();
                }
            }
            catch (Exception ex) 
            { 
                ketQua = "Lỗi C#: " + ex.Message; 
            }
            finally 
            { 
                DataProvider.DongKetNoi(conn); 
            }
            return ketQua;
        }

        // Xác thực hóa đơn
        public string XacThucHoaDon(string maHD)
        {
            OracleConnection conn = DataProvider.MoKetNoi();

            if (conn == null) return "Lỗi kết nối CSDL";

            string ketQua = "Lỗi không xác định";

            try
            { // Gọi thủ tục lưu trữ để xác thực hóa đơn
                using (OracleCommand cmd = new OracleCommand("SP_XacThucHoaDon", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_maHD", maHD));
                    OracleParameter p_ketQua = new OracleParameter("p_ketQua", OracleDbType.Varchar2, 1000, null, ParameterDirection.Output);
                    cmd.Parameters.Add(p_ketQua);
                    cmd.ExecuteNonQuery();
                    ketQua = p_ketQua.Value.ToString();
                }
            }
            catch (Exception ex) 
            { 
                ketQua = "Lỗi C#: " + ex.Message; 
            }
            finally 
            { 
                DataProvider.DongKetNoi(conn); 
            }
            return ketQua;
        }

        // Tạo hóa đơn mới với giao dịch
        public string TaoHoaDon(string maHD, double tongTien, string maNV, DataTable dtGioHang)
        {
            OracleConnection conn = DataProvider.MoKetNoi();

            if (conn == null) return "Lỗi kết nối CSDL";

            // Bắt đầu giao dịch
            OracleTransaction tran = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                // BƯỚC 1: KIỂM TRA KHO (Khóa các dòng sản phẩm lại)
                string queryCheckKho = "SELECT SoLuongTon " +
                    "FROM SANPHAM " +
                    "WHERE MaSP = :MaSP FOR UPDATE";
                // Duyệt giỏ hàng để kiểm tra tồn kho
                foreach (DataRow row in dtGioHang.Rows)
                {
                    string maSP = row["MaSP"].ToString(); // Mã sản phẩm
                    int soLuongMua = Convert.ToInt32(row["SoLuong"]); // Số lượng mua

                    // Kiểm tra tồn kho
                    using (OracleCommand cmdCheck = new OracleCommand(queryCheckKho, conn))
                    {
                        cmdCheck.Transaction = tran; // Gán transaction 
                        cmdCheck.Parameters.Add(new OracleParameter("MaSP", maSP)); // Tham số MaSP

                        object result = cmdCheck.ExecuteScalar(); // Lấy số lượng tồn kho
                        if (result == null || result == DBNull.Value)
                        {
                            tran.Rollback();
                            return $"Lỗi: Sản phẩm '{maSP}' không tồn tại.";
                        }

                        int soLuongTon = Convert.ToInt32(result); // Số lượng tồn kho

                        if (soLuongMua > soLuongTon)
                        {
                            tran.Rollback();
                            return $"Lỗi: Sản phẩm '{row["TenSP"]}' không đủ hàng (Chỉ còn {soLuongTon}).";
                        }
                    }
                }

                // BƯỚC 2: Thêm vào bảng HOADON
                string queryHD = "INSERT INTO HOADON (MaHD, NgayLap, TongTien, MaNV) VALUES (:MaHD, SYSDATE, :TongTien, :MaNV)";
                using (OracleCommand cmdHD = new OracleCommand(queryHD, conn))
                {
                    cmdHD.Transaction = tran; // Gan transaction
                    cmdHD.Parameters.Add(new OracleParameter("MaHD", maHD));
                    cmdHD.Parameters.Add(new OracleParameter("TongTien", tongTien));
                    cmdHD.Parameters.Add(new OracleParameter("MaNV", maNV));
                    cmdHD.ExecuteNonQuery();
                }

                // BƯỚC 3: Thêm vào CTHD và Cập nhật kho
                string queryCTHD = "INSERT INTO CHITIETHOADON (MaHD, MaSP, SoLuong, ThanhTien) VALUES (:MaHD, :MaSP, :SoLuong, :ThanhTien)";
                string queryUpdateKho = "UPDATE SANPHAM " +
                    "SET SoLuongTon = SoLuongTon - :SoLuongMua " +
                    "WHERE MaSP = :MaSP";

                // Duyệt giỏ hàng để thêm chi tiết hóa đơn và cập nhật kho
                foreach (DataRow row in dtGioHang.Rows)
                {
                    // Thêm vào CHITIETHOADON
                    using (OracleCommand cmdCTHD = new OracleCommand(queryCTHD, conn))
                    {
                        cmdCTHD.Transaction = tran; // Gan transaction
                        cmdCTHD.Parameters.Add(new OracleParameter("MaHD", maHD));
                        cmdCTHD.Parameters.Add(new OracleParameter("MaSP", row["MaSP"]));
                        cmdCTHD.Parameters.Add(new OracleParameter("SoLuong", Convert.ToInt32(row["SoLuong"])));
                        cmdCTHD.Parameters.Add(new OracleParameter("ThanhTien", Convert.ToDouble(row["ThanhTien"])));
                        cmdCTHD.ExecuteNonQuery();
                    }

                    // Cập nhật Kho
                    using (OracleCommand cmdUpdateKho = new OracleCommand(queryUpdateKho, conn))
                    {
                        cmdUpdateKho.Transaction = tran;
                        cmdUpdateKho.Parameters.Add(new OracleParameter("SoLuongMua", Convert.ToInt32(row["SoLuong"])));
                        cmdUpdateKho.Parameters.Add(new OracleParameter("MaSP", row["MaSP"]));
                        cmdUpdateKho.ExecuteNonQuery();
                    }
                }

                // BƯỚC 4: Neu tat ca thanh cong, Commit transaction
                tran.Commit();
                return "Thanh toán thành công! Mã Hóa Đơn: " + maHD;
            }
            catch (Exception ex)
            {
                // Neu co loi, Rollback
                tran.Rollback();
                return "Thanh toán thất bại. Lỗi CSDL: " + ex.Message;
            }
            finally
            {
                DataProvider.DongKetNoi(conn);
            }
        }

        // Lấy chi tiết hóa đơn theo Mã Hóa Đơn
        public DataTable GetChiTietHoaDon(string maHD)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;

            // Lấy MaSP, TenSP (từ bảng SANPHAM), SoLuong, ThanhTien
            string query = @"
                SELECT CT.MaSP, SP.TenSP, CT.SoLuong, CT.ThanhTien
                FROM CHITIETHOADON CT
                JOIN SANPHAM SP ON CT.MaSP = SP.MaSP
                WHERE CT.MaHD = :maHD";

            DataTable dt = new DataTable();
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("maHD", maHD));
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception) 
            { 
                dt = null; 
            }
            finally 
            { 
                DataProvider.DongKetNoi(conn); 
            }
            return dt;
        }
    }
}