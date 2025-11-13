// Tập tin: QuanLyTraSua_GUI/frmSession.Designer.cs
namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    partial class frmSession
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSessions;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnKillSession;

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
            this.dgvSessions = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnKillSession = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(1176, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ PHIÊN ĐĂNG NHẬP (SESSION)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSessions
            // 
            this.dgvSessions.AllowUserToAddRows = false;
            this.dgvSessions.AllowUserToDeleteRows = false;
            this.dgvSessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSessions.Location = new System.Drawing.Point(18, 125);
            this.dgvSessions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSessions.MultiSelect = false;
            this.dgvSessions.Name = "dgvSessions";
            this.dgvSessions.ReadOnly = true;
            this.dgvSessions.RowHeadersWidth = 62;
            this.dgvSessions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSessions.Size = new System.Drawing.Size(1140, 470);
            this.dgvSessions.TabIndex = 2;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.Location = new System.Drawing.Point(978, 65);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(180, 51);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnKillSession
            // 
            this.btnKillSession.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnKillSession.ForeColor = System.Drawing.Color.Red;
            this.btnKillSession.Location = new System.Drawing.Point(898, 605);
            this.btnKillSession.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnKillSession.Name = "btnKillSession";
            this.btnKillSession.Size = new System.Drawing.Size(260, 51);
            this.btnKillSession.TabIndex = 4;
            this.btnKillSession.Text = "Ngắt Phiên Được Chọn";
            this.btnKillSession.UseVisualStyleBackColor = true;
            this.btnKillSession.Click += new System.EventHandler(this.btnKillSession_Click);
            // 
            // frmSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 670);
            this.Controls.Add(this.btnKillSession);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvSessions);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Phiên đăng nhập";
            this.Load += new System.EventHandler(this.frmSession_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}