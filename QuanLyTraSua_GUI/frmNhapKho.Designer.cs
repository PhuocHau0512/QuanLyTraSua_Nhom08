// Tập tin: QuanLyTraSua_GUI/frmNhapKho.Designer.cs
namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    partial class frmNhapKho
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSoLuongThem;
        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.Label lblTenSP;

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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.numSoLuongThem = new System.Windows.Forms.NumericUpDown();
            this.btnNhapKho = new System.Windows.Forms.Button();
            this.lblTenSP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongThem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(984, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = "NGHIỆP VỤ NHẬP KHO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(13, 75);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSanPham.MultiSelect = false;
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersWidth = 62;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(959, 360);
            this.dgvSanPham.TabIndex = 3;
            this.dgvSanPham.SelectionChanged += new System.EventHandler(this.dgvSanPham_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(40, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số lượng nhập:";
            // 
            // numSoLuongThem
            // 
            this.numSoLuongThem.Font = new System.Drawing.Font("Arial", 12F);
            this.numSoLuongThem.Location = new System.Drawing.Point(210, 497);
            this.numSoLuongThem.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSoLuongThem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuongThem.Name = "numSoLuongThem";
            this.numSoLuongThem.Size = new System.Drawing.Size(180, 35);
            this.numSoLuongThem.TabIndex = 5;
            this.numSoLuongThem.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnNhapKho
            // 
            this.btnNhapKho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnNhapKho.Location = new System.Drawing.Point(680, 485);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(292, 60);
            this.btnNhapKho.TabIndex = 6;
            this.btnNhapKho.Text = "Xác nhận Nhập Kho";
            this.btnNhapKho.UseVisualStyleBackColor = true;
            this.btnNhapKho.Click += new System.EventHandler(this.btnNhapKho_Click);
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenSP.ForeColor = System.Drawing.Color.Blue;
            this.lblTenSP.Location = new System.Drawing.Point(40, 450);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(306, 26);
            this.lblTenSP.TabIndex = 7;
            this.lblTenSP.Text = "Vui lòng chọn sản phẩm...";
            // 
            // frmNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 560);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.btnNhapKho);
            this.Controls.Add(this.numSoLuongThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSanPham);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Kho Sản Phẩm";
            this.Load += new System.EventHandler(this.frmNhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongThem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}