namespace QuanLyTraSua
{
    partial class frmDangNhap
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
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangKy;

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
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
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
            this.lblTitle.Size = new System.Drawing.Size(562, 69);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PHẦN MỀM QUẢN LÝ TRÀ SỮA";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenTK
            // 
            this.lblTenTK.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblTenTK.Location = new System.Drawing.Point(22, 91);
            this.lblTenTK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenTK.Name = "lblTenTK";
            this.lblTenTK.Size = new System.Drawing.Size(150, 27);
            this.lblTenTK.TabIndex = 1;
            this.lblTenTK.Text = "Tên tài khoản:";
            this.lblTenTK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblMatKhau.Location = new System.Drawing.Point(22, 164);
            this.lblMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(141, 27);
            this.lblMatKhau.TabIndex = 2;
            this.lblMatKhau.Text = "Mật khẩu:";
            this.lblMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenTK
            // 
            this.txtTenTK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTK.Location = new System.Drawing.Point(171, 91);
            this.txtTenTK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenTK.Name = "txtTenTK";
            this.txtTenTK.Size = new System.Drawing.Size(365, 35);
            this.txtTenTK.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(171, 164);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(365, 35);
            this.txtMatKhau.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.Location = new System.Drawing.Point(24, 235);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(180, 59);
            this.btnDangNhap.TabIndex = 2;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnThoat.Location = new System.Drawing.Point(416, 235);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 59);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnDangKy.Location = new System.Drawing.Point(228, 235);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(165, 59);
            this.btnDangKy.TabIndex = 3;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 309);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenTK);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblTenTK);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập Hệ Thống";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

