using System;
using System.Data;
using Oracle.ManagedDataAccess.Client; // Thư viện Oracle

namespace QuanLyTraSua.QuanLyTraSua_DAO
{
    public class NhanVien_DAO
    {
        // DAO cho Quản lý Nhân Viên
        public DataTable GetAllNhanVien()
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return null;

            // Query này gọi cả 2 hàm giải mã: RSA (SĐT) và Hybrid (Địa chỉ)
            string query = @"
                SELECT MaNV, TenNV, 
                       QLTS.PKG_MAHOA_RSA.F_DECRYPT_SDT(SDT_ENCRYPTED) AS SDT, 
                       QLTS.PKG_MAHOA_HYBRID.F_DECRYPT_DIACHI(DiaChi_Encrypted, DiaChi_Key_Encrypted) AS DiaChi,
                       NgayVaoLam 
                FROM NHANVIEN";

            DataTable dt = DataProvider.ThucThiTruyVan(query, conn);
            DataProvider.DongKetNoi(conn);
            return dt;
        }

        // Thêm nhân viên mới
        public bool ThemNhanVien(string maNV, string tenNV, string sdt_plain, string diaChi_plain, DateTime ngayVaoLam)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;
            try
            {
                // Gọi thủ tục lưu trữ để thêm nhân viên
                using (OracleCommand cmd = new OracleCommand("SP_NhanVien_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_MaNV", maNV));
                    cmd.Parameters.Add(new OracleParameter("p_TenNV", tenNV));
                    cmd.Parameters.Add(new OracleParameter("p_SDT_Plain", sdt_plain));
                    cmd.Parameters.Add(new OracleParameter("p_DiaChi_Plain", diaChi_plain));
                    cmd.Parameters.Add(new OracleParameter("p_NgayVaoLam", ngayVaoLam));
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

        // Cập nhật thông tin nhân viên
        public bool CapNhatNhanVien(string maNV, string tenNV, string sdt_plain, string diaChi_plain, DateTime ngayVaoLam)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;
            try
            {// Gọi thủ tục lưu trữ để cập nhật nhân viên
                using (OracleCommand cmd = new OracleCommand("SP_NhanVien_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_MaNV", maNV));
                    cmd.Parameters.Add(new OracleParameter("p_TenNV", tenNV));
                    cmd.Parameters.Add(new OracleParameter("p_SDT_Plain", sdt_plain));
                    cmd.Parameters.Add(new OracleParameter("p_DiaChi_Plain", diaChi_plain));
                    cmd.Parameters.Add(new OracleParameter("p_NgayVaoLam", ngayVaoLam));
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

        // Xóa nhân viên
        public bool XoaNhanVien(string maNV)
        {
            OracleConnection conn = DataProvider.MoKetNoi();
            if (conn == null) return false;
            bool result = false;
            try
            {// Gọi thủ tục lưu trữ để xóa nhân viên
                using (OracleCommand cmd = new OracleCommand("SP_NhanVien_Delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new OracleParameter("p_MaNV", maNV));
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception) 
            { 
                result = false;
            } // Loi khoa ngoai tu TAIKHOAN/HOADON
            finally 
            {
                DataProvider.DongKetNoi(conn);
            }
            return result;
        }
    }
}