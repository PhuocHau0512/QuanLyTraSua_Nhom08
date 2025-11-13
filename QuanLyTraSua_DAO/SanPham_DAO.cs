using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace QuanLyTraSua.QuanLyTraSua_DAO
{ 
    // DAO cho bảng Sản phẩm
    public class SanPham_DAO
    {
        // Lấy lịch sử thay đổi giá sản phẩm trong 24 giờ qua
        public DataTable GetSanPhamHistory(string maSP)
        {
            // Mở kết nối
            OracleConnection conn = DataProvider.MoKetNoi();
            // Kiểm tra kết nối
            if (conn == null) return null;
            // Sử dụng tính năng Flashback Data Archive để lấy lịch sử thay đổi
            string query = @"
                SELECT TenSP, DonGia, 
                       VERSIONS_STARTTIME AS ""Thời điểm Bắt đầu"", 
                       VERSIONS_ENDTIME AS ""Thời điểm Kết thúc"",
                       CASE VERSIONS_OPERATION WHEN 'U' THEN 'Cập nhật' WHEN 'I' THEN 'Thêm mới' ELSE 'Xóa' END AS ""Hành động""
                FROM SANPHAM
                VERSIONS BETWEEN TIMESTAMP (SYSTIMESTAMP - INTERVAL '1' DAY) AND SYSTIMESTAMP
                WHERE MaSP = :maSP
                ORDER BY VERSIONS_STARTTIME DESC NULLS LAST";
            DataTable dataTable = new DataTable();
            try
            {
                // Thực thi truy vấn
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Thêm tham số
                    cmd.Parameters.Add(new OracleParameter("maSP", maSP));
                    // Sử dụng DataAdapter để điền dữ liệu vào DataTable
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception) { dataTable = null; }
            finally { DataProvider.DongKetNoi(conn); }
            return dataTable;
        }
        // Phục hồi giá sản phẩm theo timestamp
        public bool RestoreGiaSanPham(string maSP, DateTime timestamp)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;

            try
            {
                // Gọi stored procedure để phục hồi giá
                using (OracleCommand cmd = new OracleCommand("SP_RestoreGiaSanPham", conn))
                {
                    // Thiết lập kiểu lệnh là Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_maSP", maSP));
                    cmd.Parameters.Add(new OracleParameter("p_timestamp", OracleDbType.TimeStamp, timestamp, ParameterDirection.Input));
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception) { result = false; }
            finally { DataProvider.DongKetNoi(conn); }
            return result;
        }
        // Lấy sản phẩm theo quyền (dành cho Nhân viên và Admin/Quản lý)
        public DataTable GetActiveSanPham(string quyen)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;

            string query = "";
            // Dùng View mô phỏng OLS dựa trên quyền được truyền vào
            if (quyen == "NhanVien")
            {
                // ROLE_NHANVIEN_BANHANG chỉ được xem View PUBLIC
                query = "SELECT MaSP, TenSP, DonGia, SoLuongTon FROM VW_SANPHAM_NHANVIEN";
            }
            else
            {
                // Admin (hoặc Quản lý) được xem View đầy đủ
                query = "SELECT MaSP, TenSP, DonGia, SoLuongTon FROM VW_SANPHAM_QUANLYKHO";
            }

            DataTable dt = DataProvider.ThucThiTruyVan(query, conn);
            DataProvider.DongKetNoi(conn);
            return dt;
        }

        // Lấy tất cả sản phẩm (dành cho Admin/Quản lý)
        public DataTable GetAllSanPham()
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;

            // Form này chỉ dành cho Admin/Quản lý, nên luôn dùng View đầy đủ
            string query = "SELECT MaSP, TenSP, DonGia, LoaiSP, SoLuongTon" +
                " FROM VW_SANPHAM_QUANLYKHO";

            DataTable dt = DataProvider.ThucThiTruyVan(query, conn);
            DataProvider.DongKetNoi(conn);
            return dt;
        }
        // Thêm sản phẩm mới
        // Hàm này phải chạy SP để gans nhãn OLS cho sản phẩm mới (dùng Views))
        public bool ThemSanPham(string maSP, string tenSP, double donGia, string loaiSP, int soLuongTon)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;

            try
            {
                // Gọi stored procedure để thêm sản phẩm
                using (OracleCommand cmd = new OracleCommand("SP_SanPham_Insert", conn))
                {
                    // Thiết lập kiểu lệnh là Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Thêm các tham số
                    cmd.Parameters.Add(new OracleParameter("p_MaSP", maSP));
                    cmd.Parameters.Add(new OracleParameter("p_TenSP", tenSP));
                    cmd.Parameters.Add(new OracleParameter("p_DonGia", donGia));
                    cmd.Parameters.Add(new OracleParameter("p_LoaiSP", loaiSP));
                    cmd.Parameters.Add(new OracleParameter("p_SoLuongTon", soLuongTon)); 
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception) 
            { 
                result = false; 
            }
            finally 
            { 
                DataProvider.DongKetNoi(conn); 
            }
            return result;
        }

        // Cập nhật thông tin sản phẩm
        public bool CapNhatSanPham(string maSP, string tenSP, double donGia, string loaiSP, int soLuongTon)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            OracleTransaction tran = conn.BeginTransaction();
            bool result = false;
            try
            {
                // Khi UPDATE, FGA (Giam sat) se duoc kich hoat neu DonGia thay doi
                string query = "UPDATE SANPHAM SET TenSP = :TenSP, DonGia = :DonGia, LoaiSP = :LoaiSP, SoLuongTon = :SoLuongTon WHERE MaSP = :MaSP";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("TenSP", tenSP));
                    cmd.Parameters.Add(new OracleParameter("DonGia", donGia));
                    cmd.Parameters.Add(new OracleParameter("LoaiSP", loaiSP));
                    cmd.Parameters.Add(new OracleParameter("SoLuongTon", soLuongTon));
                    cmd.Parameters.Add(new OracleParameter("MaSP", maSP));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    tran.Commit();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception) 
            { 
                tran.Rollback(); 
                result = false; 
            }
            finally 
            { 
                DataProvider.DongKetNoi(conn);
            }
            return result;
        }

        // Xóa sản phẩm
        public bool XoaSanPham(string maSP)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            OracleTransaction tran = conn.BeginTransaction();
            bool result = false;

            try
            {
                string query = "DELETE FROM SANPHAM WHERE MaSP = :MaSP";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("MaSP", maSP));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    tran.Commit();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception) 
            { 
                tran.Rollback(); 
                result = false; 
            } // Loi co the do rang buoc khoa ngoai tu CTHD
            finally 
            { 
                DataProvider.DongKetNoi(conn); 
            }
            return result;
        }

        // Nhập kho (tăng số lượng tồn)
        public bool NhapKho(string maSP, int soLuongThem)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;

            try
            {
                string query = "UPDATE SANPHAM " +
                    "SET SoLuongTon = SoLuongTon + :SoLuongThem " +
                    "WHERE MaSP = :MaSP";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("SoLuongThem", soLuongThem));
                    cmd.Parameters.Add(new OracleParameter("MaSP", maSP));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = (rowsAffected > 0);
                }
            }
            catch (Exception) 
            { 
                result = false;
            }
            finally 
            {
                DataProvider.DongKetNoi(conn); 
            }
            return result;
        }

    }
}