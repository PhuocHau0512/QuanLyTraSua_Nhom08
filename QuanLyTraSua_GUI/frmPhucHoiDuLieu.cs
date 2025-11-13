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
    // Form phục hồi dữ liệu sản phẩm từ lịch sử thay đổi
    public partial class frmPhucHoiDuLieu : Form
    {
        private SanPham_BLL sanPhamBLL = new SanPham_BLL();

        public frmPhucHoiDuLieu()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện nút Tìm Kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng nhập Mã Sản phẩm.");
                return;
            }

            try
            { 
                // 1. Lấy dữ liệu vào một biến DataTable tạm
                DataTable dtHistory = sanPhamBLL.GetSanPhamHistory(maSP);

                // 2. Kiểm tra xem DataTable có dữ liệu (không null VÀ có dòng)
                if (dtHistory != null && dtHistory.Rows.Count > 0)
                {
                    // 3. Nếu CÓ dữ liệu, gán DataSource
                    dgvHistory.DataSource = dtHistory;

                    // 4. Chỉ định dạng cột KHI BIẾT CHẮC CÓ DỮ LIỆU
                    dgvHistory.Columns["Thời điểm Bắt đầu"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvHistory.Columns["Thời điểm Kết thúc"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }
                else
                {
                    // 5. Nếu KHÔNG có dữ liệu, gán DataSource là null (để xóa bảng cũ)
                    dgvHistory.DataSource = null;
                    MessageBox.Show("Không tìm thấy lịch sử thay đổi nào cho sản phẩm này (trong 1 ngày qua).", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử: " + ex.Message);
            }
        }

        // Xử lý sự kiện nút Phục Hồi
        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiên bản (một dòng) trong lịch sử để phục hồi.");
                return;
            }

            try
            {
                DataGridViewRow selectedRow = dgvHistory.SelectedRows[0];

                // Lấy thời điểm bắt đầu của phiên bản đó
                // (Đây là thời điểm mà dữ liệu trên dòng đó BẮT ĐẦU có hiệu lực)
                if (selectedRow.Cells["Thời điểm Bắt đầu"].Value == DBNull.Value)
                {
                    MessageBox.Show("Không thể khôi phục phiên bản hiện tại.");
                    return;
                }

                DateTime thoiDiemCanPhucHoi = (DateTime)selectedRow.Cells["Thời điểm Bắt đầu"].Value;
                string maSP = txtMaSP.Text;

                string giaCu = selectedRow.Cells["DonGia"].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn khôi phục giá của '{maSP}' về {giaCu} (tại thời điểm {thoiDiemCanPhucHoi}) không?",
                                                      "Xác nhận Phục hồi",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    if (sanPhamBLL.RestoreGiaSanPham(maSP, thoiDiemCanPhucHoi))
                    {
                        MessageBox.Show("Phục hồi thành công! Vui lòng tải lại lịch sử để xem thay đổi.");
                        // Tải lại lịch sử để thấy dòng "Cập nhật" mới
                        btnTimKiem_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Phục hồi thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi: " + ex.Message);
            }
        }
    }
}
