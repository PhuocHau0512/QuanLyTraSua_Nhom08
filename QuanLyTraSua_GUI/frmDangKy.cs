using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyTraSua.QuanLyTraSua_BLL; // Sử dụng BLL

namespace QuanLyTraSua.QuanLyTraSua_GUI
{ 
    // Form đăng ký tài khoản mới
    public partial class frmDangKy : Form
    {
        private TaiKhoan_BLL taiKhoanBLL = new TaiKhoan_BLL();

        public frmDangKy()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện nút Đăng Ký
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ketQua = taiKhoanBLL.DangKyTaiKhoan(
                txtTenTK.Text,
                txtMatKhau.Text, // Gửi mật khẩu plaintext
                txtMaNV.Text
            );

            MessageBox.Show(ketQua, "Thông báo");

            if (ketQua == "Đăng ký thành công")
            {
                this.Close();
            }
        }

        // Xử lý sự kiện nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
