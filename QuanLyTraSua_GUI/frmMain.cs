using QuanLyTraSua.QuanLyTraSua_BLL; // SỬ DỤNG NAMESPACE BLL ĐỂ TRUY CẬP CÁC LỚP BLL
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
    // Form Main của ứng dụng
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // Sự kiện Load của form Main
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = $"Chương Trình Quản Lý Trà Sữa (Chào: {Session.MaNV} - Quyền: {Session.Quyen})";

            // Kiểm tra quyền của người dùng để ẩn/hiện menu tương ứng
            if (Session.Quyen == "NhanVien")
            {
                danhMụcToolStripMenuItem.Visible = false;

                bảoMậtToolStripMenuItem.Visible = false;
            }
            // Nếu là Admin, tất cả menu sẽ hiển thị (mặc định)
        }

        #region == Hệ thống ==
        // Xử lý sự kiện đăng xuất
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Xóa thông tin session tĩnh
            Session.Clear();

            frmDangNhap frmLogin = new frmDangNhap();
            frmLogin.Show();
            this.Hide();
        }

        // Xử lý sự kiện thoát ứng dụng
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //  Xử lý sự kiện đóng form Main
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region == Danh mục (Admin) ==
        // Xử lý sự kiện mở form Quản lý nhân viên
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog(); 
        }

        // Xử lý sự kiện mở form Quản lý khách hàng
        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.ShowDialog();
        }

        // Xử lý sự kiện mở form Quản lý loại sản phẩm
        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapKho frm = new frmNhapKho();
            frm.ShowDialog();
        }
        #endregion

        #region == Nghiệp vụ ==

        // Xử lý sự kiện mở form Bán hàng
        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanHang frm = new frmBanHang();
            frm.ShowDialog();
        }

        // Xử lý sự kiện mở form Xem hóa đơn VPD
        private void xemHóaĐơnVPDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXemHoaDon frm = new frmXemHoaDon();
            frm.ShowDialog();
        }
        #endregion

        #region == Bảo mật (Admin) ==
        // Xử lý sự kiện mở form Phân quyền CSDL
        private void phânQuyềnCSDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhanQuyen frm = new frmPhanQuyen();
            frm.ShowDialog();
        }

        // Xử lý sự kiện mở form Giám sát FGA
        private void giámSátFGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGiamSat frm = new frmGiamSat();
            frm.ShowDialog();
        }

        // Xử lý sự kiện mở form Phục hồi dữ liệu
        private void phụcHồiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhucHoiDuLieu frm = new frmPhucHoiDuLieu();
            frm.ShowDialog();
        }

        // Xử lý sự kiện mở form Quản lý phiên đăng nhập
        private void quảnLýPhiênĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSession frm = new frmSession();
            frm.ShowDialog();
        }

        // Xử lý sự kiện mở form Thống kê doanh thu
        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.ShowDialog();
        }
        #endregion
    }
}