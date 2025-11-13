using QuanLyTraSua.QuanLyTraSua_DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    public class SanPham_BLL
    {
        private SanPham_DAO sanPhamDAO = new SanPham_DAO();
        public DataTable GetSanPhamHistory(string maSP) { return sanPhamDAO.GetSanPhamHistory(maSP); }
        public bool RestoreGiaSanPham(string maSP, DateTime timestamp) { return sanPhamDAO.RestoreGiaSanPham(maSP, timestamp); }

        public DataTable GetActiveSanPham()
        {
            return sanPhamDAO.GetActiveSanPham();
        }

        public DataTable GetAllSanPham()
        {
            return sanPhamDAO.GetAllSanPham();
        }

        // ** CAP NHAT: Them soLuongTon **
        public string ThemSanPham(string maSP, string tenSP, string donGia, string loaiSP, string soLuongTon)
        {
            // Logic nghiep vu
            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP))
            {
                return "Mã SP và Tên SP không được trống.";
            }
            double gia;
            if (!double.TryParse(donGia, out gia) || gia < 0)
            {
                return "Đơn giá không hợp lệ.";
            }
            int tonKho; // <-- THEM MOI
            if (!int.TryParse(soLuongTon, out tonKho) || tonKho < 0)
            {
                return "Số lượng tồn không hợp lệ.";
            }

            if (sanPhamDAO.ThemSanPham(maSP, tenSP, gia, loaiSP, tonKho))
            {
                return "Thêm sản phẩm thành công.";
            }
            else
            {
                return "Thêm thất bại (Lỗi CSDL hoặc trùng Mã SP).";
            }
        }

        // ** CAP NHAT: Them soLuongTon **
        public string CapNhatSanPham(string maSP, string tenSP, string donGia, string loaiSP, string soLuongTon)
        {
            // Logic nghiep vu
            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP))
            {
                return "Mã SP và Tên SP không được trống.";
            }
            double gia;
            if (!double.TryParse(donGia, out gia) || gia < 0)
            {
                return "Đơn giá không hợp lệ.";
            }
            int tonKho; // <-- THEM MOI
            if (!int.TryParse(soLuongTon, out tonKho) || tonKho < 0)
            {
                return "Số lượng tồn không hợp lệ.";
            }

            if (sanPhamDAO.CapNhatSanPham(maSP, tenSP, gia, loaiSP, tonKho))
            {
                return "Cập nhật sản phẩm thành công.";
            }
            else
            {
                return "Cập nhật thất bại.";
            }
        }

        public string XoaSanPham(string maSP)
        {
            if (string.IsNullOrEmpty(maSP))
            {
                return "Vui lòng chọn sản phẩm để xóa.";
            }

            if (sanPhamDAO.XoaSanPham(maSP))
            {
                return "Xóa sản phẩm thành công.";
            }
            else
            {
                return "Xóa thất bại (Lỗi CSDL hoặc sản phẩm đã được dùng trong Hóa Đơn).";
            }
        }

        // ** HAM MOI (Nghiep Vu Kho) **
        public string NhapKho(string maSP, int soLuongThem)
        {
            if (string.IsNullOrEmpty(maSP))
            {
                return "Vui lòng chọn sản phẩm.";
            }
            if (soLuongThem <= 0)
            {
                return "Số lượng nhập thêm phải lớn hơn 0.";
            }

            if (sanPhamDAO.NhapKho(maSP, soLuongThem))
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