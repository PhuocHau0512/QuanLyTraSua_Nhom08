namespace QuanLyTraSua.QuanLyTraSua_GUI
{
    partial class frmPhanQuyen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstChuaCap;
        private System.Windows.Forms.ListBox lstDaCap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGrant;
        private System.Windows.Forms.Button btnRevoke;

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
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstChuaCap = new System.Windows.Forms.ListBox();
            this.lstDaCap = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGrant = new System.Windows.Forms.Button();
            this.btnRevoke = new System.Windows.Forms.Button();
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
            this.label1.Size = new System.Drawing.Size(854, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHÂN QUYỀN CSDL (ROLE)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(285, 103);
            this.cmbUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(358, 35);
            this.cmbUsers.TabIndex = 1;
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label2.Location = new System.Drawing.Point(150, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chọn User:";
            // 
            // lstChuaCap
            // 
            this.lstChuaCap.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lstChuaCap.FormattingEnabled = true;
            this.lstChuaCap.ItemHeight = 22;
            this.lstChuaCap.Location = new System.Drawing.Point(45, 219);
            this.lstChuaCap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstChuaCap.Name = "lstChuaCap";
            this.lstChuaCap.Size = new System.Drawing.Size(298, 312);
            this.lstChuaCap.TabIndex = 3;
            // 
            // lstDaCap
            // 
            this.lstDaCap.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lstDaCap.FormattingEnabled = true;
            this.lstDaCap.ItemHeight = 22;
            this.lstDaCap.Location = new System.Drawing.Point(510, 219);
            this.lstDaCap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstDaCap.Name = "lstDaCap";
            this.lstDaCap.Size = new System.Drawing.Size(298, 312);
            this.lstDaCap.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(45, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Role CHƯA CẤP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(510, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Role ĐÃ CẤP";
            // 
            // btnGrant
            // 
            this.btnGrant.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnGrant.Location = new System.Drawing.Point(375, 307);
            this.btnGrant.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGrant.Name = "btnGrant";
            this.btnGrant.Size = new System.Drawing.Size(105, 59);
            this.btnGrant.TabIndex = 7;
            this.btnGrant.Text = ">>";
            this.btnGrant.UseVisualStyleBackColor = true;
            this.btnGrant.Click += new System.EventHandler(this.btnGrant_Click);
            // 
            // btnRevoke
            // 
            this.btnRevoke.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnRevoke.Location = new System.Drawing.Point(375, 409);
            this.btnRevoke.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRevoke.Name = "btnRevoke";
            this.btnRevoke.Size = new System.Drawing.Size(105, 59);
            this.btnRevoke.TabIndex = 8;
            this.btnRevoke.Text = "<<";
            this.btnRevoke.UseVisualStyleBackColor = true;
            this.btnRevoke.Click += new System.EventHandler(this.btnRevoke_Click);
            // 
            // frmPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 600);
            this.Controls.Add(this.btnRevoke);
            this.Controls.Add(this.btnGrant);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstDaCap);
            this.Controls.Add(this.lstChuaCap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmPhanQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Phân Quyền CSDL";
            this.Load += new System.EventHandler(this.frmPhanQuyen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}