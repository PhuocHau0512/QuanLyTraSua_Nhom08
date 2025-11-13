using QuanLyTraSua.QuanLyTraSua_BLL; // Sử dụng BLL
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
    // Form xem hóa đơn và ký số, xác thực
    public partial class frmXemHoaDon : Form
    {
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL();

        public frmXemHoaDon()
        {
            InitializeComponent();
            // Đăng ký sự kiện SelectionChanged cho dgvHoaDon
            this.dgvHoaDon.SelectionChanged += new System.EventHandler(this.dgvHoaDon_SelectionChanged);
        }

        // Tải dữ liệu hóa đơn
        private void btnTaiDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi BLL -> DAO -> SELECT *
                dgvHoaDon.DataSource = hoaDonBLL.GetAllHoaDon();

                // Điều chỉnh độ rộng cột CHUKYSO nếu tồn tại
                if (dgvHoaDon.Columns.Contains("CHUKYSO"))
                {
                    dgvHoaDon.Columns["CHUKYSO"].FillWeight = 50;
                }

                this.Text = $"Xem hóa đơn (User: {Session.MaNV} - Quyền: {Session.Quyen})";
                // Xóa bảng chi tiết hóa đơn
                dgvChiTietHoaDon.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi form được tải
        private void frmXemHoaDon_Load(object sender, EventArgs e)
        {
            btnTaiDuLieu_Click(sender, e); // Tải luôn khi mở
        }

        // Ký số hóa đơn
        private void btnKySo_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để ký số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy mã hóa đơn từ dòng được chọn
            string maHD = dgvHoaDon.SelectedRows[0].Cells["MAHD"].Value.ToString();
            string ketQua = hoaDonBLL.KySoHoaDon(maHD);
            MessageBox.Show(ketQua, "Kết quả Ký số");

            // Tải lại dữ liệu để thấy chữ ký mới
            btnTaiDuLieu_Click(sender, e);
        }

        // Xác thực hóa đơn
        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xác thực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy mã hóa đơn từ dòng được chọn
            string maHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();
            string ketQua = hoaDonBLL.XacThucHoaDon(maHD);

            if (ketQua.Contains("HOP LE"))
            {
                MessageBox.Show(ketQua, "Kết quả Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ketQua.Contains("CHUA DUOC KY SO"))
            {
                MessageBox.Show(ketQua, "Kết quả Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(ketQua, "Kết quả Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi chọn dòng trong dgvHoaDon thay đổi
        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 1)
            {
                try
                {
                    // 1. Lay ma hoa don tu dong chon
                    string maHD = dgvHoaDon.SelectedRows[0].Cells["MAHD"].Value.ToString();

                    // 2. Goi BLL/DAO de lay chi tiet
                    DataTable dtChiTiet = hoaDonBLL.GetChiTietHoaDon(maHD);

                    // 3. Hien thi len dgvChiTietHoaDon
                    dgvChiTietHoaDon.DataSource = dtChiTiet;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi");
                    dgvChiTietHoaDon.DataSource = null;
                }
            }
            else
            {
                // Neu khong chon hoa don nao thi xoa bang chi tiet
                dgvChiTietHoaDon.DataSource = null;
            }
        }
    }
}