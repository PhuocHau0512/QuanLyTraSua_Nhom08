using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTraSua.QuanLyTraSua_DTO
{ 
    // DTO cho bảng TAIKHOAN
    public class TaiKhoan_DTO
    {
        public string TenTK { get; set; } // Tên tài khoản
        public byte[] MatKhau { get; set; } // Dạng đã mã hóa AES
        public string MaNV { get; set; } // Mã nhân viên
        public string Quyen { get; set; } // Quyền (Admin/NhanVien)
    }
}