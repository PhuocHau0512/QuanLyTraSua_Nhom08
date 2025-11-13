using QuanLyTraSua.QuanLyTraSua_BLL;
using QuanLyTraSua.QuanLyTraSua_GUI;
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
    public partial class frmDangNhap : Form
    {
        private TaiKhoan_BLL taiKhoanBLL = new TaiKhoan_BLL();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        // ĐÃ SỬA (Bước 3 và 8)
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTK.Text;
            string matKhau = txtMatKhau.Text; // Mật khẩu plaintext

            string quyen, maNV, thongBaoLoi, olsLabel; // Thêm olsLabel

            // Sửa lời gọi BLL (gửi matKhau, nhận olsLabel)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy frm = new frmDangKy();
            frm.ShowDialog();
        }
    }
}