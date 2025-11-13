namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    partial class frmXemHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnTaiDuLieu = new System.Windows.Forms.Button();
            this.btnKySo = new System.Windows.Forms.Button();
            this.btnXacThuc = new System.Windows.Forms.Button();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 42);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 62;
            this.dgvHoaDon.RowTemplate.Height = 28;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(776, 314);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // btnTaiDuLieu
            // 
            this.btnTaiDuLieu.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnTaiDuLieu.Location = new System.Drawing.Point(12, 608);
            this.btnTaiDuLieu.Name = "btnTaiDuLieu";
            this.btnTaiDuLieu.Size = new System.Drawing.Size(120, 44);
            this.btnTaiDuLieu.TabIndex = 1;
            this.btnTaiDuLieu.Text = "Tải Dữ Liệu";
            this.btnTaiDuLieu.UseVisualStyleBackColor = true;
            this.btnTaiDuLieu.Click += new System.EventHandler(this.btnTaiDuLieu_Click);
            // 
            // btnKySo
            // 
            this.btnKySo.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnKySo.ForeColor = System.Drawing.Color.Blue;
            this.btnKySo.Location = new System.Drawing.Point(522, 608);
            this.btnKySo.Name = "btnKySo";
            this.btnKySo.Size = new System.Drawing.Size(120, 44);
            this.btnKySo.TabIndex = 2;
            this.btnKySo.Text = "Ký Số";
            this.btnKySo.UseVisualStyleBackColor = true;
            this.btnKySo.Click += new System.EventHandler(this.btnKySo_Click);
            // 
            // btnXacThuc
            // 
            this.btnXacThuc.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnXacThuc.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnXacThuc.Location = new System.Drawing.Point(659, 608);
            this.btnXacThuc.Name = "btnXacThuc";
            this.btnXacThuc.Size = new System.Drawing.Size(120, 44);
            this.btnXacThuc.TabIndex = 3;
            this.btnXacThuc.Text = "Xác Thực";
            this.btnXacThuc.UseVisualStyleBackColor = true;
            this.btnXacThuc.Click += new System.EventHandler(this.btnXacThuc_Click);
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(12, 396);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.RowHeadersWidth = 62;
            this.dgvChiTietHoaDon.RowTemplate.Height = 28;
            this.dgvChiTietHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(776, 197);
            this.dgvChiTietHoaDon.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Danh sách Hóa Đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chi tiết Hóa Đơn";
            // 
            // frmXemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 664);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.btnXacThuc);
            this.Controls.Add(this.btnKySo);
            this.Controls.Add(this.btnTaiDuLieu);
            this.Controls.Add(this.dgvHoaDon);
            this.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.Name = "frmXemHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem Hóa Đơn (Demo VPD & Chữ Ký Số)";
            this.Load += new System.EventHandler(this.frmXemHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnTaiDuLieu;
        private System.Windows.Forms.Button btnKySo;
        private System.Windows.Forms.Button btnXacThuc;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}