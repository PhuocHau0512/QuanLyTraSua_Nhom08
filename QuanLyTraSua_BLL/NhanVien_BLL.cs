using QuanLyTraSua.QuanLyTraSua_DAO;
using System;
using System.Data;

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    public class NhanVien_BLL
    {
        private NhanVien_DAO nhanVienDAO = new NhanVien_DAO();

        public DataTable GetAllNhanVien()
        {
            return nhanVienDAO.GetAllNhanVien();
        }

        // ĐÃ SỬA (Bước 9): Thêm diaChi_plain
        public string ThemNhanVien(string maNV, string tenNV, string sdt_plain, string diaChi_plain, string ngayVaoLam)
        {
            // --- Logic nghiệp vụ ---
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt_plain))
            {
                return "Mã NV, Tên NV và SĐT không được để trống.";
            }
            if (maNV.Length > 10)
            {
                return "Mã NV không được quá 10 ký tự.";
            }
            DateTime ngayVL;
            if (!DateTime.TryParse(ngayVaoLam, out ngayVL))
            {
                return "Ngày vào làm không hợp lệ.";
            }
            // --- Kết thúc ---

            if (nhanVienDAO.ThemNhanVien(maNV, tenNV, sdt_plain, diaChi_plain, ngayVL))
            {
                return "Thêm nhân viên thành công.";
            }
            else
            {
                return "Thêm nhân viên thất bại (Có thể do trùng Mã NV hoặc lỗi CSDL).";
            }
        }
        public string CapNhatNhanVien(string maNV, string tenNV, string sdt_plain, string diaChi_plain, string ngayVaoLam)
        {
            // Logic nghiep vu
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt_plain))
            {
                return "Mã NV, Tên NV và SĐT không được để trống.";
            }
            DateTime ngayVL;
            if (!DateTime.TryParse(ngayVaoLam, out ngayVL))
            {
                return "Ngày vào làm không hợp lệ.";
            }

            if (nhanVienDAO.CapNhatNhanVien(maNV, tenNV, sdt_plain, diaChi_plain, ngayVL))
            {
                return "Cập nhật nhân viên thành công.";
            }
            else
            {
                return "Cập nhật thất bại.";
            }
        }

        // --- HAM MOI ---
        public string XoaNhanVien(string maNV)
        {
            if (string.IsNullOrEmpty(maNV))
            {
                return "Vui lòng chọn nhân viên để xóa.";
            }

            if (nhanVienDAO.XoaNhanVien(maNV))
            {
                return "Xóa nhân viên thành công.";
            }
            else
            {
                return "Xóa thất bại (Lỗi CSDL hoặc Nhân viên này đã có Tài khoản/Hóa đơn).";
            }
        }
    }
}