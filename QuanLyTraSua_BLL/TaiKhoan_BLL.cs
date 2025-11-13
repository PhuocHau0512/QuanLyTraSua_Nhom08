using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyTraSua.QuanLyTraSua_DAO; // Gọi DAO
using QuanLyTraSua.QuanLyTraSua_DTO; // Gọi DTO

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    // BLL: Business Logic Layer - Xử lý nghiệp vụ
    public class TaiKhoan_BLL
    {
        // DAO để gọi các hàm truy xuất CSDL
        private TaiKhoan_DAO taiKhoanDAO = new TaiKhoan_DAO();

        // Hàm kiểm tra đăng nhập
        public bool KiemTraDangNhap(string tenTK, string matKhau_plain, out string quyen, out string maNV, out string thongBaoLoi, out string olsLabel)
        {
            // Khai báo biến out
            quyen = null;
            maNV = null;
            thongBaoLoi = null;
            olsLabel = null; 

            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau_plain)) // Kiểm tra đầu vào
            {
                thongBaoLoi = "Vui lòng nhập đầy đủ thông tin";
                return false;
            }

            // Gửi mật khẩu dạng string (matKhau_plain) xuống DAO
            return taiKhoanDAO.KiemTraDangNhap(tenTK, matKhau_plain, out quyen, out maNV, out thongBaoLoi, out olsLabel);
        }

        // Hàm đăng ký tài khoản
        public string DangKyTaiKhoan(string tenTK, string matKhau_plain, string maNV)
        {
            // (Hàm này không đổi, dùng cho frmDangKy)
            // Logic nghiệp vụ
            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau_plain) || string.IsNullOrEmpty(maNV))
            {
                return "Thông tin không được để trống";
            }

            if (taiKhoanDAO.GetTaiKhoan(tenTK) != null) // Kiểm tra tài khoản đã tồn tại
            {
                return "Tên tài khoản đã tồn tại";
            }
            // Mã hóa mật khẩu
            try
            {
                byte[] matKhauEncrypted = MaHoa_Helper.EncryptAES(matKhau_plain); // Mã hóa mật khẩu
                TaiKhoan_DTO tk_new = new TaiKhoan_DTO // Tạo đối tượng TaiKhoan_DTO mới
                {
                    TenTK = tenTK, 
                    MatKhau = matKhauEncrypted,
                    MaNV = maNV,
                    Quyen = "NhanVien"
                };
                // Gọi DAO để thêm tài khoản
                if (taiKhoanDAO.ThemTaiKhoan(tk_new))
                {
                    return "Đăng ký thành công";
                }
                else
                {
                    return "Đăng ký thất bại, đã có lỗi xảy ra";
                }
            }
            // Bắt lỗi mã hóa
            catch (Exception)
            {
                return "Lỗi trong quá trình mã hóa khi đăng ký";
            }
        }
    }
}