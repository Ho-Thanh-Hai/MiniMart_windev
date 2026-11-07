﻿namespace MiniMart_windev.Forms.HeThong
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyVaiTro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCauHinhKetNoi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoatChuongTrinh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLySanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyNhaCungCap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorDanhMuc = new System.Windows.Forms.ToolStripSeparator();
            this.menuNhapKho = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChiTietPhieuNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChiTietHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorNghiepVu = new System.Windows.Forms.ToolStripSeparator();
            this.menuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTonKho = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThemeToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblThoiGian = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnThoatMain = new System.Windows.Forms.Button();
            this.btnThemeMain = new System.Windows.Forms.Button();
            this.btnAboutMain = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhienBan = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnQuickTonKho = new System.Windows.Forms.Button();
            this.btnQuickDoanhThu = new System.Windows.Forms.Button();
            this.btnQuickKhachHang = new System.Windows.Forms.Button();
            this.btnQuickNhapKho = new System.Windows.Forms.Button();
            this.btnQuickSanPham = new System.Windows.Forms.Button();
            this.btnQuickBanHang = new System.Windows.Forms.Button();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblChaoMung = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHeThong,
            this.menuDanhMuc,
            this.menuNghiepVu,
            this.menuBaoCao,
            this.menuTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuHeThong
            // 
            this.menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDoiMatKhau,
            this.menuQuanLyTaiKhoan,
            this.menuQuanLyVaiTro,
            this.toolStripSeparator1,
            this.menuCauHinhKetNoi,
            this.toolStripSeparator2,
            this.menuDangXuat,
            this.menuThoatChuongTrinh});
            this.menuHeThong.Name = "menuHeThong";
            this.menuHeThong.Size = new System.Drawing.Size(77, 21);
            this.menuHeThong.Text = "Hệ Thống";
            // 
            // menuDoiMatKhau
            // 
            this.menuDoiMatKhau.Name = "menuDoiMatKhau";
            this.menuDoiMatKhau.Size = new System.Drawing.Size(216, 22);
            this.menuDoiMatKhau.Text = "Đổi mật khẩu";
            this.menuDoiMatKhau.Click += new System.EventHandler(this.menuDoiMatKhau_Click);
            // 
            // menuQuanLyTaiKhoan
            // 
            this.menuQuanLyTaiKhoan.Name = "menuQuanLyTaiKhoan";
            this.menuQuanLyTaiKhoan.Size = new System.Drawing.Size(216, 22);
            this.menuQuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.menuQuanLyTaiKhoan.Click += new System.EventHandler(this.menuQuanLyTaiKhoan_Click);
            // 
            // menuQuanLyVaiTro
            // 
            this.menuQuanLyVaiTro.Name = "menuQuanLyVaiTro";
            this.menuQuanLyVaiTro.Size = new System.Drawing.Size(216, 22);
            this.menuQuanLyVaiTro.Text = "Quản lý vai trò && Quyền";
            this.menuQuanLyVaiTro.Click += new System.EventHandler(this.menuQuanLyVaiTro_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // menuCauHinhKetNoi
            // 
            this.menuCauHinhKetNoi.Name = "menuCauHinhKetNoi";
            this.menuCauHinhKetNoi.Size = new System.Drawing.Size(216, 22);
            this.menuCauHinhKetNoi.Text = "Cấu hình kết nối SQL";
            this.menuCauHinhKetNoi.Click += new System.EventHandler(this.menuCauHinhKetNoi_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(216, 22);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // menuThoatChuongTrinh
            // 
            this.menuThoatChuongTrinh.Name = "menuThoatChuongTrinh";
            this.menuThoatChuongTrinh.Size = new System.Drawing.Size(216, 22);
            this.menuThoatChuongTrinh.Text = "Thoát chương trình";
            this.menuThoatChuongTrinh.Click += new System.EventHandler(this.menuThoatChuongTrinh_Click);
            // 
            // menuDanhMuc
            // 
            this.menuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQuanLySanPham,
            this.menuQuanLyDanhMuc,
            this.menuQuanLyNhaCungCap,
            this.toolStripSeparatorDanhMuc,
            this.menuNhapKho,
            this.menuChiTietPhieuNhap});
            this.menuDanhMuc.Name = "menuDanhMuc";
            this.menuDanhMuc.Size = new System.Drawing.Size(120, 21);
            this.menuDanhMuc.Text = "Danh Mục && Kho";
            // 
            // menuQuanLySanPham
            // 
            this.menuQuanLySanPham.Name = "menuQuanLySanPham";
            this.menuQuanLySanPham.Size = new System.Drawing.Size(202, 22);
            this.menuQuanLySanPham.Text = "Quản lý sản phẩm";
            this.menuQuanLySanPham.Click += new System.EventHandler(this.menuQuanLySanPham_Click);
            // 
            // menuQuanLyDanhMuc
            // 
            this.menuQuanLyDanhMuc.Name = "menuQuanLyDanhMuc";
            this.menuQuanLyDanhMuc.Size = new System.Drawing.Size(202, 22);
            this.menuQuanLyDanhMuc.Text = "Quản lý danh mục";
            this.menuQuanLyDanhMuc.Click += new System.EventHandler(this.menuQuanLyDanhMuc_Click);
            // 
            // menuQuanLyNhaCungCap
            // 
            this.menuQuanLyNhaCungCap.Name = "menuQuanLyNhaCungCap";
            this.menuQuanLyNhaCungCap.Size = new System.Drawing.Size(202, 22);
            this.menuQuanLyNhaCungCap.Text = "Quản lý nhà cung cấp";
            this.menuQuanLyNhaCungCap.Click += new System.EventHandler(this.menuQuanLyNhaCungCap_Click);
            // 
            // toolStripSeparatorDanhMuc
            // 
            this.toolStripSeparatorDanhMuc.Name = "toolStripSeparatorDanhMuc";
            this.toolStripSeparatorDanhMuc.Size = new System.Drawing.Size(199, 6);
            // 
            // menuNhapKho
            // 
            this.menuNhapKho.Name = "menuNhapKho";
            this.menuNhapKho.Size = new System.Drawing.Size(202, 22);
            this.menuNhapKho.Text = "Lập phiếu nhập kho";
            this.menuNhapKho.Click += new System.EventHandler(this.menuNhapKho_Click);
            // 
            // menuChiTietPhieuNhap
            // 
            this.menuChiTietPhieuNhap.Name = "menuChiTietPhieuNhap";
            this.menuChiTietPhieuNhap.Size = new System.Drawing.Size(202, 22);
            this.menuChiTietPhieuNhap.Text = "Chi tiết phiếu nhập";
            this.menuChiTietPhieuNhap.Click += new System.EventHandler(this.menuChiTietPhieuNhap_Click);
            // 
            // menuNghiepVu
            // 
            this.menuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBanHang,
            this.menuChiTietHoaDon,
            this.menuInHoaDon,
            this.toolStripSeparatorNghiepVu,
            this.menuKhachHang});
            this.menuNghiepVu.Name = "menuNghiepVu";
            this.menuNghiepVu.Size = new System.Drawing.Size(82, 21);
            this.menuNghiepVu.Text = "Nghiệp Vụ";
            // 
            // menuBanHang
            // 
            this.menuBanHang.Name = "menuBanHang";
            this.menuBanHang.Size = new System.Drawing.Size(245, 22);
            this.menuBanHang.Text = "Lập hóa đơn bán hàng (POS)";
            this.menuBanHang.Click += new System.EventHandler(this.menuBanHang_Click);
            // 
            // menuChiTietHoaDon
            // 
            this.menuChiTietHoaDon.Name = "menuChiTietHoaDon";
            this.menuChiTietHoaDon.Size = new System.Drawing.Size(245, 22);
            this.menuChiTietHoaDon.Text = "Tra cứu chi tiết hóa đơn";
            this.menuChiTietHoaDon.Click += new System.EventHandler(this.menuChiTietHoaDon_Click);
            // 
            // menuInHoaDon
            // 
            this.menuInHoaDon.Name = "menuInHoaDon";
            this.menuInHoaDon.Size = new System.Drawing.Size(245, 22);
            this.menuInHoaDon.Text = "Xem && In hóa đơn bán";
            this.menuInHoaDon.Click += new System.EventHandler(this.menuInHoaDon_Click);
            // 
            // toolStripSeparatorNghiepVu
            // 
            this.toolStripSeparatorNghiepVu.Name = "toolStripSeparatorNghiepVu";
            this.toolStripSeparatorNghiepVu.Size = new System.Drawing.Size(242, 6);
            // 
            // menuKhachHang
            // 
            this.menuKhachHang.Name = "menuKhachHang";
            this.menuKhachHang.Size = new System.Drawing.Size(245, 22);
            this.menuKhachHang.Text = "Quản lý khách hàng";
            this.menuKhachHang.Click += new System.EventHandler(this.menuKhachHang_Click);
            // 
            // menuBaoCao
            // 
            this.menuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDoanhThu,
            this.menuTonKho,
            this.menuThongKe});
            this.menuBaoCao.Name = "menuBaoCao";
            this.menuBaoCao.Size = new System.Drawing.Size(69, 21);
            this.menuBaoCao.Text = "Báo Cáo";
            // 
            // menuDoanhThu
            // 
            this.menuDoanhThu.Name = "menuDoanhThu";
            this.menuDoanhThu.Size = new System.Drawing.Size(245, 22);
            this.menuDoanhThu.Text = "Báo cáo doanh thu bán hàng";
            this.menuDoanhThu.Click += new System.EventHandler(this.menuDoanhThu_Click);
            // 
            // menuTonKho
            // 
            this.menuTonKho.Name = "menuTonKho";
            this.menuTonKho.Size = new System.Drawing.Size(245, 22);
            this.menuTonKho.Text = "Báo cáo tồn kho && Cảnh báo";
            this.menuTonKho.Click += new System.EventHandler(this.menuTonKho_Click);
            // 
            // menuThongKe
            // 
            this.menuThongKe.Name = "menuThongKe";
            this.menuThongKe.Size = new System.Drawing.Size(245, 22);
            this.menuThongKe.Text = "Thống kê top SP bán chạy";
            this.menuThongKe.Click += new System.EventHandler(this.menuThongKe_Click);
            // 
            // menuTroGiup
            // 
            this.menuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGioiThieu,
            this.menuThemeToggle});
            this.menuTroGiup.Name = "menuTroGiup";
            this.menuTroGiup.Size = new System.Drawing.Size(70, 21);
            this.menuTroGiup.Text = "Trợ Giúp";
            // 
            // menuGioiThieu
            // 
            this.menuGioiThieu.Name = "menuGioiThieu";
            this.menuGioiThieu.Size = new System.Drawing.Size(249, 22);
            this.menuGioiThieu.Text = "Giới thiệu thành viên nhóm";
            this.menuGioiThieu.Click += new System.EventHandler(this.menuGioiThieu_Click);
            // 
            // menuThemeToggle
            // 
            this.menuThemeToggle.Name = "menuThemeToggle";
            this.menuThemeToggle.Size = new System.Drawing.Size(249, 22);
            this.menuThemeToggle.Text = "Chuyển giao diện Dark / Light";
            this.menuThemeToggle.Click += new System.EventHandler(this.menuThemeToggle_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNguoiDung,
            this.toolStripStatusLabelSpring,
            this.lblThoiGian});
            this.statusStrip1.Location = new System.Drawing.Point(0, 589);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(79, 17);
            this.lblNguoiDung.Text = "Người dùng";
            // 
            // toolStripStatusLabelSpring
            // 
            this.toolStripStatusLabelSpring.Name = "toolStripStatusLabelSpring";
            this.toolStripStatusLabelSpring.Size = new System.Drawing.Size(944, 17);
            this.toolStripStatusLabelSpring.Spring = true;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(62, 17);
            this.lblThoiGian.Text = "Thời gian";
            // 
            // btnThoatMain
            // 
            this.btnThoatMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoatMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnThoatMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoatMain.FlatAppearance.BorderSize = 0;
            this.btnThoatMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoatMain.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThoatMain.ForeColor = System.Drawing.Color.White;
            this.btnThoatMain.Location = new System.Drawing.Point(960, 22);
            this.btnThoatMain.Name = "btnThoatMain";
            this.btnThoatMain.Size = new System.Drawing.Size(120, 36);
            this.btnThoatMain.TabIndex = 4;
            this.btnThoatMain.Text = "Thoát Hệ Thống";
            this.btnThoatMain.UseVisualStyleBackColor = false;
            this.btnThoatMain.Click += new System.EventHandler(this.btnThoatMain_Click);
            // 
            // btnThemeMain
            // 
            this.btnThemeMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemeMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnThemeMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemeMain.FlatAppearance.BorderSize = 0;
            this.btnThemeMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemeMain.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemeMain.ForeColor = System.Drawing.Color.White;
            this.btnThemeMain.Location = new System.Drawing.Point(835, 22);
            this.btnThemeMain.Name = "btnThemeMain";
            this.btnThemeMain.Size = new System.Drawing.Size(115, 36);
            this.btnThemeMain.TabIndex = 3;
            this.btnThemeMain.Text = "Dark Mode";
            this.btnThemeMain.UseVisualStyleBackColor = false;
            this.btnThemeMain.Click += new System.EventHandler(this.btnThemeMain_Click);
            // 
            // btnAboutMain
            // 
            this.btnAboutMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAboutMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAboutMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAboutMain.FlatAppearance.BorderSize = 0;
            this.btnAboutMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutMain.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAboutMain.ForeColor = System.Drawing.Color.White;
            this.btnAboutMain.Location = new System.Drawing.Point(670, 22);
            this.btnAboutMain.Name = "btnAboutMain";
            this.btnAboutMain.Size = new System.Drawing.Size(155, 36);
            this.btnAboutMain.TabIndex = 2;
            this.btnAboutMain.Text = "Nhóm Thực hiện";
            this.btnAboutMain.UseVisualStyleBackColor = false;
            this.btnAboutMain.Click += new System.EventHandler(this.btnAboutMain_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.btnThoatMain);
            this.panelHeader.Controls.Add(this.btnThemeMain);
            this.panelHeader.Controls.Add(this.btnAboutMain);
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Controls.Add(this.lblPhienBan);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 25);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 80);
            this.panelHeader.TabIndex = 2;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 14);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(419, 32);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI";
            // 
            // lblPhienBan
            // 
            this.lblPhienBan.AutoSize = true;
            this.lblPhienBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhienBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblPhienBan.Location = new System.Drawing.Point(24, 54);
            this.lblPhienBan.Name = "lblPhienBan";
            this.lblPhienBan.Size = new System.Drawing.Size(174, 15);
            this.lblPhienBan.TabIndex = 1;
            this.lblPhienBan.Text = "MiniMart Management System ";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panelContent.Controls.Add(this.btnQuickTonKho);
            this.panelContent.Controls.Add(this.btnQuickDoanhThu);
            this.panelContent.Controls.Add(this.btnQuickKhachHang);
            this.panelContent.Controls.Add(this.btnQuickNhapKho);
            this.panelContent.Controls.Add(this.btnQuickSanPham);
            this.panelContent.Controls.Add(this.btnQuickBanHang);
            this.panelContent.Controls.Add(this.lblMoTa);
            this.panelContent.Controls.Add(this.lblChaoMung);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 105);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1100, 484);
            this.panelContent.TabIndex = 3;
            // 
            // btnQuickTonKho
            // 
            this.btnQuickTonKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnQuickTonKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickTonKho.FlatAppearance.BorderSize = 0;
            this.btnQuickTonKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickTonKho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickTonKho.ForeColor = System.Drawing.Color.White;
            this.btnQuickTonKho.Location = new System.Drawing.Point(540, 240);
            this.btnQuickTonKho.Name = "btnQuickTonKho";
            this.btnQuickTonKho.Size = new System.Drawing.Size(220, 90);
            this.btnQuickTonKho.TabIndex = 7;
            this.btnQuickTonKho.Text = "⚠  TỒN KHO && CẢNH BÁO";
            this.btnQuickTonKho.UseVisualStyleBackColor = false;
            this.btnQuickTonKho.Click += new System.EventHandler(this.menuTonKho_Click);
            // 
            // btnQuickDoanhThu
            // 
            this.btnQuickDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnQuickDoanhThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnQuickDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnQuickDoanhThu.Location = new System.Drawing.Point(290, 240);
            this.btnQuickDoanhThu.Name = "btnQuickDoanhThu";
            this.btnQuickDoanhThu.Size = new System.Drawing.Size(220, 90);
            this.btnQuickDoanhThu.TabIndex = 6;
            this.btnQuickDoanhThu.Text = "📊  BÁO CÁO DOANH THU";
            this.btnQuickDoanhThu.UseVisualStyleBackColor = false;
            this.btnQuickDoanhThu.Click += new System.EventHandler(this.menuDoanhThu_Click);
            // 
            // btnQuickKhachHang
            // 
            this.btnQuickKhachHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnQuickKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickKhachHang.FlatAppearance.BorderSize = 0;
            this.btnQuickKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnQuickKhachHang.Location = new System.Drawing.Point(40, 240);
            this.btnQuickKhachHang.Name = "btnQuickKhachHang";
            this.btnQuickKhachHang.Size = new System.Drawing.Size(220, 90);
            this.btnQuickKhachHang.TabIndex = 5;
            this.btnQuickKhachHang.Text = "👥  QUẢN LÝ KHÁCH HÀNG";
            this.btnQuickKhachHang.UseVisualStyleBackColor = false;
            this.btnQuickKhachHang.Click += new System.EventHandler(this.menuKhachHang_Click);
            // 
            // btnQuickNhapKho
            // 
            this.btnQuickNhapKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnQuickNhapKho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickNhapKho.FlatAppearance.BorderSize = 0;
            this.btnQuickNhapKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickNhapKho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickNhapKho.ForeColor = System.Drawing.Color.White;
            this.btnQuickNhapKho.Location = new System.Drawing.Point(540, 120);
            this.btnQuickNhapKho.Name = "btnQuickNhapKho";
            this.btnQuickNhapKho.Size = new System.Drawing.Size(220, 90);
            this.btnQuickNhapKho.TabIndex = 4;
            this.btnQuickNhapKho.Text = "📥  NHẬP KHO HÀNG HÓA";
            this.btnQuickNhapKho.UseVisualStyleBackColor = false;
            this.btnQuickNhapKho.Click += new System.EventHandler(this.menuNhapKho_Click);
            // 
            // btnQuickSanPham
            // 
            this.btnQuickSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnQuickSanPham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickSanPham.FlatAppearance.BorderSize = 0;
            this.btnQuickSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickSanPham.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickSanPham.ForeColor = System.Drawing.Color.White;
            this.btnQuickSanPham.Location = new System.Drawing.Point(290, 120);
            this.btnQuickSanPham.Name = "btnQuickSanPham";
            this.btnQuickSanPham.Size = new System.Drawing.Size(220, 90);
            this.btnQuickSanPham.TabIndex = 3;
            this.btnQuickSanPham.Text = "📦  DANH MỤC SẢN PHẨM";
            this.btnQuickSanPham.UseVisualStyleBackColor = false;
            this.btnQuickSanPham.Click += new System.EventHandler(this.menuQuanLySanPham_Click);
            // 
            // btnQuickBanHang
            // 
            this.btnQuickBanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnQuickBanHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickBanHang.FlatAppearance.BorderSize = 0;
            this.btnQuickBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickBanHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnQuickBanHang.ForeColor = System.Drawing.Color.White;
            this.btnQuickBanHang.Location = new System.Drawing.Point(40, 120);
            this.btnQuickBanHang.Name = "btnQuickBanHang";
            this.btnQuickBanHang.Size = new System.Drawing.Size(220, 90);
            this.btnQuickBanHang.TabIndex = 2;
            this.btnQuickBanHang.Text = "🛒  BÁN HÀNG (POS)";
            this.btnQuickBanHang.UseVisualStyleBackColor = false;
            this.btnQuickBanHang.Click += new System.EventHandler(this.menuBanHang_Click);
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.ForeColor = System.Drawing.Color.Gray;
            this.lblMoTa.Location = new System.Drawing.Point(36, 68);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(469, 19);
            this.lblMoTa.TabIndex = 1;
            this.lblMoTa.Text = "Chọn chức năng thao tác nhanh bên dưới hoặc trên thanh Menu hệ thống.";
            // 
            // lblChaoMung
            // 
            this.lblChaoMung.AutoSize = true;
            this.lblChaoMung.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblChaoMung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblChaoMung.Location = new System.Drawing.Point(35, 30);
            this.lblChaoMung.Name = "lblChaoMung";
            this.lblChaoMung.Size = new System.Drawing.Size(407, 30);
            this.lblChaoMung.TabIndex = 0;
            this.lblChaoMung.Text = "Chào mừng bạn đến với Siêu Thị Mini!";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 611);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniMart — Hệ Thống Quản Lý Siêu Thị Mini";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyVaiTro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuCauHinhKetNoi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem menuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLySanPham;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyNhaCungCap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem menuNhapKho;
        private System.Windows.Forms.ToolStripMenuItem menuChiTietPhieuNhap;
        private System.Windows.Forms.ToolStripMenuItem menuNghiepVu;
        private System.Windows.Forms.ToolStripMenuItem menuBanHang;
        private System.Windows.Forms.ToolStripMenuItem menuChiTietHoaDon;
        private System.Windows.Forms.ToolStripMenuItem menuInHoaDon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorNghiepVu;
        private System.Windows.Forms.ToolStripMenuItem menuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem menuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem menuDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem menuTonKho;
        private System.Windows.Forms.ToolStripMenuItem menuThongKe;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpring;
        private System.Windows.Forms.ToolStripStatusLabel lblThoiGian;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhienBan;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnQuickTonKho;
        private System.Windows.Forms.Button btnQuickDoanhThu;
        private System.Windows.Forms.Button btnQuickKhachHang;
        private System.Windows.Forms.Button btnQuickNhapKho;
        private System.Windows.Forms.Button btnQuickSanPham;
        private System.Windows.Forms.Button btnQuickBanHang;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblChaoMung;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAboutMain;
        private System.Windows.Forms.Button btnThemeMain;
        private System.Windows.Forms.Button btnThoatMain;
        private System.Windows.Forms.ToolStripMenuItem menuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem menuGioiThieu;
        private System.Windows.Forms.ToolStripMenuItem menuThemeToggle;
        private System.Windows.Forms.ToolStripMenuItem menuThoatChuongTrinh;
    }
}