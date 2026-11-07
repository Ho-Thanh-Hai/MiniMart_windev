-- =========================================================================================
-- ĐỒ ÁN LẬP TRÌNH WINDOWS: HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINIMART)
-- CƠ SỞ DỮ LIỆU: QuanLySieuThiMini
-- CÔNG NGHỆ: Microsoft SQL Server, C# .NET Framework, LINQ to SQL
-- =========================================================================================

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLySieuThiMini')
BEGIN
    CREATE DATABASE QuanLySieuThiMini;
END
GO

USE QuanLySieuThiMini;
GO

-- 1. BẢNG VAI TRÒ
IF OBJECT_ID('dbo.VaiTro', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.VaiTro (
        MaVaiTro INT IDENTITY(1,1) PRIMARY KEY,
        TenVaiTro NVARCHAR(50) NOT NULL
    );
END
GO

-- 2. BẢNG CHỨC NĂNG
IF OBJECT_ID('dbo.ChucNang', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ChucNang (
        MaChucNang VARCHAR(50) PRIMARY KEY,
        TenChucNang NVARCHAR(100) NOT NULL,
        MoTa NVARCHAR(255) NULL
    );
END
GO

-- 3. BẢNG PHÂN QUYỀN
IF OBJECT_ID('dbo.PhanQuyen', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.PhanQuyen (
        MaVaiTro INT NOT NULL,
        MaChucNang VARCHAR(50) NOT NULL,
        DuocPhep BIT DEFAULT 1,
        CONSTRAINT PK_PhanQuyen PRIMARY KEY (MaVaiTro, MaChucNang),
        CONSTRAINT FK_PhanQuyen_VaiTro FOREIGN KEY (MaVaiTro) REFERENCES dbo.VaiTro(MaVaiTro) ON DELETE CASCADE,
        CONSTRAINT FK_PhanQuyen_ChucNang FOREIGN KEY (MaChucNang) REFERENCES dbo.ChucNang(MaChucNang) ON DELETE CASCADE
    );
END
GO

-- 4. BẢNG NGƯỜI DÙNG
IF OBJECT_ID('dbo.NguoiDung', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.NguoiDung (
        MaNguoiDung INT IDENTITY(1,1) PRIMARY KEY,
        TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
        MatKhauHash VARCHAR(64) NOT NULL, -- SHA-256 Hex
        HoTen NVARCHAR(100) NOT NULL,
        MaVaiTro INT NOT NULL,
        TrangThai BIT DEFAULT 1,
        CONSTRAINT FK_NguoiDung_VaiTro FOREIGN KEY (MaVaiTro) REFERENCES dbo.VaiTro(MaVaiTro)
    );
END
GO

-- 5. BẢNG DANH MỤC SẢN PHẨM
IF OBJECT_ID('dbo.DanhMuc', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.DanhMuc (
        MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
        TenDanhMuc NVARCHAR(100) NOT NULL,
        MoTa NVARCHAR(255) NULL
    );
END
GO

-- 6. BẢNG NHÀ CUNG CẤP
IF OBJECT_ID('dbo.NhaCungCap', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.NhaCungCap (
        MaNCC INT IDENTITY(1,1) PRIMARY KEY,
        TenNCC NVARCHAR(150) NOT NULL,
        DiaChi NVARCHAR(255) NULL,
        SoDienThoai VARCHAR(15) NULL,
        Email VARCHAR(100) NULL
    );
END
GO

-- 7. BẢNG SẢN PHẨM
IF OBJECT_ID('dbo.SanPham', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.SanPham (
        MaSanPham VARCHAR(20) PRIMARY KEY,
        TenSanPham NVARCHAR(150) NOT NULL,
        MaDanhMuc INT NOT NULL,
        MaNCC INT NOT NULL,
        DonGia DECIMAL(18,2) NOT NULL,
        SoLuongTon INT DEFAULT 0,
        CONSTRAINT FK_SanPham_DanhMuc FOREIGN KEY (MaDanhMuc) REFERENCES dbo.DanhMuc(MaDanhMuc),
        CONSTRAINT FK_SanPham_NCC FOREIGN KEY (MaNCC) REFERENCES dbo.NhaCungCap(MaNCC)
    );
END
GO

-- 8. BẢNG KHÁCH HÀNG
IF OBJECT_ID('dbo.KhachHang', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.KhachHang (
        MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
        HoTen NVARCHAR(100) NOT NULL,
        SoDienThoai VARCHAR(15) NULL,
        Email VARCHAR(100) NULL,
        DiaChi NVARCHAR(255) NULL
    );
END
GO

-- 9. BẢNG PHIẾU NHẬP KHO
IF OBJECT_ID('dbo.PhieuNhap', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.PhieuNhap (
        MaPhieuNhap INT IDENTITY(1,1) PRIMARY KEY,
        MaNCC INT NOT NULL,
        MaNguoiDung INT NOT NULL,
        NgayNhap DATETIME DEFAULT GETDATE(),
        TongTien DECIMAL(18,2) DEFAULT 0,
        CONSTRAINT FK_PhieuNhap_NCC FOREIGN KEY (MaNCC) REFERENCES dbo.NhaCungCap(MaNCC),
        CONSTRAINT FK_PhieuNhap_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung)
    );
END
GO

-- 10. BẢNG CHI TIẾT PHIẾU NHẬP
IF OBJECT_ID('dbo.ChiTietPhieuNhap', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ChiTietPhieuNhap (
        MaPhieuNhap INT NOT NULL,
        MaSanPham VARCHAR(20) NOT NULL,
        SoLuong INT NOT NULL,
        DongiaNhap DECIMAL(18,2) NOT NULL,
        ThanhTien DECIMAL(18,2) NOT NULL,
        CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaPhieuNhap, MaSanPham),
        CONSTRAINT FK_CTPN_PhieuNhap FOREIGN KEY (MaPhieuNhap) REFERENCES dbo.PhieuNhap(MaPhieuNhap) ON DELETE CASCADE,
        CONSTRAINT FK_CTPN_SanPham FOREIGN KEY (MaSanPham) REFERENCES dbo.SanPham(MaSanPham)
    );
END
GO

-- 11. BẢNG HÓA ĐƠN BÁN HÀNG
IF OBJECT_ID('dbo.HoaDon', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.HoaDon (
        MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
        MaKhachHang INT NULL,
        MaNguoiDung INT NOT NULL,
        NgayLap DATETIME DEFAULT GETDATE(),
        TongTien DECIMAL(18,2) DEFAULT 0,
        GiamGia DECIMAL(18,2) DEFAULT 0,
        ThanhTien DECIMAL(18,2) DEFAULT 0,
        CONSTRAINT FK_HoaDon_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES dbo.KhachHang(MaKhachHang),
        CONSTRAINT FK_HoaDon_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES dbo.NguoiDung(MaNguoiDung)
    );
END
GO

-- 12. BẢNG CHI TIẾT HÓA ĐƠN
IF OBJECT_ID('dbo.ChiTietHoaDon', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ChiTietHoaDon (
        MaHoaDon INT NOT NULL,
        MaSanPham VARCHAR(20) NOT NULL,
        SoLuong INT NOT NULL,
        DonGia DECIMAL(18,2) NOT NULL,
        ThanhTien DECIMAL(18,2) NOT NULL,
        CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHoaDon, MaSanPham),
        CONSTRAINT FK_CTHD_HoaDon FOREIGN KEY (MaHoaDon) REFERENCES dbo.HoaDon(MaHoaDon) ON DELETE CASCADE,
        CONSTRAINT FK_CTHD_SanPham FOREIGN KEY (MaSanPham) REFERENCES dbo.SanPham(MaSanPham)
    );
END
GO

-- =========================================================================================
-- DỮ LIỆU KHỞI TẠO MẪU (SEED DATA)
-- =========================================================================================

-- 1. VAI TRÒ
IF NOT EXISTS (SELECT 1 FROM dbo.VaiTro WHERE MaVaiTro = 1)
BEGIN
    SET IDENTITY_INSERT dbo.VaiTro ON;
    INSERT INTO dbo.VaiTro (MaVaiTro, TenVaiTro) VALUES 
    (1, N'Quản trị viên'),
    (2, N'Thu ngân'),
    (3, N'Thủ kho');
    SET IDENTITY_INSERT dbo.VaiTro OFF;
END
GO

-- 2. CHỨC NĂNG HỆ THỐNG
IF NOT EXISTS (SELECT 1 FROM dbo.ChucNang)
BEGIN
    INSERT INTO dbo.ChucNang (MaChucNang, TenChucNang, MoTa) VALUES
    ('SYS_USER', N'Quản lý tài khoản', N'Thêm, sửa, xóa người dùng'),
    ('SYS_ROLE', N'Quản lý phân quyền', N'Phân quyền chức năng theo vai trò'),
    ('SYS_CONFIG', N'Cấu hình hệ thống', N'Cấu hình kết nối cơ sở dữ liệu'),
    ('CAT_PRODUCT', N'Quản lý sản phẩm', N'Danh mục hàng hóa siêu thị'),
    ('CAT_CATEGORY', N'Quản lý danh mục', N'Phân loại sản phẩm'),
    ('CAT_SUPPLIER', N'Quản lý nhà cung cấp', N'Đối tác cung cấp nguồn hàng'),
    ('POS_SALES', N'Bán hàng & Hóa đơn', N'Lập hóa đơn POS và in hóa đơn'),
    ('POS_CUSTOMER', N'Quản lý khách hàng', N'Thông tin khách hàng thành viên'),
    ('WH_RECEIPT', N'Quản lý nhập kho', N'Tạo và duyệt phiếu nhập hàng'),
    ('RPT_REVENUE', N'Báo cáo doanh thu', N'Thống kê doanh thu theo thời gian'),
    ('RPT_INVENTORY', N'Báo cáo tồn kho', N'Cảnh báo hàng sắp hết và tồn kho');
END
GO

-- 3. PHÂN QUYỀN MẶC ĐỊNH CHO CÁC VAI TRÒ
IF NOT EXISTS (SELECT 1 FROM dbo.PhanQuyen)
BEGIN
    -- Quản trị viên (Toàn quyền)
    INSERT INTO dbo.PhanQuyen (MaVaiTro, MaChucNang, DuocPhep)
    SELECT 1, MaChucNang, 1 FROM dbo.ChucNang;

    -- Thu ngân: Bán hàng, Khách hàng, Báo cáo hóa đơn
    INSERT INTO dbo.PhanQuyen (MaVaiTro, MaChucNang, DuocPhep) VALUES
    (2, 'POS_SALES', 1),
    (2, 'POS_CUSTOMER', 1),
    (2, 'CAT_PRODUCT', 0),
    (2, 'WH_RECEIPT', 0),
    (2, 'SYS_USER', 0),
    (2, 'SYS_ROLE', 0);

    -- Thủ kho: Sản phẩm, Danh mục, Nhà cung cấp, Nhập kho, Báo cáo tồn kho
    INSERT INTO dbo.PhanQuyen (MaVaiTro, MaChucNang, DuocPhep) VALUES
    (3, 'CAT_PRODUCT', 1),
    (3, 'CAT_CATEGORY', 1),
    (3, 'CAT_SUPPLIER', 1),
    (3, 'WH_RECEIPT', 1),
    (3, 'RPT_INVENTORY', 1),
    (3, 'POS_SALES', 0),
    (3, 'SYS_USER', 0);
END
GO

-- 4. NGƯỜI DÙNG MẪU (Mật khẩu mặc định: 123456 -> băm SHA-256)
-- Hash: 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92
IF NOT EXISTS (SELECT 1 FROM dbo.NguoiDung WHERE TenDangNhap = 'admin')
BEGIN
    SET IDENTITY_INSERT dbo.NguoiDung ON;
    INSERT INTO dbo.NguoiDung (MaNguoiDung, TenDangNhap, MatKhauHash, HoTen, MaVaiTro, TrangThai) VALUES
    (1, 'admin', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Quản Trị Viên', 1, 1),
    (2, 'thungan01', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Nguyễn Thu Ngân', 2, 1),
    (3, 'thukho01', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Trần Thủ Kho', 3, 1);
    SET IDENTITY_INSERT dbo.NguoiDung OFF;
END
GO

-- 5. DANH MỤC MẪU
IF NOT EXISTS (SELECT 1 FROM dbo.DanhMuc)
BEGIN
    SET IDENTITY_INSERT dbo.DanhMuc ON;
    INSERT INTO dbo.DanhMuc (MaDanhMuc, TenDanhMuc, MoTa) VALUES
    (1, N'Nước giải khát', N'Các loại đồ uống đóng chai, lon'),
    (2, N'Bánh kẹo & Snack', N'Bánh quy, kẹo, khoai tây chiên'),
    (3, N'Sữa & Chế phẩm sữa', N'Sữa tươi, sữa chua, bơ phô mai'),
    (4, N'Gia vị thực phẩm', N'Dầu ăn, nước mắm, bột nêm, đường muối'),
    (5, N'Đồ dùng gia đình', N'Nước rửa chén, khăn giấy, xà phòng');
    SET IDENTITY_INSERT dbo.DanhMuc OFF;
END
GO

-- 6. NHÀ CUNG CẤP MẪU
IF NOT EXISTS (SELECT 1 FROM dbo.NhaCungCap)
BEGIN
    SET IDENTITY_INSERT dbo.NhaCungCap ON;
    INSERT INTO dbo.NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai, Email) VALUES
    (1, N'Công ty Nước Giải Khát Coca-Cola VN', N'Quận Thủ Đức, TP.HCM', '02838961234', 'contact@coca-cola.vn'),
    (2, N'Công ty Cổ phần Thực phẩm Kinh Đô', N'Quận 1, TP.HCM', '02838271122', 'info@mondelezkinhdo.com'),
    (3, N'Công ty Cổ phần Sữa Việt Nam (Vinamilk)', N'Quận 7, TP.HCM', '02854155555', 'vinamilk@vinamilk.com.vn'),
    (4, N'Công ty Unilever Việt Nam', N'KCN Tây Bắc Củ Chi, TP.HCM', '02838236655', 'care@unilever.com');
    SET IDENTITY_INSERT dbo.NhaCungCap OFF;
END
GO

-- 7. SẢN PHẨM MẪU
IF NOT EXISTS (SELECT 1 FROM dbo.SanPham)
BEGIN
    INSERT INTO dbo.SanPham (MaSanPham, TenSanPham, MaDanhMuc, MaNCC, DonGia, SoLuongTon) VALUES
    ('SP001', N'Coca Cola Lon 320ml', 1, 1, 10000, 150),
    ('SP002', N'Nước Cam ép Teppy 327ml', 1, 1, 12000, 80),
    ('SP003', N'Bánh Chocopie Hộp 12 Cái', 2, 2, 55000, 45),
    ('SP004', N'Snack Khoai Tây Lays 95g', 2, 2, 22000, 60),
    ('SP005', N'Sữa Tươi Tiệt Trùng Vinamilk 1L', 3, 3, 38000, 90),
    ('SP006', N'Sữa Chua Vinamilk Có Đường Lốc 4', 3, 3, 28000, 110),
    ('SP007', N'Hạt Nêm Knorr Nấm Hương 400g', 4, 4, 35000, 75),
    ('SP008', N'Nước Rửa Chén Sunlight Chanh 750g', 5, 4, 29000, 65);
END
GO

-- 8. KHÁCH HÀNG MẪU
IF NOT EXISTS (SELECT 1 FROM dbo.KhachHang)
BEGIN
    SET IDENTITY_INSERT dbo.KhachHang ON;
    INSERT INTO dbo.KhachHang (MaKhachHang, HoTen, SoDienThoai, Email, DiaChi) VALUES
    (1, N'Khách vãng lai', '0000000000', 'khachvanglai@minimart.vn', N'Tại quầy'),
    (2, N'Nguyễn Văn An', '0901234567', 'an.nguyen@gmail.com', N'123 Nguyễn Trãi, Q.5, TP.HCM'),
    (3, N'Trần Thị Bích', '0912345678', 'bich.tran@gmail.com', N'456 Lê Lợi, Q.1, TP.HCM'),
    (4, N'Lê Hoàng Long', '0987654321', 'long.le@gmail.com', N'789 Cách Mạng Tháng 8, Q.3, TP.HCM');
    SET IDENTITY_INSERT dbo.KhachHang OFF;
END
GO

-- 9. HÓA ĐƠN & CHI TIẾT MẪU
IF NOT EXISTS (SELECT 1 FROM dbo.HoaDon)
BEGIN
    SET IDENTITY_INSERT dbo.HoaDon ON;
    INSERT INTO dbo.HoaDon (MaHoaDon, MaKhachHang, MaNguoiDung, NgayLap, TongTien, GiamGia, ThanhTien) VALUES
    (1, 2, 1, DATEADD(day, -3, GETDATE()), 75000, 5000, 70000),
    (2, 3, 2, DATEADD(day, -2, GETDATE()), 128000, 10000, 118000),
    (3, 1, 2, DATEADD(day, -1, GETDATE()), 52000, 0, 52000),
    (4, 4, 1, GETDATE(), 147000, 15000, 132000);
    SET IDENTITY_INSERT dbo.HoaDon OFF;

    INSERT INTO dbo.ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien) VALUES
    (1, 'SP001', 2, 10000, 20000),
    (1, 'SP003', 1, 55000, 55000),
    (2, 'SP005', 2, 38000, 76000),
    (2, 'SP006', 1, 28000, 28000),
    (2, 'SP002', 2, 12000, 24000),
    (3, 'SP001', 3, 10000, 30000),
    (3, 'SP004', 1, 22000, 22000),
    (4, 'SP003', 1, 55000, 55000),
    (4, 'SP007', 1, 35000, 35000),
    (4, 'SP008', 2, 29000, 58000);
END
GO

PRINT N'>>> KHỞI TẠO CƠ SỞ DỮ LIỆU QuanLySieuThiMini THÀNH CÔNG! <<<';
GO
