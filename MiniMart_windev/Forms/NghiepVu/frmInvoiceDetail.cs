﻿using MiniMart_windev.Helpers;
using MiniMart_windev.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;

namespace MiniMart_windev.Forms.NghiepVu
{
    public partial class frmInvoiceDetail : Form
    {
        private int maHoaDon;
        // Khai báo DataContext LINQ to SQL
        private QuanLyBanHangKhoDataContext db =
            new QuanLyBanHangKhoDataContext();

        // Khai báo đối tượng in hóa đơn
        public frmInvoiceDetail()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);

            // Thiết lập các thuộc tính
            txtMaHoaDon.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;

            cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;

            nudSoLuong.Minimum = 1;
            nudSoLuong.Value = 1;

            // Gắn sự kiện
            cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;
            nudSoLuong.ValueChanged += nudSoLuong_ValueChanged;

        }

        public frmInvoiceDetail(int maHD) : this()
        {
            maHoaDon = maHD;

            txtMaHoaDon.Text = maHoaDon.ToString();

            LoadSanPham();
            LoadChiTietHoaDon();
        }
        private void LoadSanPham()
        {
            try
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    var danhSach = db.GetTable<SanPham>()
                        .Select(sp => new
                        {
                            sp.MaSanPham,
                            sp.TenSanPham
                        })
                        .ToList();

                    cboSanPham.DataSource = danhSach;
                    cboSanPham.DisplayMember = "TenSanPham";
                    cboSanPham.ValueMember = "MaSanPham";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }
        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue == null)
                return;

            try
            {
                string maSP = cboSanPham.SelectedValue?.ToString();

                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    SanPham sp = db.GetTable<SanPham>()
                        .FirstOrDefault(x => x.MaSanPham == maSP);

                    if (sp != null)
                    {
                        txtDonGia.Text = sp.DonGia.ToString("N0");

                        TinhThanhTien();
                    }
                }
            }
            catch
            {
                // Bỏ qua khi ComboBox đang khởi tạo dữ liệu
            }
        }
        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void TinhThanhTien()
        {
            decimal donGia = 0;

            decimal.TryParse(
                txtDonGia.Text.Replace(",", ""),
                out donGia
            );

            decimal soLuong = nudSoLuong.Value;

            decimal thanhTien = soLuong * donGia;

            txtThanhTien.Text = thanhTien.ToString("N0");
        }
        private void LoadChiTietHoaDon()
        {
            try
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    var danhSach = (from ct in db.GetTable<ChiTietHoaDon>()
                                    join sp in db.GetTable<SanPham>()
                                    on ct.MaSanPham equals sp.MaSanPham
                                    where ct.MaHoaDon == maHoaDon
                                    select new
                                    {
                                        ct.MaSanPham,
                                        sp.TenSanPham,
                                        ct.SoLuong,
                                        ct.DonGia,
                                        ct.ThanhTien
                                    }).ToList();

                    dgvChiTietHoaDon.DataSource = danhSach;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hóa đơn: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra sản phẩm đã được chọn
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                cboSanPham.Focus();
                return;
            }

            try
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    string maSP = cboSanPham.SelectedValue?.ToString();
                    int soLuong = Convert.ToInt32(nudSoLuong.Value);

                    // 2. Kiểm tra hóa đơn
                    HoaDon hd = db.GetTable<HoaDon>()
                        .FirstOrDefault(x => x.MaHoaDon == maHoaDon);

                    if (hd == null)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn!");
                        return;
                    }

                    // 3. Tìm sản phẩm
                    SanPham sp = db.GetTable<SanPham>()
                        .FirstOrDefault(x => x.MaSanPham == maSP);

                    if (sp == null)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm!");
                        return;
                    }

                    // 4. Kiểm tra số lượng tồn kho
                    if (sp.SoLuongTon < soLuong)
                    {
                        MessageBox.Show("Số lượng tồn kho không đủ!");
                        return;
                    }

                    // 5. Kiểm tra sản phẩm đã có trong hóa đơn chưa
                    ChiTietHoaDon ctCu = db.GetTable<ChiTietHoaDon>()
                        .FirstOrDefault(x =>
                            x.MaHoaDon == maHoaDon &&
                            x.MaSanPham == maSP);

                    if (ctCu != null)
                    {
                        MessageBox.Show(
                            "Sản phẩm đã có trong hóa đơn!\n" +
                            "Bạn hãy sử dụng chức năng Sửa số lượng."
                        );
                        return;
                    }

                    // 6. Tính thành tiền
                    decimal donGia = sp.DonGia;
                    decimal thanhTien = donGia * soLuong;

                    // 7. Tính tổng tiền hóa đơn
                    decimal tongTienCu = db.GetTable<ChiTietHoaDon>()
                        .Where(x => x.MaHoaDon == maHoaDon)
                        .Select(x => (decimal?)x.ThanhTien)
                        .Sum() ?? 0;

                    decimal tongTienMoi = tongTienCu + thanhTien;

                    if (hd.GiamGia > tongTienMoi)
                    {
                        MessageBox.Show(
                            "Mức giảm giá hiện tại lớn hơn tổng tiền hóa đơn!"
                        );
                        return;
                    }

                    using (TransactionScope scope = new TransactionScope())
                    {
                        // 8. Tạo chi tiết hóa đơn mới
                        ChiTietHoaDon ct = new ChiTietHoaDon();

                        ct.MaHoaDon = maHoaDon;
                        ct.MaSanPham = maSP;
                        ct.SoLuong = soLuong;
                        ct.DonGia = donGia;
                        ct.ThanhTien = thanhTien;

                        db.GetTable<ChiTietHoaDon>().InsertOnSubmit(ct);

                        // 9. Trừ số lượng tồn kho
                        sp.SoLuongTon -= soLuong;

                        // 10. Cập nhật hóa đơn
                        hd.TongTien = tongTienMoi;
                        hd.ThanhTien = tongTienMoi - hd.GiamGia;

                        // 11. Lưu tất cả thay đổi
                        db.SubmitChanges();
                        scope.Complete();
                    }

                    MessageBox.Show("Thêm sản phẩm vào hóa đơn thành công!");

                    // 12. Tải lại danh sách
                    LoadChiTietHoaDon();

                    nudSoLuong.Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
            }
        }

        private void dgvChiTietHoaDon_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvChiTietHoaDon.Rows.Count)
            {
                try
                {
                    DataGridViewRow row = dgvChiTietHoaDon.Rows[e.RowIndex];
                    if (dgvChiTietHoaDon.Columns.Contains("MaSanPham") && row.Cells["MaSanPham"].Value != null)
                    {
                        string maSP = row.Cells["MaSanPham"].Value.ToString();
                        cboSanPham.SelectedValue = maSP;
                    }

                    if (dgvChiTietHoaDon.Columns.Contains("SoLuong") && row.Cells["SoLuong"].Value != null &&
                        decimal.TryParse(row.Cells["SoLuong"].Value.ToString(), out decimal sl))
                    {
                        nudSoLuong.Value = Math.Min(Math.Max(sl, nudSoLuong.Minimum), nudSoLuong.Maximum);
                    }

                    if (dgvChiTietHoaDon.Columns.Contains("DonGia") && row.Cells["DonGia"].Value != null &&
                        decimal.TryParse(row.Cells["DonGia"].Value.ToString(), out decimal dg))
                    {
                        txtDonGia.Text = dg.ToString("N0");
                    }

                    if (dgvChiTietHoaDon.Columns.Contains("ThanhTien") && row.Cells["ThanhTien"].Value != null &&
                        decimal.TryParse(row.Cells["ThanhTien"].Value.ToString(), out decimal tt))
                    {
                        txtThanhTien.Text = tt.ToString("N0");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Lỗi click dòng chi tiết hóa đơn: " + ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đã chọn sản phẩm
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }

            try
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    string maSP = cboSanPham.SelectedValue?.ToString();
                    int soLuongMoi = Convert.ToInt32(nudSoLuong.Value);

                    // 2. Tìm chi tiết hóa đơn
                    ChiTietHoaDon ct = db.GetTable<ChiTietHoaDon>()
                        .FirstOrDefault(x =>
                            x.MaHoaDon == maHoaDon &&
                            x.MaSanPham == maSP);

                    if (ct == null)
                    {
                        MessageBox.Show("Sản phẩm chưa có trong hóa đơn!");
                        return;
                    }

                    // 3. Tìm sản phẩm
                    SanPham sp = db.GetTable<SanPham>()
                        .FirstOrDefault(x => x.MaSanPham == maSP);

                    if (sp == null)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm!");
                        return;
                    }

                    // 4. Tính chênh lệch số lượng
                    int chenhLech = soLuongMoi - ct.SoLuong;

                    // 5. Kiểm tra tồn kho nếu tăng số lượng
                    if (chenhLech > 0 && sp.SoLuongTon < chenhLech)
                    {
                        MessageBox.Show("Số lượng tồn kho không đủ!");
                        return;
                    }

                    using (TransactionScope scope = new TransactionScope())
                    {
                        // 6. Cập nhật tồn kho
                        sp.SoLuongTon -= chenhLech;

                        // 7. Cập nhật chi tiết hóa đơn
                        ct.SoLuong = soLuongMoi;
                        ct.ThanhTien = ct.SoLuong * ct.DonGia;

                        // 8. Tìm hóa đơn
                        HoaDon hd = db.GetTable<HoaDon>()
                            .FirstOrDefault(x => x.MaHoaDon == maHoaDon);

                        if (hd == null)
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn!");
                            return;
                        }

                        // 9. Tính lại tổng tiền
                        decimal tongTienMoi = db.GetTable<ChiTietHoaDon>()
                            .Where(x => x.MaHoaDon == maHoaDon)
                            .Select(x => (decimal?)x.ThanhTien)
                            .Sum() ?? 0;

                        if (hd.GiamGia > tongTienMoi)
                        {
                            MessageBox.Show(
                                "Tổng tiền mới nhỏ hơn mức giảm giá hiện tại!"
                            );
                            return;
                        }

                        hd.TongTien = tongTienMoi;
                        hd.ThanhTien = tongTienMoi - hd.GiamGia;

                        // 10. Lưu thay đổi
                        db.SubmitChanges();
                        scope.Complete();
                    }

                    MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!");

                    // 11. Tải lại dữ liệu
                    LoadChiTietHoaDon();

                    nudSoLuong.Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa chi tiết hóa đơn: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra sản phẩm đã được chọn
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!");
                return;
            }

            // 2. Xác nhận xóa
            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sản phẩm này khỏi hóa đơn?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (ketQua == DialogResult.No)
                return;

            try
            {
                using (QuanLyBanHangKhoDataContext db =
                       new QuanLyBanHangKhoDataContext())
                {
                    string maSP = cboSanPham.SelectedValue?.ToString();

                    // 3. Tìm chi tiết hóa đơn
                    ChiTietHoaDon ct = db.GetTable<ChiTietHoaDon>()
                        .FirstOrDefault(x =>
                            x.MaHoaDon == maHoaDon &&
                            x.MaSanPham == maSP);

                    if (ct == null)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm trong hóa đơn!");
                        return;
                    }

                    // 4. Tìm sản phẩm trong kho
                    SanPham sp = db.GetTable<SanPham>()
                        .FirstOrDefault(x => x.MaSanPham == maSP);

                    if (sp == null)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm!");
                        return;
                    }

                    // 5. Tìm hóa đơn
                    HoaDon hd = db.GetTable<HoaDon>()
                        .FirstOrDefault(x => x.MaHoaDon == maHoaDon);

                    if (hd == null)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn!");
                        return;
                    }

                    using (TransactionScope scope = new TransactionScope())
                    {
                        // 6. Hoàn trả số lượng về kho
                        sp.SoLuongTon += ct.SoLuong;

                        // 7. Xóa chi tiết hóa đơn
                        db.GetTable<ChiTietHoaDon>().DeleteOnSubmit(ct);

                        // 8. Tính lại tổng tiền sau khi xóa
                        decimal tongTienMoi = db.GetTable<ChiTietHoaDon>()
                            .Where(x => x.MaHoaDon == maHoaDon)
                            .Select(x => (decimal?)x.ThanhTien)
                            .Sum() ?? 0;

                        // 9. Cập nhật hóa đơn
                        hd.TongTien = tongTienMoi;
                        hd.ThanhTien = tongTienMoi - hd.GiamGia;

                        // 10. Lưu thay đổi
                        db.SubmitChanges();
                        scope.Complete();
                    }

                    MessageBox.Show("Xóa sản phẩm khỏi hóa đơn thành công!");

                    // 11. Tải lại danh sách
                    LoadChiTietHoaDon();

                    // 12. Làm mới thông tin nhập liệu
                    cboSanPham.SelectedIndex = -1;
                    nudSoLuong.Value = 1;
                    txtDonGia.Clear();
                    txtThanhTien.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // 1. Bỏ chọn sản phẩm
            cboSanPham.SelectedIndex = -1;

            // 2. Đặt lại số lượng
            nudSoLuong.Value = 1;

            // 3. Xóa đơn giá và thành tiền
            txtDonGia.Clear();
            txtThanhTien.Clear();

            // 4. Bỏ chọn dòng trong DataGridView
            dgvChiTietHoaDon.ClearSelection();

            // 5. Tải lại danh sách chi tiết hóa đơn
            LoadChiTietHoaDon();
        }

        private void lblThanhTien_Click(object sender, EventArgs e)
        {

        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmInvoicePrint frm = new frmInvoicePrint(maHoaDon);
            frm.ShowDialog();
        }

        

    }
}
