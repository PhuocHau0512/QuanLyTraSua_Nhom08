using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using QuanLyTraSua.QuanLyTraSua_DTO;
using Oracle.ManagedDataAccess.Client;

namespace QuanLyTraSua.QuanLyTraSua_DAO
{
    // DAO cho bảng TAIKHOAN
    public class TaiKhoan_DAO
    { 
        // Lấy thông tin tài khoản theo tên tài khoản
        public TaiKhoan_DTO GetTaiKhoan(string tenTK)
        {
            // (Hàm này vẫn dùng để kiểm tra đăng ký, không đổi)
            TaiKhoan_DTO tk = null;

            OracleConnection conn = DataProvider.MoKetNoi();

            if (conn == null) return null;

            string query = "SELECT TenTK, MatKhau, MaNV, Quyen " +
                "FROM TAIKHOAN " +
                "WHERE TenTK = :tenTK";

            try
            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("tenTK", tenTK));

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tk = new TaiKhoan_DTO
                            {
                                TenTK = reader["TenTK"].ToString(),

                                MatKhau = (byte[])reader["MatKhau"],

                                MaNV = reader["MaNV"].ToString(),

                                Quyen = reader["Quyen"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception) 
            {
                tk = null; 
            }
            finally
            { 
                DataProvider.DongKetNoi(conn);
            }
            return tk;
        }


        // Cập nhật hàm kiểm tra đăng nhập với tham số OLS
        public bool KiemTraDangNhap(string tenTK, string matKhau_plain, out string quyen, out string maNV, out string thongBaoLoi, out string olsLabel)
        {
            OracleConnection conn = DataProvider.MoKetNoi();

            quyen = null;
            maNV = null;
            olsLabel = null; // Khởi tạo

            if (conn == null) 
            { 
                thongBaoLoi = "Lỗi kết nối CSDL"; 
                return false; 
            }

            thongBaoLoi = "Lỗi không xác định";

            try
            {
                using (OracleCommand cmd = new OracleCommand("SP_KiemTraDangNhap", conn))
                {
                    // Đặt kiểu lệnh là thủ tục lưu trữ
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_tenTK", OracleDbType.Varchar2, tenTK, ParameterDirection.Input));

                    // Gửi mật khẩu dạng chuỗi (plain text)
                    cmd.Parameters.Add(new OracleParameter("p_matKhau_Plain", OracleDbType.Varchar2, matKhau_plain, ParameterDirection.Input));

                    // Tham số đầu ra
                    OracleParameter p_ketQua = new OracleParameter("p_ketQua", OracleDbType.Varchar2, 50, null, ParameterDirection.Output);
                    OracleParameter p_quyen = new OracleParameter("p_quyen", OracleDbType.Varchar2, 50, null, ParameterDirection.Output);
                    OracleParameter p_manv = new OracleParameter("p_manv", OracleDbType.Varchar2, 10, null, ParameterDirection.Output);

                    // Thêm tham số OLS 
                    OracleParameter p_ols_label = new OracleParameter("p_ols_label", OracleDbType.Varchar2, 100, null, ParameterDirection.Output);

                    cmd.Parameters.Add(p_ketQua);
                    cmd.Parameters.Add(p_quyen);
                    cmd.Parameters.Add(p_manv);
                    cmd.Parameters.Add(p_ols_label);

                    cmd.ExecuteNonQuery();
                    string spResult = p_ketQua.Value.ToString();

                    if (spResult == "SUCCESS")
                    {
                        quyen = p_quyen.Value.ToString();
                        maNV = p_manv.Value.ToString();
                        olsLabel = p_ols_label.Value.ToString(); // Lấy nhãn OLS
                        thongBaoLoi = null;
                        return true;
                    }

                    if (spResult == "FAIL_USERNAME") thongBaoLoi = "Tài khoản không tồn tại";

                    else if (spResult == "FAIL_PASSWORD") thongBaoLoi = "Mật khẩu không chính xác";

                    return false;
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 28000) thongBaoLoi = "Tài khoản đã bị khóa do đăng nhập sai quá 3 lần!";

                else thongBaoLoi = "Lỗi Oracle: " + ex.Message;

                return false;
            }
            catch (Exception ex)
            {
                thongBaoLoi = "Lỗi: " + ex.Message;
                return false;
            }
            finally { DataProvider.DongKetNoi(conn); }
        }

        // Thêm tài khoản mới
        public bool ThemTaiKhoan(TaiKhoan_DTO tk)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            string query = "INSERT INTO TAIKHOAN (TenTK, MatKhau, MaNV, Quyen) VALUES (:TenTK, :MatKhau, :MaNV, :Quyen)";
            bool result = false;
            try
            {
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("TenTK", tk.TenTK));
                    cmd.Parameters.Add(new OracleParameter("MatKhau", OracleDbType.Raw, tk.MatKhau, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("MaNV", tk.MaNV));
                    cmd.Parameters.Add(new OracleParameter("Quyen", tk.Quyen));
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
    }
}