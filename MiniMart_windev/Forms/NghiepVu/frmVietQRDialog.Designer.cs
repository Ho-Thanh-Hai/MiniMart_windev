namespace MiniMart_windev.Forms.NghiepVu
{
    partial class frmVietQRDialog
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
            this.lblSub = new System.Windows.Forms.Label();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.lblSTK = new System.Windows.Forms.Label();
            this.lblChuTK = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuuAnh = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblSub);
            this.panelTop.Controls.Add(this.lblTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(460, 65);
            this.panelTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(50, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(360, 25);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THANH TOÁN HÓA ĐƠN QUA MÃ VIETQR";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblSub.Location = new System.Drawing.Point(70, 38);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(320, 15);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Quét mã bằng ứng dụng Ngân hàng (MB, VCB, MoMo, Tech...)";
            // 
            // picQR
            // 
            this.picQR.BackColor = System.Drawing.Color.White;
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(90, 80);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(280, 280);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 1;
            this.picQR.TabStop = false;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.lblNoiDung);
            this.panelInfo.Controls.Add(this.lblSoTien);
            this.panelInfo.Controls.Add(this.lblChuTK);
            this.panelInfo.Controls.Add(this.lblSTK);
            this.panelInfo.Controls.Add(this.lblNganHang);
            this.panelInfo.Location = new System.Drawing.Point(30, 375);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(400, 135);
            this.panelInfo.TabIndex = 2;
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNganHang.Location = new System.Drawing.Point(15, 10);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(185, 17);
            this.lblNganHang.TabIndex = 0;
            this.lblNganHang.Text = "Ngân hàng: MBBank (Quân Đội)";
            // 
            // lblSTK
            // 
            this.lblSTK.AutoSize = true;
            this.lblSTK.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSTK.Location = new System.Drawing.Point(15, 33);
            this.lblSTK.Name = "lblSTK";
            this.lblSTK.Size = new System.Drawing.Size(176, 17);
            this.lblSTK.TabIndex = 1;
            this.lblSTK.Text = "Số tài khoản: 0987 654 321";
            // 
            // lblChuTK
            // 
            this.lblChuTK.AutoSize = true;
            this.lblChuTK.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblChuTK.Location = new System.Drawing.Point(15, 56);
            this.lblChuTK.Name = "lblChuTK";
            this.lblChuTK.Size = new System.Drawing.Size(193, 17);
            this.lblChuTK.TabIndex = 2;
            this.lblChuTK.Text = "Chủ TK: SIÊU THỊ MINIMART";
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSoTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblSoTien.Location = new System.Drawing.Point(15, 80);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(170, 20);
            this.lblSoTien.TabIndex = 3;
            this.lblSoTien.Text = "Số tiền: 0 đ";
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblNoiDung.Location = new System.Drawing.Point(15, 105);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(215, 17);
            this.lblNoiDung.TabIndex = 4;
            this.lblNoiDung.Text = "Nội dung: MINIMART THANHTOAN HD";
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(235, 520);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(195, 38);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "✓ Đã nhận thanh toán";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuuAnh
            // 
            this.btnLuuAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.btnLuuAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuAnh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLuuAnh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLuuAnh.Location = new System.Drawing.Point(30, 520);
            this.btnLuuAnh.Name = "btnLuuAnh";
            this.btnLuuAnh.Size = new System.Drawing.Size(195, 38);
            this.btnLuuAnh.TabIndex = 4;
            this.btnLuuAnh.Text = "💾 Lưu ảnh QR";
            this.btnLuuAnh.UseVisualStyleBackColor = false;
            this.btnLuuAnh.Click += new System.EventHandler(this.btnLuuAnh_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblTrangThai.ForeColor = System.Drawing.Color.Gray;
            this.lblTrangThai.Location = new System.Drawing.Point(120, 362);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(220, 15);
            this.lblTrangThai.TabIndex = 5;
            this.lblTrangThai.Text = "Hệ thống tự động đồng bộ số tiền hóa đơn";
            // 
            // frmVietQRDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 575);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.btnLuuAnh);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.picQR);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVietQRDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán VietQR - Siêu thị MiniMart";
            this.Load += new System.EventHandler(this.frmVietQRDialog_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblNganHang;
        private System.Windows.Forms.Label lblSTK;
        private System.Windows.Forms.Label lblChuTK;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuuAnh;
        private System.Windows.Forms.Label lblTrangThai;
    }
}
