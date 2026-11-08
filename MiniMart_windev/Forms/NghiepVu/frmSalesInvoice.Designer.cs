namespace MiniMart_windev.Forms.NghiepVu
{
    partial class frmSalesInvoice
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.cboNguoiDung = new System.Windows.Forms.ComboBox();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.colMaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNguoiLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.btnVietQR = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTieuDe.Location = new System.Drawing.Point(35, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(288, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "LẬP HÓA ĐƠN BÁN HÀNG";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMaHoaDon.Location = new System.Drawing.Point(37, 52);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(83, 17);
            this.lblMaHoaDon.TabIndex = 11;
            this.lblMaHoaDon.Text = "Mã hóa đơn:";
            this.lblMaHoaDon.Click += new System.EventHandler(this.lblMaHoaDon_Click);
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMaHoaDon.Location = new System.Drawing.Point(40, 74);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.ReadOnly = true;
            this.txtMaHoaDon.Size = new System.Drawing.Size(120, 24);
            this.txtMaHoaDon.TabIndex = 12;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.AutoSize = true;
            this.lblNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNguoiDung.Location = new System.Drawing.Point(180, 52);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(69, 17);
            this.lblNguoiDung.TabIndex = 4;
            this.lblNguoiDung.Text = "Người lập:";
            // 
            // cboNguoiDung
            // 
            this.cboNguoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboNguoiDung.FormattingEnabled = true;
            this.cboNguoiDung.Location = new System.Drawing.Point(183, 74);
            this.cboNguoiDung.Name = "cboNguoiDung";
            this.cboNguoiDung.Size = new System.Drawing.Size(150, 25);
            this.cboNguoiDung.TabIndex = 3;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblKhachHang.Location = new System.Drawing.Point(350, 52);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(79, 17);
            this.lblKhachHang.TabIndex = 1;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(353, 74);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(160, 25);
            this.cboKhachHang.TabIndex = 2;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNgayLap.Location = new System.Drawing.Point(37, 108);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(65, 17);
            this.lblNgayLap.TabIndex = 5;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLap.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(40, 128);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(140, 24);
            this.dtpNgayLap.TabIndex = 6;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTimKiem.Location = new System.Drawing.Point(540, 131);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(63, 17);
            this.lblTimKiem.TabIndex = 19;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTimKiem.Location = new System.Drawing.Point(609, 128);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(160, 24);
            this.txtTimKiem.TabIndex = 20;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.Location = new System.Drawing.Point(777, 124);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 30);
            this.btnTimKiem.TabIndex = 26;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeight = 30;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHoaDon,
            this.colTenNguoiLap,
            this.colTenKhachHang,
            this.colNgayLap,
            this.colTongTien,
            this.colGiamGia,
            this.colThanhTien});
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.Location = new System.Drawing.Point(40, 165);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 35;
            this.dgvHoaDon.RowTemplate.Height = 26;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(822, 280);
            this.dgvHoaDon.TabIndex = 21;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick);
            // 
            // colMaHoaDon
            // 
            this.colMaHoaDon.DataPropertyName = "MaHoaDon";
            this.colMaHoaDon.FillWeight = 80F;
            this.colMaHoaDon.HeaderText = "Mã HĐ";
            this.colMaHoaDon.Name = "MaHoaDon";
            this.colMaHoaDon.ReadOnly = true;
            // 
            // colTenNguoiLap
            // 
            this.colTenNguoiLap.DataPropertyName = "TenNguoiLap";
            this.colTenNguoiLap.FillWeight = 110F;
            this.colTenNguoiLap.HeaderText = "Người lập";
            this.colTenNguoiLap.Name = "TenNguoiLap";
            this.colTenNguoiLap.ReadOnly = true;
            // 
            // colTenKhachHang
            // 
            this.colTenKhachHang.DataPropertyName = "TenKhachHang";
            this.colTenKhachHang.FillWeight = 120F;
            this.colTenKhachHang.HeaderText = "Khách hàng";
            this.colTenKhachHang.Name = "TenKhachHang";
            this.colTenKhachHang.ReadOnly = true;
            // 
            // colNgayLap
            // 
            this.colNgayLap.DataPropertyName = "NgayLap";
            this.colNgayLap.FillWeight = 100F;
            this.colNgayLap.HeaderText = "Ngày lập";
            this.colNgayLap.Name = "NgayLap";
            this.colNgayLap.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.DataPropertyName = "TongTien";
            this.colTongTien.FillWeight = 95F;
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.Name = "TongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // colGiamGia
            // 
            this.colGiamGia.DataPropertyName = "GiamGia";
            this.colGiamGia.FillWeight = 85F;
            this.colGiamGia.HeaderText = "Giảm giá";
            this.colGiamGia.Name = "GiamGia";
            this.colGiamGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.DataPropertyName = "ThanhTien";
            this.colThanhTien.FillWeight = 110F;
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "ThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblThanhTien.Location = new System.Drawing.Point(40, 460);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(72, 17);
            this.lblThanhTien.TabIndex = 18;
            this.lblThanhTien.Text = "Thành tiền:";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtThanhTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtThanhTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtThanhTien.Location = new System.Drawing.Point(118, 457);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(120, 24);
            this.txtThanhTien.TabIndex = 17;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTongTien.Location = new System.Drawing.Point(260, 460);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(68, 17);
            this.lblTongTien.TabIndex = 14;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTongTien.Location = new System.Drawing.Point(334, 457);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(120, 24);
            this.txtTongTien.TabIndex = 13;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGiamGia.Location = new System.Drawing.Point(475, 460);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(63, 17);
            this.lblGiamGia.TabIndex = 15;
            this.lblGiamGia.Text = "Giảm giá:";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGiamGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGiamGia.Location = new System.Drawing.Point(544, 457);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(110, 24);
            this.txtGiamGia.TabIndex = 16;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.Location = new System.Drawing.Point(40, 500);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 34);
            this.btnThem.TabIndex = 22;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.Location = new System.Drawing.Point(140, 500);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 34);
            this.btnSua.TabIndex = 23;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.Location = new System.Drawing.Point(240, 500);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(85, 34);
            this.btnXoa.TabIndex = 24;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.Location = new System.Drawing.Point(340, 500);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 34);
            this.btnLamMoi.TabIndex = 25;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnChiTiet.Location = new System.Drawing.Point(440, 500);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(120, 34);
            this.btnChiTiet.TabIndex = 27;
            this.btnChiTiet.Text = "Chi tiết hóa đơn";
            this.btnChiTiet.UseVisualStyleBackColor = true;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // btnVietQR
            // 
            this.btnVietQR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVietQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVietQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnVietQR.Location = new System.Drawing.Point(570, 500);
            this.btnVietQR.Name = "btnVietQR";
            this.btnVietQR.Size = new System.Drawing.Size(155, 34);
            this.btnVietQR.TabIndex = 28;
            this.btnVietQR.Text = "📱 Thanh toán VietQR";
            this.btnVietQR.UseVisualStyleBackColor = true;
            this.btnVietQR.Click += new System.EventHandler(this.btnVietQR_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXuatExcel.Location = new System.Drawing.Point(735, 500);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(125, 34);
            this.btnXuatExcel.TabIndex = 29;
            this.btnXuatExcel.Text = "📊 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // frmSalesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(900, 555);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnVietQR);
            this.Controls.Add(this.btnChiTiet);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.txtThanhTien);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.lblGiamGia);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.lblMaHoaDon);
            this.Controls.Add(this.dtpNgayLap);
            this.Controls.Add(this.lblNgayLap);
            this.Controls.Add(this.lblNguoiDung);
            this.Controls.Add(this.cboNguoiDung);
            this.Controls.Add(this.cboKhachHang);
            this.Controls.Add(this.lblKhachHang);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(850, 520);
            this.Name = "frmSalesInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa đơn bán hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.ComboBox cboNguoiDung;
        private System.Windows.Forms.Label lblNguoiDung;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNguoiLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Button btnVietQR;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}
