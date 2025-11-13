namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    partial class frmDangKy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenTK;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTenTK;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblXacNhanMK;
        private System.Windows.Forms.TextBox txtXacNhanMK;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTenTK = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtTenTK = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblXacNhanMK = new System.Windows.Forms.Label();
            this.txtXacNhanMK = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(651, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenTK
            // 
            this.lblTenTK.AutoSize = true;
            this.lblTenTK.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTenTK.Location = new System.Drawing.Point(60, 90);
            this.lblTenTK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenTK.Name = "lblTenTK";
            this.lblTenTK.Size = new System.Drawing.Size(150, 27);
            this.lblTenTK.TabIndex = 1;
            this.lblTenTK.Text = "Tên tài khoản:";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMatKhau.Location = new System.Drawing.Point(60, 163);
            this.lblMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(110, 27);
            this.lblMatKhau.TabIndex = 2;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtTenTK
            // 
            this.txtTenTK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTK.Location = new System.Drawing.Point(270, 86);
            this.txtTenTK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenTK.Name = "txtTenTK";
            this.txtTenTK.Size = new System.Drawing.Size(328, 35);
            this.txtTenTK.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(270, 158);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(328, 35);
            this.txtMatKhau.TabIndex = 1;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnDangKy.Location = new System.Drawing.Point(120, 375);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(180, 59);
            this.btnDangKy.TabIndex = 4;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnHuy.Location = new System.Drawing.Point(345, 375);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(180, 59);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lblXacNhanMK
            // 
            this.lblXacNhanMK.AutoSize = true;
            this.lblXacNhanMK.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblXacNhanMK.Location = new System.Drawing.Point(60, 236);
            this.lblXacNhanMK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXacNhanMK.Name = "lblXacNhanMK";
            this.lblXacNhanMK.Size = new System.Drawing.Size(205, 27);
            this.lblXacNhanMK.TabIndex = 7;
            this.lblXacNhanMK.Text = "Xác nhận mật khẩu:";
            // 
            // txtXacNhanMK
            // 
            this.txtXacNhanMK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacNhanMK.Location = new System.Drawing.Point(270, 231);
            this.txtXacNhanMK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtXacNhanMK.Name = "txtXacNhanMK";
            this.txtXacNhanMK.PasswordChar = '*';
            this.txtXacNhanMK.Size = new System.Drawing.Size(328, 35);
            this.txtXacNhanMK.TabIndex = 2;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMaNV.Location = new System.Drawing.Point(60, 309);
            this.lblMaNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(150, 27);
            this.lblMaNV.TabIndex = 9;
            this.lblMaNV.Text = "Mã nhân viên:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(270, 304);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(328, 35);
            this.txtMaNV.TabIndex = 3;
            // 
            // frmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 455);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.txtXacNhanMK);
            this.Controls.Add(this.lblXacNhanMK);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenTK);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblTenTK);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký Tài Khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}