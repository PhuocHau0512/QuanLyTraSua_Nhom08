// Tập tin: QuanLyTraSua_GUI/frmSanPham.Designer.cs
namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    partial class frmSanPham
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLoaiSP = new System.Windows.Forms.ComboBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label(); // <-- THEM MOI
            this.numSoLuongTon = new System.Windows.Forms.NumericUpDown(); // <-- THEM MOI
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).BeginInit(); // <-- THEM MOI
            this.SuspendLayout();
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(12, 280); // <-- Sua vi tri
            this.dgvSanPham.MultiSelect = false;
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersWidth = 62;
            this.dgvSanPham.RowTemplate.Height = 28;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(960, 339); // <-- Sua kich thuoc
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.SelectionChanged += new System.EventHandler(this.dgvSanPham_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numSoLuongTon); // <-- THEM MOI
            this.groupBox1.Controls.Add(this.label6); // <-- THEM MOI
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbLoaiSP);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenSP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaSP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 148); // <-- Sua kich thuoc
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Loại SP:";
            // 
            // cmbLoaiSP
            // 
            this.cmbLoaiSP.FormattingEnabled = true;
            this.cmbLoaiSP.Items.AddRange(new object[] {
            "TraSua",
            "Topping"});
            this.cmbLoaiSP.Location = new System.Drawing.Point(584, 80);
            this.cmbLoaiSP.Name = "cmbLoaiSP";
            this.cmbLoaiSP.Size = new System.Drawing.Size(358, 31);
            this.cmbLoaiSP.TabIndex = 6;
            this.cmbLoaiSP.Text = "TraSua";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(108, 80);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(358, 30);
            this.txtDonGia.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Đơn giá:";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(584, 38);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(358, 30);
            this.txtTenSP.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên SP:";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(108, 38);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(358, 30);
            this.txtMaSP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã SP:";
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(399, 222); // <-- Sua vi tri
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 43);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(525, 222); // <-- Sua vi tri
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 43);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.Red;
            this.btnXoa.Location = new System.Drawing.Point(651, 222); // <-- Sua vi tri
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 43);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnLamMoi.Location = new System.Drawing.Point(273, 222); // <-- Sua vi tri
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 43);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(984, 50);
            this.label1.TabIndex = 6;
            this.label1.Text = "QUẢN LÝ SẢN PHẨM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true; // <-- THEM MOI
            this.label6.Location = new System.Drawing.Point(16, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tồn kho:";
            // 
            // numSoLuongTon
            // 
            this.numSoLuongTon.Location = new System.Drawing.Point(108, 116); // <-- THEM MOI
            this.numSoLuongTon.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSoLuongTon.Name = "numSoLuongTon";
            this.numSoLuongTon.Size = new System.Drawing.Size(358, 30);
            this.numSoLuongTon.TabIndex = 9;
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 631);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvSanPham);
            this.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Sản phẩm (Admin - OLS)";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).EndInit(); // <-- THEM MOI
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLoaiSP;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6; // <-- THEM MOI
        private System.Windows.Forms.NumericUpDown numSoLuongTon; // <-- THEM MOI
    }
}