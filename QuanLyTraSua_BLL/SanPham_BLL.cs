using QuanLyTraSua.QuanLyTraSua_DAO; // DAO để truy xuất CSDL
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    // BLL: Business Logic Layer - Xử lý nghiệp vụ
    public class SanPham_BLL
    {
        // DAO để gọi các hàm truy xuất CSDL
        private SanPham_DAO sanPhamDAO = new SanPham_DAO();

        //  Các hàm BLL gọi DAO
        public DataTable GetSanPhamHistory(string maSP) 
        { 
            return sanPhamDAO.GetSanPhamHistory(maSP); // Trả về DataTable chứa lịch sử thay đổi giá sản phẩm
        } 
        public bool RestoreGiaSanPham(string maSP, DateTime timestamp) 
        { 
            return sanPhamDAO.RestoreGiaSanPham(maSP, timestamp);  // Phục hồi giá sản phẩm theo timestamp
        } 

        // Các hàm BLL có thêm logic nghiệp vụ
        public DataTable GetActiveSanPham(string quyen)
        {
            return sanPhamDAO.GetActiveSanPham(quyen); // Trả về DataTable chứa sản phẩm theo quyền
        }

        public DataTable GetAllSanPham() // Dành cho Admin/Quản lý
        {
            return sanPhamDAO.GetAllSanPham();
        }

        // Kiểm tra số lượng tồn kho của sản phẩm
        public string ThemSanPham(string maSP, string tenSP, string donGia, string loaiSP, string soLuongTon)
        {
            // Logic nghiep vu
            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP))
            {
                return "Mã SP và Tên SP không được trống.";
            }

            // ** KIEM TRA DON GIA **
            double gia;  
            if (!double.TryParse(donGia, out gia) || gia < 0) 
            {
                return "Đơn giá không hợp lệ.";
            }

            // ** KIEM TRA SO LUONG TON KHO **
            int tonKho; 
            if (!int.TryParse(soLuongTon, out tonKho) || tonKho < 0)
            {
                return "Số lượng tồn không hợp lệ.";
            }
            // Gọi DAO để thêm sản phẩm
            if (sanPhamDAO.ThemSanPham(maSP, tenSP, gia, loaiSP, tonKho))
            {
                return "Thêm sản phẩm thành công.";
            }
            else
            {
                return "Thêm thất bại (Lỗi CSDL hoặc trùng Mã SP).";
            }
        }

        // Cập nhật thông tin sản phẩm
        public string CapNhatSanPham(string maSP, string tenSP, string donGia, string loaiSP, string soLuongTon)
        {
            // Logic nghiep vu
            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP))
            {
                return "Mã SP và Tên SP không được trống.";
            }

            // ** KIEM TRA DON GIA **
            double gia;
            if (!double.TryParse(donGia, out gia) || gia < 0)
            {
                return "Đơn giá không hợp lệ.";
            }
            // ** KIEM TRA SO LUONG TON KHO **
            int tonKho; 
            if (!int.TryParse(soLuongTon, out tonKho) || tonKho < 0)
            {
                return "Số lượng tồn không hợp lệ.";
            }

            // Gọi DAO để cập nhật sản phẩm
            if (sanPhamDAO.CapNhatSanPham(maSP, tenSP, gia, loaiSP, tonKho))
            {
                return "Cập nhật sản phẩm thành công.";
            }
            else
            {
                return "Cập nhật thất bại.";
            }
        }

        // Xóa sản phẩm
        public string XoaSanPham(string maSP)
        {
            if (string.IsNullOrEmpty(maSP)) // Kiểm tra mã sản phẩm
            {
                return "Vui lòng chọn sản phẩm để xóa.";
            }

            if (sanPhamDAO.XoaSanPham(maSP)) // Gọi DAO để xóa sản phẩm
            {
                return "Xóa sản phẩm thành công.";
            }
            else
            {
                return "Xóa thất bại (Lỗi CSDL hoặc sản phẩm đã được dùng trong Hóa Đơn).";
            }
        }

        // Nhập kho sản phẩm
        public string NhapKho(string maSP, int soLuongThem)
        {
            if (string.IsNullOrEmpty(maSP)) // Kiểm tra mã sản phẩm
            {
                return "Vui lòng chọn sản phẩm.";
            }
            if (soLuongThem <= 0) // Kiểm tra số lượng nhập thêm
            {
                return "Số lượng nhập thêm phải lớn hơn 0.";
            }

            if (sanPhamDAO.NhapKho(maSP, soLuongThem)) // Gọi DAO để nhập kho
            {
                return "Nhập kho thành công.";
            }
            else
            {
                return "Nhập kho thất bại (Lỗi CSDL).";
            }
        }
    }
}