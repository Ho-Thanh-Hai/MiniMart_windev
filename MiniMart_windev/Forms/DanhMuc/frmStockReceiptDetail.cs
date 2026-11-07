using System.Transactions;
﻿using MiniMart_windev.Helpers;
using MiniMart_windev.Models;
using QuanLyBanHangKhoDataContext = MiniMart_windev.Models.MiniMartDBDataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMart_windev.Forms.DanhMuc
{
    public partial class frmStockReceiptDetail : Form
    {
        private QuanLyBanHangKhoDataContext db = new QuanLyBanHangKhoDataContext();

        public frmStockReceiptDetail()
        {
            InitializeComponent();
            ThemeHelper.SetupFormThemeAndNavigation(this);

            LoadPhieuNhap();
            LoadSanPham();

            cboMaPhieuNhap.SelectedIndex = -1;
            cboSanPham.SelectedIndex = -1;

            LoadChiTietPhieuNhap();
        }

        private void LoadPhieuNhap()
        {
            cboMaPhieuNhap.DataSource = db.GetTable<PhieuNhap>().ToList();
            cboMaPhieuNhap.DisplayMember = "MaPhieuNhap";
            cboMaPhieuNhap.ValueMember = "MaPhieuNhap";
        }

        private void LoadSanPham()
        {
            cboSanPham.DataSource = db.GetTable<SanPham>().ToList();
            cboSanPham.DisplayMember = "TenSanPham";
            cboSanPham.ValueMember = "MaSanPham";
        }

        private void LoadChiTietPhieuNhap()
        {
            var danhSach = db.GetTable<ChiTietPhieuNhap>()
                .Select(ct => new
                {
                    ct.MaPhieuNhap,
                    ct.MaSanPham,
                    TenSanPham = ct.SanPham.TenSanPham,
                    ct.SoLuong,
                    ct.DonGiaNhap,
                    ct.ThanhTien
                })
                .ToList();

            dgvChiTietPhieuNhap.DataSource = danhSach;
        }

        private void CapNhatTongTien(int maPN)
        {
            PhieuNhap pn = db.GetTable<PhieuNhap>()
                .FirstOrDefault(p => p.MaPhieuNhap == maPN);

            if (pn == null)
                return;

            pn.TongTien = db.GetTable<ChiTietPhieuNhap>()
                .Where(ct => ct.MaPhieuNhap == maPN)
                .Select(ct => (decimal?)ct.ThanhTien)
                .Sum() ?? 0;

            db.SubmitChanges();
        }
        private void TinhThanhTien()
        {
            int soLuong;
            decimal donGia;

            if (int.TryParse(txtSoLuong.Text, out soLuong) &&
                decimal.TryParse(txtDonGiaNhap.Text, out donGia))
            {
                txtThanhTien.Text = (soLuong * donGia).ToString("#,##0");
            }
            else
            {
                txtThanhTien.Clear();
            }
        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboMaPhieuNhap.SelectedValue == null ||
                cboSanPham.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDonGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            int soLuong;
            decimal donGia;

            if (!int.TryParse(txtSoLuong.Text, out soLuong) ||
                !decimal.TryParse(txtDonGiaNhap.Text, out donGia) ||
                soLuong <= 0 || donGia <= 0)
            {
                MessageBox.Show("Số lượng và đơn giá phải lớn hơn 0!");
                return;
            }

            int maPN = Convert.ToInt32(cboMaPhieuNhap.SelectedValue);
            string maSP = cboSanPham.SelectedValue?.ToString();

            bool daTonTai = db.GetTable<ChiTietPhieuNhap>()
                .Any(x => x.MaPhieuNhap == maPN && x.MaSanPham == maSP);

            if (daTonTai)
            {
                MessageBox.Show("Sản phẩm này đã có trong phiếu nhập!");
                return;
            }

            ChiTietPhieuNhap ct = new ChiTietPhieuNhap();

            ct.MaPhieuNhap = maPN;
            ct.MaSanPham = maSP;
            ct.SoLuong = soLuong;
            ct.DonGiaNhap = donGia;
            ct.ThanhTien = soLuong * donGia;

            SanPham sp = db.GetTable<SanPham>()
                .FirstOrDefault(s => s.MaSanPham == maSP);

            using (TransactionScope scope = new TransactionScope())
            {
                if (sp != null)
                {
                    sp.SoLuongTon += soLuong;
                }

                db.GetTable<ChiTietPhieuNhap>().InsertOnSubmit(ct);

                db.SubmitChanges();
                CapNhatTongTien(maPN);
                scope.Complete();
            }

            MessageBox.Show("Thêm chi tiết phiếu nhập thành công!");
            LoadChiTietPhieuNhap();
        }

        private void cboMaPhieuNhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaPhieuNhap.SelectedValue == null ||
                !(cboMaPhieuNhap.SelectedValue is int))
                return;

            LoadChiTietPhieuNhap();
        }

        private void dgvChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvChiTietPhieuNhap.Rows[e.RowIndex];

            if (row.Cells["MaPhieuNhap"].Value == null ||
                row.Cells["MaSanPham"].Value == null)
                return;

            int maPN = Convert.ToInt32(row.Cells["MaPhieuNhap"].Value);
            string maSP = row.Cells["MaSanPham"].Value?.ToString();

            ChiTietPhieuNhap ct = db.GetTable<ChiTietPhieuNhap>()
                .FirstOrDefault(x => x.MaPhieuNhap == maPN &&
                                     x.MaSanPham == maSP);

            if (ct == null)
            {
                MessageBox.Show("Không tìm thấy chi tiết phiếu nhập!");
                return;
            }

            cboMaPhieuNhap.SelectedValue = maPN;
            cboSanPham.SelectedValue = maSP;

            txtSoLuong.Text = ct.SoLuong.ToString();
            txtDonGiaNhap.Text = ct.DonGiaNhap.ToString("0");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboMaPhieuNhap.SelectedValue == null ||
                cboSanPham.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDonGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            int soLuongMoi;
            decimal donGiaMoi;

            if (!int.TryParse(txtSoLuong.Text, out soLuongMoi) ||
                !decimal.TryParse(txtDonGiaNhap.Text, out donGiaMoi) ||
                soLuongMoi <= 0 || donGiaMoi <= 0)
            {
                MessageBox.Show("Số lượng và đơn giá phải lớn hơn 0!");
                return;
            }

            int maPN = Convert.ToInt32(cboMaPhieuNhap.SelectedValue);
            string maSP = cboSanPham.SelectedValue?.ToString();

            ChiTietPhieuNhap ct = db.GetTable<ChiTietPhieuNhap>()
                .FirstOrDefault(x => x.MaPhieuNhap == maPN && x.MaSanPham == maSP);

            if (ct == null)
            {
                MessageBox.Show("Không tìm thấy chi tiết phiếu nhập!");
                return;
            }

            int soLuongCu = ct.SoLuong;
            decimal thanhTienCu = ct.ThanhTien;

            ct.SoLuong = soLuongMoi;
            ct.DonGiaNhap = donGiaMoi;
            ct.ThanhTien = soLuongMoi * donGiaMoi;

            PhieuNhap pn = db.GetTable<PhieuNhap>()
                .FirstOrDefault(p => p.MaPhieuNhap == maPN);

            SanPham sp = db.GetTable<SanPham>()
                .FirstOrDefault(s => s.MaSanPham == maSP);

            if (pn != null)
                pn.TongTien += ct.ThanhTien - thanhTienCu;

            if (sp != null)
                sp.SoLuongTon += soLuongMoi - soLuongCu;

            db.SubmitChanges();
            CapNhatTongTien(maPN);

            MessageBox.Show("Cập nhật chi tiết phiếu nhập thành công!");

            LoadChiTietPhieuNhap();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cboMaPhieuNhap.SelectedValue == null ||
                cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chi tiết cần xóa!");
                return;
            }

            int maPN = Convert.ToInt32(cboMaPhieuNhap.SelectedValue);
            string maSP = cboSanPham.SelectedValue?.ToString();

            ChiTietPhieuNhap ct = db.GetTable<ChiTietPhieuNhap>()
                .FirstOrDefault(x => x.MaPhieuNhap == maPN && x.MaSanPham == maSP);

            if (ct == null)
            {
                MessageBox.Show("Không tìm thấy chi tiết phiếu nhập!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa chi tiết này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int soLuongCu = ct.SoLuong;
                decimal thanhTienCu = ct.ThanhTien;

                PhieuNhap pn = db.GetTable<PhieuNhap>()
                    .FirstOrDefault(p => p.MaPhieuNhap == maPN);

                SanPham sp = db.GetTable<SanPham>()
                    .FirstOrDefault(s => s.MaSanPham == maSP);

                if (pn != null)
                    pn.TongTien -= thanhTienCu;

                if (sp != null)
                    sp.SoLuongTon -= soLuongCu;

                db.GetTable<ChiTietPhieuNhap>().DeleteOnSubmit(ct);
                db.SubmitChanges();
                CapNhatTongTien(maPN);

                MessageBox.Show("Xóa chi tiết phiếu nhập thành công!");

                LoadChiTietPhieuNhap();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboMaPhieuNhap.SelectedIndex = -1;
            cboSanPham.SelectedIndex = -1;

            txtSoLuong.Clear();
            txtDonGiaNhap.Clear();
            txtThanhTien.Clear();
            txtTimTenSanPham.Clear();

            LoadChiTietPhieuNhap();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboMaPhieuNhap.SelectedValue == null ||
                !(cboMaPhieuNhap.SelectedValue is int))
            {
                MessageBox.Show("Vui lòng chọn mã phiếu nhập!");
                return;
            }

            string tuKhoa = txtTimTenSanPham.Text.Trim();
            int maPN = Convert.ToInt32(cboMaPhieuNhap.SelectedValue);

            var danhSach = db.GetTable<ChiTietPhieuNhap>()
                .Where(ct => ct.MaPhieuNhap == maPN &&
                             ct.SanPham.TenSanPham.Contains(tuKhoa))
                .Select(ct => new
                {
                    ct.MaPhieuNhap,
                    TenSanPham = ct.SanPham.TenSanPham,
                    ct.SoLuong,
                    ct.DonGiaNhap,
                    ct.ThanhTien
                })
                .ToList();

            dgvChiTietPhieuNhap.DataSource = danhSach;

            if (danhSach.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (ActiveControl == cboMaPhieuNhap)
                {
                    cboSanPham.Focus();
                    return true;
                }
                else if (ActiveControl == cboSanPham)
                {
                    txtSoLuong.Focus();
                    return true;
                }
                else if (ActiveControl == txtSoLuong)
                {
                    txtDonGiaNhap.Focus();
                    return true;
                }
                else if (ActiveControl == txtDonGiaNhap)
                {
                    btnThem.Focus();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
