# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINIMART MANAGEMENT SYSTEM)

> **Đồ án môn học:** Lập trình Windows / Lập trình ứng dụng trên Windows (C# .NET)  
> **Nền tảng công nghệ:** C# Windows Forms (.NET Framework 4.8), LINQ to SQL, Microsoft ReportViewer (RDLC), Microsoft SQL Server.  
> **Kiến trúc:** Phân tầng theo chuẩn Helper Class, Data Model, Business Logic, bảo mật mật khẩu SHA-256 & Phân quyền RBAC.

---

## 👥 THÀNH VIÊN NHÓM THỰC HIỆN

| STT | Họ và Tên | Mã số sinh viên (MSSV) | Vai trò & Nhiệm vụ chính |
| :---: | :--- | :---: | :--- |
| **1** | **Sỳ Gia Hân** | **51.01.104.024** | **Trưởng nhóm** - Quản lý cấu trúc, Tích hợp hệ thống, Kiến trúc Helper & Giao diện người dùng |
| **2** | **Nguyễn Cao Ngọc Huệ** | **51.01.104.032** | Quản lý danh mục sản phẩm, Nhà cung cấp, Nghiệp vụ Nhập kho & Báo cáo tồn kho RDLC |
| **3** | **Hồ Thanh Hải** | **51.01.104.021** | Nghiệp vụ bán hàng tại quầy (POS), Quản lý khách hàng, Hóa đơn & Báo cáo in hóa đơn RDLC |
| **4** | **Bùi Long Nhật** | **51.01.104.064** | Bảo mật hệ thống, Phân quyền RBAC, Báo cáo doanh thu RDLC & Thống kê kinh doanh |

---

## 🌟 ĐẶC TÍNH & ĐÁP ỨNG TIÊU CHÍ ĐỒ ÁN

### 1. Hệ thống 22 Forms & Công nghệ LINQ (3.0 điểm)
- **Vượt chỉ tiêu tối thiểu 15 Form:** Hệ thống được thiết kế với **22 Forms** hoàn chỉnh, trực quan, phân chia theo các module:
  - **Hệ thống:** Đăng nhập (`frmLogin`), Màn hình chính Dashboard (`frmMain`), Đổi mật khẩu (`frmChangePassword`), Quản lý tài khoản (`frmUserManagement`), Quản lý phân quyền vai trò (`frmRoleManagement`), Cấu hình kết nối SQL (`frmConnectionConfig`), Thông tin nhóm (`frmAbout`).
  - **Danh mục & Kho:** Quản lý sản phẩm (`frmProductManagement`), Quản lý danh mục (`frmCategoryManagement`), Quản lý nhà cung cấp (`frmSupplierManagement`), Nhập kho (`frmStockReceipt`), Chi tiết phiếu nhập (`frmStockReceiptDetail`).
  - **Nghiệp vụ Bán hàng (POS):** Lập hóa đơn (`frmSalesInvoice`), Chi tiết hóa đơn (`frmInvoiceDetail`), Quản lý khách hàng (`frmCustomerManagement`).
  - **Báo cáo & Thống kê:** Báo cáo doanh thu theo kỳ (`frmRevenueReport`), In báo cáo doanh thu (`frmRevenuePrint`), Báo cáo tồn kho & Cảnh báo (`frmInventoryReport`), Tra cứu & In hóa đơn (`frmInvoiceReport`, `frmInvoicePrint`), Biểu đồ thống kê top sản phẩm bán chạy (`frmSalesStatistics`).
- **Kỹ thuật LINQ:** Sử dụng **LINQ to SQL (.dbml)** với đầy đủ các toán tử Lambda và LINQ Query: `Where`, `Select`, `Join`, `GroupBy`, `OrderBy`, `OrderByDescending`, `Sum`, `Count`, `Take`, `Skip`.
- Tách biệt logic truy vấn thông qua các lớp Helper chuyên biệt (`ThemeHelper`, `SecurityHelper`, `CurrentUserSession`).

### 2. Bảo mật & Phân quyền đa cấp RBAC (2.0 điểm)
- **Mã hóa mật khẩu an toàn:** Không lưu mật khẩu Plain Text vào cơ sở dữ liệu. Sử dụng giải thuật băm một chiều **SHA-256** trong `SecurityHelper.cs`.
- **Phân quyền người dùng (Role-Based Access Control):**
  - Hệ thống cơ sở dữ liệu thiết kế 4 bảng cốt lõi: `NguoiDung`, `VaiTro`, `PhanQuyen`, `ChucNang`.
  - Sau khi đăng nhập thành công, thông tin người dùng được lưu trong `CurrentUserSession`.
  - Tự động kiểm tra quyền và **Ẩn/Hiện (Visible)** hoặc **Vô hiệu hóa (Enabled)** các Menu và nút tắt Dashboard tương ứng trên `frmMain`.
  - Hỗ trợ các vai trò điển hình: *Quản trị viên* (toàn quyền), *Thu ngân* (chỉ bán hàng & in hóa đơn), *Thủ kho* (nhập kho & quản lý tồn kho).

### 3. Logic Nghiệp vụ nâng cao (2.0 điểm)
- **Ràng buộc tồn kho chặt chẽ:** Tự động kiểm tra số lượng tồn kho thực tế trước khi thêm vào giỏ hàng. Cảnh báo và dừng giao dịch nếu số lượng yêu cầu vượt quá tồn kho.
- **Tự động trừ/cộng tồn kho:**
  - Khi lưu hóa đơn bán hàng: Tự động trừ số lượng tồn kho tương ứng của sản phẩm.
  - Khi hoàn trả hoặc xóa chi tiết hóa đơn: Tự động hoàn lại số lượng vào kho.
  - Khi nhập kho: Tự động cộng dồn số lượng vào kho và cập nhật tổng tiền phiếu nhập.
- **Tính toán chiết khấu & giảm giá:** Tự động tính toán tổng tiền, số tiền giảm giá và thành tiền theo từng hóa đơn.
- **Giao dịch toàn vẹn (`TransactionScope`):** Sử dụng `System.Transactions.TransactionScope` để đảm bảo tính toàn vẹn tuyệt đối của dữ liệu. Nếu việc ghi chi tiết hóa đơn hoặc cập nhật tồn kho gặp lỗi, toàn bộ giao dịch sẽ tự động Rollback về trạng thái ban đầu.

### 4. Hệ thống 03 Báo cáo Report in ấn RDLC (1.0 điểm)
- Tích hợp công nghệ **Microsoft Reporting / ReportViewer (.rdlc)** chuyên nghiệp:
  1. **Báo cáo Hóa đơn bán hàng (`ReportHoaDon.rdlc`):** Truyền đầy đủ các tham số `ReportParameter` (Mã HĐ, Ngày lập, Khách hàng, Người lập, Tổng tiền, Giảm giá, Thành tiền) và bảng danh sách chi tiết hàng hóa (`ReportDataSource`).
  2. **Báo cáo Tồn kho & Cảnh báo (`rptInventory.rdlc`):** Báo cáo số lượng tồn kho theo danh mục, lọc theo tiêu chí nhóm hàng và cảnh báo hàng sắp hết.
  3. **Báo cáo Doanh thu bán hàng (`rptDoanhThu.rdlc`):** Lọc doanh thu theo khoảng thời gian tùy chọn (*Từ ngày... Đến ngày...*), thống kê chi tiết từng hóa đơn, tự động tính tổng doanh thu (`Sum`) và giá trị trung bình đơn hàng.
  4. **Thống kê kinh doanh (`frmSalesStatistics.cs`):** Trực quan hóa dữ liệu kinh doanh và top các sản phẩm bán chạy nhất.

### 5. Tính năng bổ trợ chuyên nghiệp
- **Chế độ Dark Mode / Light Mode đồng bộ toàn hệ thống:** Hỗ trợ chuyển đổi giao diện sáng/tối tức thời trên tất cả các form, các nút bấm và chữ hiển thị với độ tương phản cao, hiện đại.
- **Điều hướng thông minh:** Mỗi form con đều có nút **`Về Menu Chính`** và phím tắt tiện lợi.
- **Giao diện tự động thu phóng (Responsive):** Thiết lập `Anchor` đa chiều và `AutoSizeColumnsMode = Fill` cho DataGridView, co giãn mượt mà khi người dùng phóng to hoặc thay đổi kích thước cửa sổ.

---

## 🛠 HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

### Yêu cầu môi trường
- Hệ điều hành: Windows 10 / Windows 11.
- Môi trường phát triển: **Visual Studio 2019** hoặc **Visual Studio 2022** (khuyến nghị có cài đặt workload *.NET Desktop Development*).
- Cơ sở dữ liệu: **Microsoft SQL Server** (bản 2014, 2017, 2019, 2022 hoặc SQL Server Express / LocalDB).
- Microsoft Reporting Services Projects Extension (để xem/chỉnh sửa file `.rdlc` nếu cần).

### Các bước thực hiện

#### Bước 1: Khởi tạo Cơ sở dữ liệu SQL Server
1. Mở **SQL Server Management Studio (SSMS)** và kết nối tới SQL Server của bạn.
2. Mở file script SQL có sẵn trong thư mục: [`Database/QuanLySieuThiMini.sql`](Database/QuanLySieuThiMini.sql).
3. Bấm **Execute (F5)** để tự động tạo cơ sở dữ liệu `QuanLySieuThiMini`, các bảng, ràng buộc khóa ngoại và dữ liệu mẫu (Seed Data).

#### Bước 2: Mở và cấu hình giải pháp trong Visual Studio
1. Mở file giải pháp **`MiniMart_windev.sln`** bằng Visual Studio.
2. Kiểm tra chuỗi kết nối trong file [`MiniMart_windev/App.config`](MiniMart_windev/App.config) (hoặc sử dụng form cấu hình kết nối `frmConnectionConfig` ngay trong phần mềm):
   ```xml
   <connectionStrings>
     <add name="MiniMart_windev.Properties.Settings.QuanLySieuThiMiniConnectionString"
          connectionString="Data Source=.;Initial Catalog=QuanLySieuThiMini;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
   *(Thay đổi `Data Source=.` thành tên Server SQL của máy bạn nếu dùng Named Instance như `.\SQLEXPRESS`).*

#### Bước 3: Khởi chạy chương trình
1. Bấm **F5** (hoặc nút **Start**) trong Visual Studio để biên dịch và chạy phần mềm.
2. Đăng nhập bằng một trong các tài khoản demo sau:

| Tên đăng nhập | Mật khẩu | Vai trò | Quyền hạn truy cập |
| :--- | :---: | :---: | :--- |
| **`admin`** | **`123456`** | **Quản trị viên** | **Toàn quyền hệ thống:** Quản lý tài khoản, phân quyền, cấu hình, danh mục, kho, bán hàng và tất cả báo cáo. |
| **`thungan01`** | **`123456`** | **Thu ngân** | Bán hàng (POS), tra cứu hóa đơn, in hóa đơn, quản lý khách hàng. *(Các menu hệ thống, quản lý kho tự động bị ẩn/khóa)*. |
| **`thukho01`** | **`123456`** | **Thủ kho** | Quản lý sản phẩm, danh mục, nhà cung cấp, nhập kho hàng hóa, báo cáo tồn kho & cảnh báo. *(Menu bán hàng và hệ thống tự động khóa)*. |

---

## 📁 CẤU TRÚC THƯ MỤC DỰ ÁN

```text
MiniMart_windev/
│
├── Database/
│   └── QuanLySieuThiMini.sql        # Script SQL tạo DB, bảng, khóa ngoại & dữ liệu mẫu
│
├── MiniMart_windev/
│   ├── Forms/
│   │   ├── HeThong/                 # Các Form Hệ thống & Phân quyền (Login, Main, User, Role, Config, About)
│   │   ├── DanhMuc/                 # Các Form Quản lý Danh mục (Product, Category, Supplier, StockReceipt)
│   │   ├── NghiepVu/                # Các Form Nghiệp vụ (SalesInvoice, InvoiceDetail, Customer, InvoicePrint)
│   │   └── BaoCao/                  # Các Form & File Báo cáo (RevenueReport, InventoryReport, SalesStatistics)
│   │
│   ├── Helpers/
│   │   ├── SecurityHelper.cs        # Xử lý mã hóa băm SHA-256 mật khẩu
│   │   ├── ThemeHelper.cs           # Xử lý chế độ Dark Mode / Light Mode toàn hệ thống
│   │   └── CurrentUserSession.cs    # Quản lý phiên đăng nhập tĩnh và phân quyền
│   │
│   ├── Models/
│   │   ├── MiniMartDB.dbml          # Sơ đồ quan hệ thực thể LINQ to SQL
│   │   └── MiniMartDB.designer.cs   # Các lớp thực thể tự động sinh từ LINQ
│   │
│   ├── App.config                   # Cấu hình Connection String & tham số ứng dụng
│   ├── packages.config              # Quản lý thư viện phụ thuộc NuGet
│   └── MiniMart_windev.csproj       # File cấu hình Project C#
│
├── MiniMart_windev.sln              # Solution Visual Studio chuẩn cho mọi phiên bản VS
├── .gitignore                       # Loại bỏ các file rác (bin, obj, .vs) khi commit lên Git
└── README.md                        # Tài liệu hướng dẫn đồ án chi tiết
```

---

## 🏆 KẾT LUẬN & CAM KẾT
- Dự án được xây dựng tuân thủ chuẩn quy phạm lập trình hướng đối tượng trong C# WinForms.
- Mã nguồn sạch sẽ, chú thích rõ ràng, xử lý ngoại lệ `try...catch` đầy đủ trên mọi thao tác dữ liệu.
- Đảm bảo tính toàn vẹn, bảo mật và trải nghiệm người dùng tối ưu.
