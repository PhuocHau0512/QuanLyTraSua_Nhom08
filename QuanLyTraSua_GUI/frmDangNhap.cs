using QuanLyTraSua.QuanLyTraSua_BLL; // SỬ DỤNG NAMESPACE BLL ĐỂ TRUY CẬP TAIKHOAN_BLL
using QuanLyTraSua.QuanLyTraSua_GUI; // SỬ DỤNG NAMESPACE GUI ĐỂ TRUY CẬP frmMain VÀ frmDangKy
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua
{
    // Form đăng nhập
    public partial class frmDangNhap : Form
    {
        private TaiKhoan_BLL taiKhoanBLL = new TaiKhoan_BLL();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện nút Đăng Nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTK.Text;
            string matKhau = txtMatKhau.Text; 

            string quyen, maNV, thongBaoLoi, olsLabel;

            // Gọi phương thức kiểm tra đăng nhập từ lớp BLL
            bool dangNhapThanhCong = taiKhoanBLL.KiemTraDangNhap(tenTK, matKhau, out quyen, out maNV, out thongBaoLoi, out olsLabel);

            if (dangNhapThanhCong)
            {
                MessageBox.Show($"Đăng nhập thành công với quyền: {quyen}", "Thông báo");

                // LƯU SESSION TOÀN CỤC (Thêm OLS Label)
                Session.MaNV = maNV;
                Session.Quyen = quyen;
                Session.OlsLabel = olsLabel; // <-- LƯU NHÃN OLS

                frmMain frmMain = new frmMain();
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(thongBaoLoi, "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Xử lý sự kiện nút Đăng Ký
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy frm = new frmDangKy();
            frm.ShowDialog();
        }
    }
}