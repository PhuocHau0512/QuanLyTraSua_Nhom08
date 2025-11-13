using QuanLyTraSua.QuanLyTraSua_BLL; // SỬ DỤNG NAMESPACE BLL ĐỂ TRUY CẬP SANPHAM_BLL
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    // Form Nhập kho cho Admin (nhóm KHO)
    public partial class frmNhapKho : Form
    {
        private SanPham_BLL sanPhamBLL = new SanPham_BLL();
        private string selectedMaSP = null;

        public frmNhapKho()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện Load form
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //  Tải dữ liệu sản phẩm vào DataGridView
        private void LoadData()
        {
            try
            {
                // Lấy tất cả sản phẩm
                dgvSanPham.DataSource = sanPhamBLL.GetAllSanPham();
                // Định dạng cột
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

        //  Xử lý sự kiện khi chọn một dòng trong DataGridView
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

        // Xử lý sự kiện khi nhấn nút Nhập kho
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