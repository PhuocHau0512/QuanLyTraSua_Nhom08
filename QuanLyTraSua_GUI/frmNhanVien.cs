using QuanLyTraSua.QuanLyTraSua_BLL; // SỬ DỤNG NAMESPACE BLL ĐỂ TRUY CẬP NhanVien_BLL
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
    // Form quản lý nhân viên
    public partial class frmNhanVien : Form
    {
        private NhanVien_BLL nhanVienBLL = new NhanVien_BLL();

        public frmNhanVien()
        {
            InitializeComponent();
        }
         
        // Xử lý sự kiện khi form load
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Xử lý sự kiện nút Tải Lại
        private void btnTaiLai_Click(object sender, EventArgs e)
        { 
            LoadData();
        }

        // Hàm tải dữ liệu nhân viên vào DataGridView
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

        // Xử lý sự kiện nút Thêm
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

        // Hàm xóa trắng các ô nhập liệu
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

        // Xử lý sự kiện nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        // Xử lý sự kiện khi chọn dòng trong DataGridView 
        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count == 1)
            {
                // Hiển thị dữ liệu lên các ô nhập liệu
                DataGridViewRow row = dgvNhanVien.SelectedRows[0];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);

                // Cho phép sửa và xóa
                txtMaNV.Enabled = false; // Khóa mã nhân viên
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        // Xử lý sự kiện nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string ketQua = nhanVienBLL.CapNhatNhanVien( // Gửi plaintext
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

        // Xử lý sự kiện nút Xóa
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