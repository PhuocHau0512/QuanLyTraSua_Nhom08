using QuanLyTraSua.QuanLyTraSua_BLL; // Sử dụng BLL
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    // Form Thống Kê Doanh Thu
    public partial class frmThongKe : Form
    {
        private Admin_BLL adminBLL = new Admin_BLL();

        public frmThongKe()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện khi form được tải
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            // Khởi tạo giá trị mặc định cho DateTimePicker
            dtpDenNgay.Value = DateTime.Now;
            dtpTuNgay.Value = DateTime.Now.AddDays(-7);
        }

        // Xử lý sự kiện khi nhấn nút Thống Kê
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            try
            {
                // Lấy dữ liệu thống kê từ BLL
                DataTable dt = adminBLL.GetThongKeDoanhThu(tuNgay, denNgay);
                dgvThongKe.DataSource = dt;

                // Tính tổng doanh thu
                double tongDoanhThu = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Sử dụng Compute để tính tổng cột "Tong Doanh Thu"
                    object sum = dt.Compute("SUM([Tong Doanh Thu])", "");
                    tongDoanhThu = Convert.ToDouble(sum);
                }

                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}