// Tập tin: QuanLyTraSua_GUI/frmNhapKho.cs
using QuanLyTraSua.QuanLyTraSua_BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    public partial class frmNhapKho : Form
    {
        private SanPham_BLL sanPhamBLL = new SanPham_BLL();
        private string selectedMaSP = null;

        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Admin (nhóm KHO) sẽ thấy tất cả sản phẩm
                dgvSanPham.DataSource = sanPhamBLL.GetAllSanPham();
                // Tùy chỉnh cột
                if (dgvSanPham.Columns.Contains("SoLuongTon"))
                {
                    dgvSanPham.Columns["SoLuongTon"].HeaderText = "Tồn Kho Hiện Tại";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvSanPham.SelectedRows[0];
                selectedMaSP = row.Cells["MaSP"].Value.ToString();
                string tenSP = row.Cells["TenSP"].Value.ToString();
                lblTenSP.Text = $"Sản phẩm: {tenSP} ({selectedMaSP})";
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaSP))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách.", "Thông báo");
                return;
            }

            int soLuongThem = (int)numSoLuongThem.Value;

            string ketQua = sanPhamBLL.NhapKho(selectedMaSP, soLuongThem);

            MessageBox.Show(ketQua, "Thông báo Nhập kho");

            if (ketQua.Contains("thành công"))
            {
                LoadData(); // Tải lại để thấy số lượng mới
            }
        }
    }
}