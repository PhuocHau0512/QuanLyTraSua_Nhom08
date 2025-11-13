namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    partial class frmGiamSat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Button btnLamMoi;
        protected override void Dispose(bool disposing) { /* ... */ }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(1176, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "NHẬT KÝ GIÁM SÁT (FGA) - THAY ĐỔI GIÁ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(18, 108);
            this.dgvLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersWidth = 62;
            this.dgvLogs.Size = new System.Drawing.Size(1140, 538);
            this.dgvLogs.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.Location = new System.Drawing.Point(978, 47);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(180, 51);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmGiamSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 663);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmGiamSat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhật ký Giám sát FGA";
            this.Load += new System.EventHandler(this.frmGiamSat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

    }
}