using QuanLyTraSua.QuanLyTraSua_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Chào mừng người dùng
            this.Text = $"Chương Trình Quản Lý Trà Sữa (Chào: {Session.MaNV} - Quyền: {Session.Quyen})";

            // Phân quyền trên GIAO DIỆN
            // Nếu người dùng là Nhân viên, ẩn các menu quản trị
            if (Session.Quyen == "NhanVien")
            {
                // Ẩn menu Danh mục (Quản lý nhân viên, sản phẩm)
                danhMụcToolStripMenuItem.Visible = false;

                // Ẩn menu Bảo mật (Phân quyền, Giám sát, Phục hồi)
                bảoMậtToolStripMenuItem.Visible = false;
            }
            // Nếu là Admin, tất cả menu sẽ hiển thị (mặc định)
        }

        #region == Hệ thống ==

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Xóa thông tin session tĩnh
            Session.Clear();

            // Đóng form main và mở lại form đăng nhập
            frmDangNhap frmLogin = new frmDangNhap();
            frmLogin.Show();
            this.Hide();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Đảm bảo ứng dụng tắt hẳn khi đóng form Main
            // (Đề phòng trường hợp form đăng nhập vẫn bị ẩn)
            Application.Exit();
        }

        #endregion

        #region == Danh mục (Admin) ==

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form Quản lý nhân viên
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog(); // ShowDialog để nó hiện đè lên form Main
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.ShowDialog();
        }

        // ** HAM MOI **
        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapKho frm = new frmNhapKho();
            frm.ShowDialog();
        }

        #endregion

        #region == Nghiệp vụ ==

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // (Đây là form nghiệp vụ chính)
            frmBanHang frm = new frmBanHang();
            frm.ShowDialog();
        }

        private void xemHóaĐơnVPDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form demo VPD
            frmXemHoaDon frm = new frmXemHoaDon();
            frm.ShowDialog();
        }

        #endregion

        #region == Bảo mật (Admin) ==

        private void phânQuyềnCSDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form Phân quyền ROLE
            frmPhanQuyen frm = new frmPhanQuyen();
            frm.ShowDialog();
        }

        private void giámSátFGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form xem nhật ký FGA
            frmGiamSat frm = new frmGiamSat();
            frm.ShowDialog();
        }

        private void phụcHồiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form Phục hồi Flashback
            frmPhucHoiDuLieu frm = new frmPhucHoiDuLieu();
            frm.ShowDialog();
        }

        private void quảnLýPhiênĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form Quản lý Session
            frmSession frm = new frmSession();
            frm.ShowDialog();
        }
        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form Thống kê
            frmThongKe frm = new frmThongKe();
            frm.ShowDialog();
        }

        #endregion
    }
}