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
    public partial class frmXemHoaDon : Form
    {
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL();

        public frmXemHoaDon()
        {
            InitializeComponent();
            // Gan su kien SelectionChanged cho dgvHoaDon
            this.dgvHoaDon.SelectionChanged += new System.EventHandler(this.dgvHoaDon_SelectionChanged);
        }

        private void btnTaiDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi hàm GetAllHoaDon (đã được cập nhật ở DAO)
                dgvHoaDon.DataSource = hoaDonBLL.GetAllHoaDon();

                // Tinh chỉnh hiển thị cột ChuKySo
                if (dgvHoaDon.Columns.Contains("ChuKySo"))
                {
                    dgvHoaDon.Columns["ChuKySo"].FillWeight = 50;
                }

                this.Text = $"Xem hóa đơn (User: {Session.MaNV} - Quyền: {Session.Quyen})";
                // Xoa du lieu cu cua bang Chi Tiet
                dgvChiTietHoaDon.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmXemHoaDon_Load(object sender, EventArgs e)
        {
            btnTaiDuLieu_Click(sender, e); // Tải luôn khi mở
        }

        // 
        private void btnKySo_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để ký số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();
            string ketQua = hoaDonBLL.KySoHoaDon(maHD);
            MessageBox.Show(ketQua, "Kết quả Ký số");

            // Tải lại dữ liệu để thấy chữ ký mới
            btnTaiDuLieu_Click(sender, e);
        }

        // 
        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xác thực.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();
            string ketQua = hoaDonBLL.XacThucHoaDon(maHD);

            if (ketQua.Contains("HỢP LỆ"))
            {
                MessageBox.Show(ketQua, "Kết quả Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ketQua.Contains("CHƯA ĐƯỢC KÝ SỐ"))
            {
                MessageBox.Show(ketQua, "Kết quả Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(ketQua, "Kết quả Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 1)
            {
                try
                {
                    // 1. Lay MaHD tu dong duoc chon
                    string maHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();

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