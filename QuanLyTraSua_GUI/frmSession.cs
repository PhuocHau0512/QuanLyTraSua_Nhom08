using QuanLyTraSua.QuanLyTraSua_BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    public partial class frmSession : Form
    {
        // Khởi tạo lớp BLL
        private Admin_BLL adminBLL = new Admin_BLL();

        public frmSession()
        {
            InitializeComponent();
        }

        private void frmSession_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Gọi BLL (đã có)
                dgvSessions.DataSource = adminBLL.GetActiveSessions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKillSession_Click(object sender, EventArgs e)
        {
            if (dgvSessions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiên để ngắt.", "Thông báo");
                return;
            }

            try
            {
                // Lấy SID và Serial# từ dòng được chọn
                DataGridViewRow selectedRow = dgvSessions.SelectedRows[0];
                int sid = Convert.ToInt32(selectedRow.Cells["SID"].Value);
                int serial = Convert.ToInt32(selectedRow.Cells["Serial"].Value);
                string user = selectedRow.Cells["User"].Value.ToString();
                string machine = selectedRow.Cells["Máy trạm"].Value.ToString();

                // Xác nhận
                DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn ngắt kết nối của user '{user}' trên máy '{machine}' (SID: {sid}) không?",
                                                      "Xác nhận Ngắt Phiên",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    // Gọi BLL (đã có)
                    if (adminBLL.KillSession(sid, serial))
                    {
                        MessageBox.Show("Ngắt phiên thành công!", "Thông báo");
                        LoadData(); // Tải lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Ngắt phiên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ngắt phiên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}