namespace MiniMart_windev.Forms.DanhMuc
{
    partial class frmStockReceipt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaPhieuNhap = new System.Windows.Forms.Label();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.lblNguoiLap = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.txtNguoiLap = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.MaPhieuNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNguoiLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(684, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(556, 57);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ PHIẾU NHẬP";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaPhieuNhap
            // 
            this.lblMaPhieuNhap.AutoSize = true;
            this.lblMaPhieuNhap.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.lblMaPhieuNhap.Location = new System.Drawing.Point(80, 120);
            this.lblMaPhieuNhap.Name = "lblMaPhieuNhap";
            this.lblMaPhieuNhap.Size = new System.Drawing.Size(276, 48);
            this.lblMaPhieuNhap.TabIndex = 1;
            this.lblMaPhieuNhap.Text = "Mã phiếu nhập";
            this.lblMaPhieuNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.lblNhaCungCap.Location = new System.Drawing.Point(80, 190);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(253, 48);
            this.lblNhaCungCap.TabIndex = 2;
            this.lblNhaCungCap.Text = "Nhà cung cấp";
            this.lblNhaCungCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.AutoSize = true;
            this.lblNguoiLap.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.lblNguoiLap.Location = new System.Drawing.Point(80, 330);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Size = new System.Drawing.Size(296, 48);
            this.lblNguoiLap.TabIndex = 3;
            this.lblNguoiLap.Text = "Người lập phiếu";
            this.lblNguoiLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.lblNgayNhap.Location = new System.Drawing.Point(80, 260);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(204, 48);
            this.lblNgayNhap.TabIndex = 4;
            this.lblNgayNhap.Text = "Ngày nhập";
            this.lblNgayNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.lblTongTien.Location = new System.Drawing.Point(80, 400);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(184, 48);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Tổng tiền";
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(500, 120);
            this.txtMaPhieuNhap.Multiline = true;
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.ReadOnly = true;
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(400, 55);
            this.txtMaPhieuNhap.TabIndex = 6;
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.txtNguoiLap.Location = new System.Drawing.Point(500, 330);
            this.txtNguoiLap.Multiline = true;
            this.txtNguoiLap.Name = "txtNguoiLap";
            this.txtNguoiLap.ReadOnly = true;
            this.txtNguoiLap.Size = new System.Drawing.Size(400, 55);
            this.txtNguoiLap.TabIndex = 7;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.txtTongTien.Location = new System.Drawing.Point(500, 400);
            this.txtTongTien.Multiline = true;
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(400, 55);
            this.txtTongTien.TabIndex = 8;
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(500, 190);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(400, 56);
            this.cboNhaCungCap.TabIndex = 9;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(500, 260);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(400, 55);
            this.dtpNgayNhap.TabIndex = 10;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(1040, 120);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(200, 65);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Location = new System.Drawing.Point(1040, 210);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(200, 65);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(1260, 120);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(200, 65);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.Location = new System.Drawing.Point(1260, 210);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(200, 65);
            this.btnLamMoi.TabIndex = 14;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Location = new System.Drawing.Point(1040, 300);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(200, 65);
            this.btnTimKiem.TabIndex = 15;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.lblTimKiem.Location = new System.Drawing.Point(80, 470);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(354, 48);
            this.lblTimKiem.TabIndex = 16;
            this.lblTimKiem.Text = "Tìm mã phiếu nhập";
            this.lblTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Times New Roman", 25F);
            this.txtTimKiem.Location = new System.Drawing.Point(500, 470);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(400, 55);
            this.txtTimKiem.TabIndex = 17;
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.AllowUserToAddRows = false;
            this.dgvPhieuNhap.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhieuNhap.ColumnHeadersHeight = 60;
            this.dgvPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieuNhap,
            this.TenNCC,
            this.TenNguoiLap,
            this.NgayNhap,
            this.TongTien});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhieuNhap.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(30, 650);
            this.dgvPhieuNhap.MultiSelect = false;
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.ReadOnly = true;
            this.dgvPhieuNhap.RowHeadersVisible = false;
            this.dgvPhieuNhap.RowHeadersWidth = 51;
            this.dgvPhieuNhap.RowTemplate.Height = 27;
            this.dgvPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(1900, 300);
            this.dgvPhieuNhap.TabIndex = 18;
            this.dgvPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuNhap_CellClick);
            // 
            // MaPhieuNhap
            // 
            this.MaPhieuNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaPhieuNhap.DataPropertyName = "MaPhieuNhap";
            this.MaPhieuNhap.HeaderText = "Mã phiếu nhập";
            this.MaPhieuNhap.MinimumWidth = 6;
            this.MaPhieuNhap.Name = "MaPhieuNhap";
            this.MaPhieuNhap.ReadOnly = true;
            this.MaPhieuNhap.Width = 305;
            // 
            // TenNCC
            // 
            this.TenNCC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenNCC.DataPropertyName = "TenNCC";
            this.TenNCC.HeaderText = "Nhà cung cấp";
            this.TenNCC.MinimumWidth = 6;
            this.TenNCC.Name = "TenNCC";
            this.TenNCC.ReadOnly = true;
            this.TenNCC.Width = 282;
            // 
            // TenNguoiLap
            // 
            this.TenNguoiLap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenNguoiLap.DataPropertyName = "TenNguoiLap";
            this.TenNguoiLap.HeaderText = "Người lập phiếu";
            this.TenNguoiLap.MinimumWidth = 6;
            this.TenNguoiLap.Name = "TenNguoiLap";
            this.TenNguoiLap.ReadOnly = true;
            this.TenNguoiLap.Width = 325;
            // 
            // NgayNhap
            // 
            this.NgayNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NgayNhap.DataPropertyName = "NgayNhap";
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.MinimumWidth = 6;
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.ReadOnly = true;
            this.NgayNhap.Width = 233;
            // 
            // TongTien
            // 
            this.TongTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.MinimumWidth = 6;
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            this.TongTien.Width = 213;
            // 
            // frmStockReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 761);
            this.Controls.Add(this.dgvPhieuNhap);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.cboNhaCungCap);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.txtNguoiLap);
            this.Controls.Add(this.txtMaPhieuNhap);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblNgayNhap);
            this.Controls.Add(this.lblNguoiLap);
            this.Controls.Add(this.lblNhaCungCap);
            this.Controls.Add(this.lblMaPhieuNhap);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "frmStockReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ PHIẾU NHẬP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaPhieuNhap;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.Label lblNguoiLap;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtMaPhieuNhap;
        private System.Windows.Forms.TextBox txtNguoiLap;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNguoiLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
    }
}