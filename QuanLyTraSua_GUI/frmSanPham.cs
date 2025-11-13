using QuanLyTraSua.QuanLyTraSua_BLL; // Sử dụng BLL
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    // Form Quản lý Sản phẩm
    public partial class frmSanPham : Form
    {
        private SanPham_BLL sanPhamBLL = new SanPham_BLL();

        public frmSanPham()
        {
            InitializeComponent();
        }

        // Load dữ liệu khi form được tải
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Hàm tải dữ liệu sản phẩm
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

        // Hàm xóa trắng các ô nhập liệu
        private void ClearInputs()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "0";
            numSoLuongTon.Value = 0; 
            cmbLoaiSP.SelectedIndex = 0; // Mac dinh la TraSua
            txtMaSP.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        // Xử lý sự kiện nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }

        // Xử lý sự kiện khi chọn một dòng trong DataGridView
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

                // Dieu chinh trang thai nut
                txtMaSP.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        //  Xử lý sự kiện nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ketQua = sanPhamBLL.ThemSanPham(
                txtMaSP.Text,
                txtTenSP.Text,
                txtDonGia.Text,
                cmbLoaiSP.SelectedItem.ToString(),
                numSoLuongTon.Value.ToString() 
            );

            MessageBox.Show(ketQua, "Thông báo");
            if (ketQua.Contains("thành công"))
            {
                LoadData();
            }
        }

        // Xử lý sự kiện nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            string ketQua = sanPhamBLL.CapNhatSanPham(
                txtMaSP.Text,
                txtTenSP.Text,
                txtDonGia.Text,
                cmbLoaiSP.SelectedItem.ToString(),
                numSoLuongTon.Value.ToString() //
            );

            MessageBox.Show(ketQua, "Thông báo");
            if (ketQua.Contains("thành công"))
            {
                LoadData();
            }
        }

        // Xử lý sự kiện nút Xóa
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