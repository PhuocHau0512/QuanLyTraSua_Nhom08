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
    // Form Giám Sát Hoạt Động Hệ Thống
    public partial class frmGiamSat : Form
    {
        private Admin_BLL adminBLL = new Admin_BLL();

        public frmGiamSat()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện khi form được tải
        private void frmGiamSat_Load(object sender, EventArgs e)
        {
            LoadLogs();
        }

        // Xử lý sự kiện nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }

        // Hàm tải nhật ký từ BLL và hiển thị lên DataGridView
        private void LoadLogs()
        {
            try
            {
                dgvLogs.DataSource = adminBLL.GetFGAAuditLog();
                // Tùy chỉnh độ rộng cột
                dgvLogs.Columns["Thời gian"].Width = 140;
                dgvLogs.Columns["User"].Width = 100;
                dgvLogs.Columns["Máy trạm"].Width = 120;
                dgvLogs.Columns["Câu lệnh"].FillWeight = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhật ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
