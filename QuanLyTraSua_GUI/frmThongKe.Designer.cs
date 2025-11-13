namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    partial class frmThongKe
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongDoanhThu;

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
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
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
            this.label1.TabIndex = 3;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CalendarFont = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpTuNgay.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(135, 80);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(200, 35);
            this.dtpTuNgay.TabIndex = 4;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CalendarFont = new System.Drawing.Font("Times New Roman", 12F);
            this.dtpDenNgay.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(465, 80);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(200, 35);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(30, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Từ ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3.Location = new System.Drawing.Point(350, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Đến ngày:";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.Location = new System.Drawing.Point(700, 75);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(250, 45);
            this.btnThongKe.TabIndex = 8;
            this.btnThongKe.Text = "Xem Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(30, 140);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersWidth = 62;
            this.dgvThongKe.RowTemplate.Height = 28;
            this.dgvThongKe.Size = new System.Drawing.Size(920, 350);
            this.dgvThongKe.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(520, 510);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tổng Doanh Thu:";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.txtTongDoanhThu.ForeColor = System.Drawing.Color.Red;
            this.txtTongDoanhThu.Location = new System.Drawing.Point(750, 505);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(200, 40);
            this.txtTongDoanhThu.TabIndex = 11;
            this.txtTongDoanhThu.Text = "0 VNĐ";
            this.txtTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.txtTongDoanhThu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống Kê Doanh Thu";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}