namespace MiniMart_windev.Forms.HeThong
{
    partial class frmConnectionConfig
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.grpXacThuc = new System.Windows.Forms.GroupBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoSqlAuth = new System.Windows.Forms.RadioButton();
            this.rdoWindowsAuth = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.btnLayDanhSachDB = new System.Windows.Forms.Button();
            this.btnKiemTraKetNoi = new System.Windows.Forms.Button();
            this.btnLuuCauHinh = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.grpXacThuc.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(530, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(100, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(325, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "CẤU HÌNH KẾT NỐI DATABASE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server name:";
            // 
            // txtServer
            // 
            this.txtServer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.Location = new System.Drawing.Point(135, 82);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(350, 25);
            this.txtServer.TabIndex = 2;
            this.txtServer.Text = ".\\MSSQLSERVER02";
            // 
            // grpXacThuc
            // 
            this.grpXacThuc.Controls.Add(this.txtMatKhau);
            this.grpXacThuc.Controls.Add(this.label3);
            this.grpXacThuc.Controls.Add(this.txtTaiKhoan);
            this.grpXacThuc.Controls.Add(this.label2);
            this.grpXacThuc.Controls.Add(this.rdoSqlAuth);
            this.grpXacThuc.Controls.Add(this.rdoWindowsAuth);
            this.grpXacThuc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpXacThuc.Location = new System.Drawing.Point(30, 125);
            this.grpXacThuc.Name = "grpXacThuc";
            this.grpXacThuc.Size = new System.Drawing.Size(465, 140);
            this.grpXacThuc.TabIndex = 3;
            this.grpXacThuc.TabStop = false;
            this.grpXacThuc.Text = "Xác thực (Authentication)";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Enabled = false;
            this.txtMatKhau.Location = new System.Drawing.Point(145, 98);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(295, 25);
            this.txtMatKhau.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu:";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Enabled = false;
            this.txtTaiKhoan.Location = new System.Drawing.Point(145, 63);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(295, 25);
            this.txtTaiKhoan.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tài khoản:";
            // 
            // rdoSqlAuth
            // 
            this.rdoSqlAuth.AutoSize = true;
            this.rdoSqlAuth.Location = new System.Drawing.Point(240, 30);
            this.rdoSqlAuth.Name = "rdoSqlAuth";
            this.rdoSqlAuth.Size = new System.Drawing.Size(176, 21);
            this.rdoSqlAuth.TabIndex = 1;
            this.rdoSqlAuth.Text = "SQL Server Authentication";
            this.rdoSqlAuth.UseVisualStyleBackColor = true;
            this.rdoSqlAuth.CheckedChanged += new System.EventHandler(this.rdoWindowsAuth_CheckedChanged);
            // 
            // rdoWindowsAuth
            // 
            this.rdoWindowsAuth.AutoSize = true;
            this.rdoWindowsAuth.Checked = true;
            this.rdoWindowsAuth.Location = new System.Drawing.Point(30, 30);
            this.rdoWindowsAuth.Name = "rdoWindowsAuth";
            this.rdoWindowsAuth.Size = new System.Drawing.Size(163, 21);
            this.rdoWindowsAuth.TabIndex = 0;
            this.rdoWindowsAuth.TabStop = true;
            this.rdoWindowsAuth.Text = "Windows Authentication";
            this.rdoWindowsAuth.UseVisualStyleBackColor = true;
            this.rdoWindowsAuth.CheckedChanged += new System.EventHandler(this.rdoWindowsAuth_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Database:";
            // 
            // cboDatabase
            // 
            this.cboDatabase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(135, 282);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(265, 25);
            this.cboDatabase.TabIndex = 5;
            this.cboDatabase.Text = "QuanLySieuThiMini";
            // 
            // btnLayDanhSachDB
            // 
            this.btnLayDanhSachDB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLayDanhSachDB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLayDanhSachDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLayDanhSachDB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayDanhSachDB.Location = new System.Drawing.Point(410, 280);
            this.btnLayDanhSachDB.Name = "btnLayDanhSachDB";
            this.btnLayDanhSachDB.Size = new System.Drawing.Size(85, 29);
            this.btnLayDanhSachDB.TabIndex = 6;
            this.btnLayDanhSachDB.Text = "🔄 Tải DB";
            this.btnLayDanhSachDB.UseVisualStyleBackColor = false;
            this.btnLayDanhSachDB.Click += new System.EventHandler(this.btnLayDanhSachDB_Click);
            // 
            // btnKiemTraKetNoi
            // 
            this.btnKiemTraKetNoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnKiemTraKetNoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKiemTraKetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTraKetNoi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemTraKetNoi.ForeColor = System.Drawing.Color.White;
            this.btnKiemTraKetNoi.Location = new System.Drawing.Point(30, 340);
            this.btnKiemTraKetNoi.Name = "btnKiemTraKetNoi";
            this.btnKiemTraKetNoi.Size = new System.Drawing.Size(155, 38);
            this.btnKiemTraKetNoi.TabIndex = 7;
            this.btnKiemTraKetNoi.Text = "🔌 Thử kết nối";
            this.btnKiemTraKetNoi.UseVisualStyleBackColor = false;
            this.btnKiemTraKetNoi.Click += new System.EventHandler(this.btnKiemTraKetNoi_Click);
            // 
            // btnLuuCauHinh
            // 
            this.btnLuuCauHinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLuuCauHinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuCauHinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuCauHinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuCauHinh.ForeColor = System.Drawing.Color.White;
            this.btnLuuCauHinh.Location = new System.Drawing.Point(220, 340);
            this.btnLuuCauHinh.Name = "btnLuuCauHinh";
            this.btnLuuCauHinh.Size = new System.Drawing.Size(160, 38);
            this.btnLuuCauHinh.TabIndex = 8;
            this.btnLuuCauHinh.Text = "💾 Lưu cấu hình";
            this.btnLuuCauHinh.UseVisualStyleBackColor = false;
            this.btnLuuCauHinh.Click += new System.EventHandler(this.btnLuuCauHinh_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(400, 340);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(95, 38);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Đóng";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmConnectionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(530, 405);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuuCauHinh);
            this.Controls.Add(this.btnKiemTraKetNoi);
            this.Controls.Add(this.btnLayDanhSachDB);
            this.Controls.Add(this.cboDatabase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpXacThuc);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnectionConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu hình kết nối hệ thống";
            this.Load += new System.EventHandler(this.frmConnectionConfig_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpXacThuc.ResumeLayout(false);
            this.grpXacThuc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.GroupBox grpXacThuc;
        private System.Windows.Forms.RadioButton rdoWindowsAuth;
        private System.Windows.Forms.RadioButton rdoSqlAuth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.Button btnLayDanhSachDB;
        private System.Windows.Forms.Button btnKiemTraKetNoi;
        private System.Windows.Forms.Button btnLuuCauHinh;
        private System.Windows.Forms.Button btnThoat;
    }
}
