using QuanLyTraSua.QuanLyTraSua_DAO;
using System;
using System.Data;

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    // BLL cho Quản lý Nhân Viên
    public class NhanVien_BLL
    {
        // DAO để gọi các hàm truy xuất CSDL
        private NhanVien_DAO nhanVienDAO = new NhanVien_DAO();

        //  Các hàm BLL gọi DAO
        public DataTable GetAllNhanVien()
        {
            return nhanVienDAO.GetAllNhanVien(); // Trả về DataTable chứa tất cả nhân viên
        }

        // Các hàm BLL có thêm logic nghiệp vụ
        public string ThemNhanVien(string maNV, string tenNV, string sdt_plain, string diaChi_plain, string ngayVaoLam)
        {
            // Logic nghiep vu
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt_plain))
            {
                return "Mã NV, Tên NV và SĐT không được để trống."; // Kiểm tra trường bắt buộc
            }

            if (maNV.Length > 10) // Giới hạn độ dài Mã NV
            {
                return "Mã NV không được quá 10 ký tự."; // Kiểm tra độ dài
            }

            DateTime ngayVL; // Kiểm tra định dạng ngày tháng

            if (!DateTime.TryParse(ngayVaoLam, out ngayVL))
            {
                return "Ngày vào làm không hợp lệ."; 
            }

            // Gọi DAO để thêm nhân viên
            if (nhanVienDAO.ThemNhanVien(maNV, tenNV, sdt_plain, diaChi_plain, ngayVL))
            {
                return "Thêm nhân viên thành công."; // Thành công
            }
            else
            {
                return "Thêm nhân viên thất bại (Có thể do trùng Mã NV hoặc lỗi CSDL)."; // Thất bại
            }
        }

        // Cập nhật thông tin nhân viên
        public string CapNhatNhanVien(string maNV, string tenNV, string sdt_plain, string diaChi_plain, string ngayVaoLam)
        {
            // Logic nghiep vu
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt_plain))
            {
                return "Mã NV, Tên NV và SĐT không được để trống."; // Kiểm tra trường bắt buộc
            }

            DateTime ngayVL; // Kiểm tra định dạng ngày tháng

            if (!DateTime.TryParse(ngayVaoLam, out ngayVL))
            {
                return "Ngày vào làm không hợp lệ.";
            }

            // Gọi DAO để cập nhật nhân viên
            if (nhanVienDAO.CapNhatNhanVien(maNV, tenNV, sdt_plain, diaChi_plain, ngayVL))
            {
                return "Cập nhật nhân viên thành công."; // 
            }
            else
            {
                return "Cập nhật thất bại.";
            }
        }

        // Xóa nhân viên
        public string XoaNhanVien(string maNV)
        {
            // Logic nghiep vu
            if (string.IsNullOrEmpty(maNV))
            {
                return "Vui lòng chọn nhân viên để xóa."; // Kiểm tra mã NV không được trống
            }

            if (nhanVienDAO.XoaNhanVien(maNV)) // Gọi DAO để xóa nhân viên
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