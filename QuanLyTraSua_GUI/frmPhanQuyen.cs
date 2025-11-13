using QuanLyTraSua.QuanLyTraSua_BLL; // SỬ DỤNG NAMESPACE BLL ĐỂ TRUY CẬP ADMIN_BLL
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
    // Form phân quyền cho người dùng Oracle
    public partial class frmPhanQuyen : Form
    {
        private Admin_BLL adminBLL = new Admin_BLL();
        private List<string> allRoles = new List<string>(); // Lưu tất cả các role từ Oracle

        public frmPhanQuyen()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện Load form
        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            LoadAllUsers();
            LoadAllRoles();
        }

        // Tải tất cả user từ Oracle vào combobox
        private void LoadAllUsers()
        {
            DataTable dt = adminBLL.GetOracleUsers();
            if (dt != null)
            {
                cmbUsers.DataSource = dt;
                cmbUsers.DisplayMember = "USERNAME";
                cmbUsers.ValueMember = "USERNAME";
            }
        }

        // Tải tất cả role từ Oracle vào danh sách allRoles
        private void LoadAllRoles()
        {
            DataTable dt = adminBLL.GetOracleRoles();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    allRoles.Add(row["ROLE"].ToString());
                }
            }
        }

        // Xử lý sự kiện khi chọn user khác trong combobox
        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedValue == null) return;

            string selectedUser = cmbUsers.SelectedValue.ToString();
            LoadRolesForUser(selectedUser);
        }

        // Tải danh sách role đã cấp và chưa cấp cho user
        private void LoadRolesForUser(string username)
        {
            // Lấy danh sách role đã cấp từ BLL
            DataTable dtGranted = adminBLL.GetRolesForUser(username);
            List<string> grantedRoles = new List<string>();
            if (dtGranted != null)
            {
                foreach (DataRow row in dtGranted.Rows)
                {
                    grantedRoles.Add(row["GRANTED_ROLE"].ToString());
                }
            }

            // Lọc ra danh sách role chưa cấp
            List<string> notGrantedRoles = allRoles.Except(grantedRoles).ToList();

            // Hiển thị lên 2 listbox
            lstDaCap.DataSource = grantedRoles;
            lstChuaCap.DataSource = notGrantedRoles;
        }

        // Xử lý sự kiện cấp role cho user
        private void btnGrant_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedValue == null || lstChuaCap.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn user và role CHƯA CẤP.", "Thông báo");
                return;
            }

            // Lấy user và role được chọn
            string user = cmbUsers.SelectedValue.ToString();
            string role = lstChuaCap.SelectedItem.ToString();

            if (adminBLL.GrantRole(user, role))
            {
                MessageBox.Show($"Cấp quyền '{role}' cho '{user}' thành công.", "Thành công");
                LoadRolesForUser(user); // Tải lại danh sách
            }
            else
            {
                MessageBox.Show("Cấp quyền thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện thu hồi role từ user
        private void btnRevoke_Click(object sender, EventArgs e)
        {
            if (cmbUsers.SelectedValue == null || lstDaCap.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn user và role ĐÃ CẤP.", "Thông báo");
                return;
            }

            // Lấy user và role được chọn
            string user = cmbUsers.SelectedValue.ToString();
            string role = lstDaCap.SelectedItem.ToString();

            // Chỉ giữ lại khối try-catch để xử lý
            try
            {
                if (adminBLL.RevokeRole(user, role))
                {
                    MessageBox.Show($"Thu hồi quyền '{role}' từ '{user}' thành công.", "Thành công");
                    LoadRolesForUser(user); // Tải lại danh sách
                }
                else
                {
                    // Trường hợp thất bại chung (ví dụ: BLL trả về false)
                    MessageBox.Show("Thu hồi quyền thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ox)
            {
                // Hiển thị lỗi CSDL chi tiết cho Admin
                MessageBox.Show($"Lỗi Oracle: {ox.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi chung khác
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
