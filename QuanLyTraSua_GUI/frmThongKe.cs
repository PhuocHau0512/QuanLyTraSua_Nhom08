using QuanLyTraSua.QuanLyTraSua_BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    public partial class frmThongKe : Form
    {
        private Admin_BLL adminBLL = new Admin_BLL();

        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            // Dat mac dinh la thong ke trong 1 tuan qua
            dtpDenNgay.Value = DateTime.Now;
            dtpTuNgay.Value = DateTime.Now.AddDays(-7);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            try
            {
                // Goi BLL de lay data
                DataTable dt = adminBLL.GetThongKeDoanhThu(tuNgay, denNgay);
                dgvThongKe.DataSource = dt;

                // Tinh tong doanh thu
                double tongDoanhThu = 0;
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Tinh tong cot "Tong Doanh Thu"
                    object sum = dt.Compute("SUM([Tổng Doanh Thu])", "");
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