using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTraSua.QuanLyTraSua_GUI; // SỬ DỤNG NAMESPACE GUI ĐỂ TRUY CẬP frmMain VÀ frmDangKy

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    // Lớp Session để lưu thông tin đăng nhập toàn cục
    public class Session
    {
        public static string MaNV { get; set; } // Mã nhân viên
        public static string Quyen { get; set; } // Quyền (Admin/NhanVien)
        public static string OlsLabel { get; set; } // Nhãn OLS

        // Xóa session khi đăng xuất
        public static void Clear()
        {
            MaNV = null;
            Quyen = null;
            OlsLabel = null;
        }
    }
}