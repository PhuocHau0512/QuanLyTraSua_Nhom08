// Tập tin: QuanLyTraSua_GUI/frmSanPham.cs
using QuanLyTraSua.QuanLyTraSua_BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    public partial class frmSanPham : Form
    {
        private SanPham_BLL sanPhamBLL = new SanPham_BLL();

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Goi BLL -> DAO -> SELECT *
                // OLS se tu dong loc, nhung vi day la Admin (nhan INT)
                // nen se thay tat ca (ca TraSua va Topping)
                dgvSanPham.DataSource = sanPhamBLL.GetAllSanPham();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "0";
            numSoLuongTon.Value = 0; // <-- THEM MOI
            cmbLoaiSP.SelectedIndex = 0; // Mac dinh la TraSua
            txtMaSP.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 1)
            {
                // Hien thi thong tin len cac textbox
                DataGridViewRow row = dgvSanPham.SelectedRows[0];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                cmbLoaiSP.SelectedItem = row.Cells["LoaiSP"].Value.ToString();
                numSoLuongTon.Value = Convert.ToDecimal(row.Cells["SoLuongTon"].Value); // <-- THEM MOI

                // Khoa chuc nang
                txtMaSP.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ketQua = sanPhamBLL.ThemSanPham(
                txtMaSP.Text,
                txtTenSP.Text,
                txtDonGia.Text,
                cmbLoaiSP.SelectedItem.ToString(),
                numSoLuongTon.Value.ToString() // <-- THEM MOI
            );

            MessageBox.Show(ketQua, "Thông báo");
            if (ketQua.Contains("thành công"))
            {
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ketQua = sanPhamBLL.CapNhatSanPham(
                txtMaSP.Text,
                txtTenSP.Text,
                txtDonGia.Text,
                cmbLoaiSP.SelectedItem.ToString(),
                numSoLuongTon.Value.ToString() // <-- THEM MOI
            );

            MessageBox.Show(ketQua, "Thông báo");
            if (ketQua.Contains("thành công"))
            {
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string ketQua = sanPhamBLL.XoaSanPham(txtMaSP.Text);
                MessageBox.Show(ketQua, "Thông báo");
                if (ketQua.Contains("thành công"))
                {
                    LoadData();
                }
            }
        }
    }
}