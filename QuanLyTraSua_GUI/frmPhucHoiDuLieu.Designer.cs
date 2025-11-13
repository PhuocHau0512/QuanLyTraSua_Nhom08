namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    partial class frmPhucHoiDuLieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Label label3;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1173, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHỤC HỒI DỮ LIỆU (FLASHBACK)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(45, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã sản phẩm:";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtMaSP.Location = new System.Drawing.Point(210, 103);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(223, 35);
            this.txtMaSP.TabIndex = 2;
            this.txtMaSP.Text = "TS001";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Location = new System.Drawing.Point(450, 95);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(180, 51);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Xem Lịch sử";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(47, 194);
            this.dgvHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersWidth = 62;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(1080, 366);
            this.dgvHistory.TabIndex = 4;
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnPhucHoi.ForeColor = System.Drawing.Color.Red;
            this.btnPhucHoi.Location = new System.Drawing.Point(772, 570);
            this.btnPhucHoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(355, 46);
            this.btnPhucHoi.TabIndex = 5;
            this.btnPhucHoi.Text = "Phục hồi về phiên bản này";
            this.btnPhucHoi.UseVisualStyleBackColor = true;
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(47, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Lịch sử phiên bản (1 ngày qua):";
            // 
            // frmPhucHoiDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 653);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPhucHoi);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmPhucHoiDuLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phục hồi dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}