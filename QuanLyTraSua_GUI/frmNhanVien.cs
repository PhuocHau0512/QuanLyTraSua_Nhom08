using QuanLyTraSua.QuanLyTraSua_BLL;
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
    public partial class frmNhanVien : Form
    {
        // Khởi tạo lớp BLL
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu khi form mở lên
            LoadData();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            // Tải lại dữ liệu
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Gọi BLL -> DAO -> SP
                // SP này tự động GIẢI MÃ SĐT (RSA) và Địa Chỉ (Hybrid)
                this.dgvNhanVien.DataSource = nhanVienBLL.GetAllNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu từ Form (dạng plaintext)
                string maNV = this.txtMaNV.Text;
                string tenNV = this.txtTenNV.Text;
                string sdt_plain = this.txtSDT.Text; // SĐT dạng chữ
                string diaChi_plain = this.txtDiaChi.Text; // Địa chỉ dạng chữ
                string ngayVaoLam = this.dtpNgayVaoLam.Text;

                // 2. Gọi lớp BLL (BLL sẽ kiểm tra logic)
                // Gửi cả 2 trường plaintext
                string ketQua = nhanVienBLL.ThemNhanVien(
                    maNV,
                    tenNV,
                    sdt_plain,
                    diaChi_plain,
                    ngayVaoLam
                );

                // 3. Hiển thị kết quả
                MessageBox.Show(ketQua, "Thông báo");

                // 4. Tải lại GridView nếu thành công
                if (ketQua.Contains("thành công"))
                {
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            this.txtMaNV.Text = "";
            this.txtTenNV.Text = "";
            this.txtSDT.Text = "";
            this.txtDiaChi.Text = "";
            this.dtpNgayVaoLam.Value = DateTime.Now;

            txtMaNV.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 1)
            {
                // Hien thi thong tin len cac textbox
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);

                // Khoa chuc nang
                txtMaNV.Enabled = false; // Khong cho sua MaNV (khoa chinh)
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        // --- HAM MOI ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string ketQua = nhanVienBLL.CapNhatNhanVien(
                    txtMaNV.Text,
                    txtTenNV.Text,
                    txtSDT.Text,
                    txtDiaChi.Text,
                    dtpNgayVaoLam.Text
                );

                MessageBox.Show(ketQua, "Thông báo");
                if (ketQua.Contains("thành công"))
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- HAM MOI ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên '" + txtTenNV.Text + "' không?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string ketQua = nhanVienBLL.XoaNhanVien(txtMaNV.Text);
                    MessageBox.Show(ketQua, "Thông báo");
                    if (ketQua.Contains("thành công"))
                    {
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}