using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyTraSua.QuanLyTraSua_DAO;
using QuanLyTraSua.QuanLyTraSua_DTO;

namespace QuanLyTraSua.QuanLyTraSua_BLL
{
    public class TaiKhoan_BLL
    {
        private TaiKhoan_DAO taiKhoanDAO = new TaiKhoan_DAO();

        // ĐÃ SỬA: Thêm out string olsLabel, đổi matKhau
        public bool KiemTraDangNhap(string tenTK, string matKhau_plain, out string quyen, out string maNV, out string thongBaoLoi, out string olsLabel)
        {
            quyen = null;
            maNV = null;
            thongBaoLoi = null;
            olsLabel = null; // Khởi tạo

            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau_plain))
            {
                thongBaoLoi = "Vui lòng nhập đầy đủ thông tin";
                return false;
            }

            // Bỏ mã hóa ở BLL (Bước 3)

            // Gửi mật khẩu dạng string (matKhau_plain) xuống DAO
            return taiKhoanDAO.KiemTraDangNhap(tenTK, matKhau_plain, out quyen, out maNV, out thongBaoLoi, out olsLabel);
        }

        public string DangKyTaiKhoan(string tenTK, string matKhau_plain, string maNV)
        {
            // (Hàm này không đổi, dùng cho frmDangKy)
            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau_plain) || string.IsNullOrEmpty(maNV))
            {
                return "Thông tin không được để trống";
            }
            if (taiKhoanDAO.GetTaiKhoan(tenTK) != null)
            {
                return "Tên tài khoản đã tồn tại";
            }
            try
            {
                byte[] matKhauEncrypted = MaHoa_Helper.EncryptAES(matKhau_plain);
                TaiKhoan_DTO tk_new = new TaiKhoan_DTO
                {
                    TenTK = tenTK,
                    MatKhau = matKhauEncrypted,
                    MaNV = maNV,
                    Quyen = "NhanVien"
                };
                if (taiKhoanDAO.ThemTaiKhoan(tk_new))
                {
                    return "Đăng ký thành công";
                }
                else
                {
                    return "Đăng ký thất bại, đã có lỗi xảy ra";
                }
            }
            catch (Exception)
            {
                return "Lỗi trong quá trình mã hóa khi đăng ký";
            }
        }
    }
}