// Tập tin: QuanLyTraSua_GUI/frmBanHang.cs
using QuanLyTraSua.QuanLyTraSua_BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    // Form Bán Hàng
    public partial class frmBanHang : Form
    {
        private SanPham_BLL sanPhamBLL = new SanPham_BLL(); // BLL SanPham
        private HoaDon_BLL hoaDonBLL = new HoaDon_BLL(); // BLL HoaDon

        // Gio hang hien tai
        private DataTable dtGioHang = new DataTable();

        public frmBanHang()
        {
            InitializeComponent();
            KhoiTaoGioHang();
        }

        // Khoi tao cau truc gio hang
        private void KhoiTaoGioHang()
        {
            dtGioHang.Columns.Add("MaSP", typeof(string));
            dtGioHang.Columns.Add("TenSP", typeof(string));
            dtGioHang.Columns.Add("DonGia", typeof(double));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("ThanhTien", typeof(double), "DonGia * SoLuong");

            // Gan vao DataGridView
            dgvGioHang.DataSource = dtGioHang;
        }

        // Load danh sach san pham
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            // Tai danh sach san pham (da duoc OLS loc)
            dgvSanPham.DataSource = sanPhamBLL.GetActiveSanPham(Session.Quyen);

            // Dinh dang DataGridView
            if (dgvSanPham.Columns.Contains("SoLuongTon"))
            {
                dgvSanPham.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
                dgvSanPham.Columns["SoLuongTon"].FillWeight = 50;
                dgvSanPham.Columns["TenSP"].FillWeight = 150;
            }

            // Neu user la NhanVien (chi thay TraSua)
            if (Session.Quyen == "NhanVien")
            {
                this.Text += " (Chế độ Bán hàng - OLS: Chỉ thấy Trà Sữa)";
            }
            else // Admin (thay ca Topping)
            {
                this.Text += " (Chế độ Quản lý - OLS: Thấy Trà Sữa & Topping)";
            }
        }

        // Xu ly su kien them san pham vao gio hang
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để thêm.");
                return;
            }

            // Lay thong tin san pham duoc chon
            DataRowView selectedRow = (DataRowView)dgvSanPham.SelectedRows[0].DataBoundItem;
            string maSP = selectedRow["MASP"].ToString(); 
            string tenSP = selectedRow["TENSP"].ToString(); 
            double donGia = Convert.ToDouble(selectedRow["DONGIA"]); 
            int soLuongTon = Convert.ToInt32(selectedRow["SOLUONGTON"]); 
            int soLuong = (int)numSoLuong.Value;

            // KIỂM TRA SƠ BỘ (Kiểm tra cuối cùng là ở hàm ThanhToan)
            if (soLuong > soLuongTon)
            {
                MessageBox.Show($"Số lượng tồn của '{tenSP}' không đủ (chỉ còn {soLuongTon}).", "Lỗi Kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra xem SP da co trong gio hang chua
            DataRow existingCartRow = dtGioHang.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaSP") == maSP);

            if (existingCartRow != null)
            {
                int soLuongMoi = existingCartRow.Field<int>("SoLuong") + soLuong;
                // Kiểm tra lại nếu cộng dồn
                if (soLuongMoi > soLuongTon)
                {
                    MessageBox.Show($"Tổng số lượng trong giỏ ({soLuongMoi}) vượt quá tồn kho ({soLuongTon}).", "Lỗi Kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Cap nhat so luong
                existingCartRow["SoLuong"] = soLuongMoi;
            }
            else
            {
                // Them moi vao gio hang
                DataRow newCartRow = dtGioHang.NewRow();
                newCartRow["MaSP"] = maSP;
                newCartRow["TenSP"] = tenSP;
                newCartRow["DonGia"] = donGia;
                newCartRow["SoLuong"] = soLuong;
                dtGioHang.Rows.Add(newCartRow);
            }

            CapNhatTongTien();
        }

        // Xu ly su kien xoa san pham khoi gio hang
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trong giỏ hàng để xóa.");
                return;
            }

            // Xoa dong duoc chon
            dgvGioHang.Rows.RemoveAt(dgvGioHang.SelectedRows[0].Index);

            CapNhatTongTien();
        }

        // Cap nhat tong tien trong gio hang
        private void CapNhatTongTien()
        {
            // Tinh tong cot "ThanhTien"
            double tongTien = 0;
            if (dtGioHang.Rows.Count > 0)
            {
                tongTien = Convert.ToDouble(dtGioHang.Compute("SUM(ThanhTien)", string.Empty));
            }
            txtTongTien.Text = tongTien.ToString("N0"); // Dinh dang 100,000
        }

        // Xu ly su kien thanh toan
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Tai lai danh sach san pham (de lay SoLuongTon moi nhat)
            // phong truong hop nguoi khac vua mua
            dgvSanPham.DataSource = sanPhamBLL.GetActiveSanPham(Session.Quyen);

            // Goi BLL de thanh toan
            string ketQua = hoaDonBLL.TaoHoaDon(dtGioHang);

            MessageBox.Show(ketQua, "Thông báo Thanh toán");

            if (ketQua.Contains("thành công"))
            {
                // Xoa gio hang
                dtGioHang.Clear();
                CapNhatTongTien();
                // Tai lai DS san pham de thay kho bi tru
                dgvSanPham.DataSource = sanPhamBLL.GetActiveSanPham(Session.Quyen);
            }
            // Neu that bai (het hang), chi hien thi thong bao, khong xoa gio hang
        }
    }
}