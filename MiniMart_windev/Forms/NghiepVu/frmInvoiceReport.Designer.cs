﻿namespace MiniMart_windev.Forms.NghiepVu
{
    partial class frmInvoiceReport
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.grpTongHoaDon = new System.Windows.Forms.GroupBox();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.grpTongDoanhThu = new System.Windows.Forms.GroupBox();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.grpTongSanPham = new System.Windows.Forms.GroupBox();
            this.lblSoSanPham = new System.Windows.Forms.Label();
            this.dgvBaoCaoHoaDon = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpTongHoaDon.SuspendLayout();
            this.grpTongDoanhThu.SuspendLayout();
            this.grpTongSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(277, 13);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(247, 20);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "BÁO CÁO HÓA ĐƠN BÁN HÀNG";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(49, 78);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(69, 20);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(379, 78);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(81, 20);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(124, 73);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(200, 26);
            this.dtpTuNgay.TabIndex = 3;
            this.dtpTuNgay.Value = new System.DateTime(2026, 10, 5, 16, 2, 0, 0);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(466, 73);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(200, 26);
            this.dtpDenNgay.TabIndex = 4;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(53, 105);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(114, 38);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnTatCa
            // 
            this.btnTatCa.Location = new System.Drawing.Point(173, 105);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(81, 38);
            this.btnTatCa.TabIndex = 6;
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.UseVisualStyleBackColor = true;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // grpTongHoaDon
            // 
            this.grpTongHoaDon.Controls.Add(this.lblSoHoaDon);
            this.grpTongHoaDon.Location = new System.Drawing.Point(54, 191);
            this.grpTongHoaDon.Name = "grpTongHoaDon";
            this.grpTongHoaDon.Size = new System.Drawing.Size(200, 130);
            this.grpTongHoaDon.TabIndex = 7;
            this.grpTongHoaDon.TabStop = false;
            this.grpTongHoaDon.Text = "Tổng số hóa đơn";
            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.AutoSize = true;
            this.lblSoHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoHoaDon.Location = new System.Drawing.Point(3, 22);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(50, 60);
            this.lblSoHoaDon.TabIndex = 1;
            this.lblSoHoaDon.Text = "0";
            this.lblSoHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpTongDoanhThu
            // 
            this.grpTongDoanhThu.Controls.Add(this.lblDoanhThu);
            this.grpTongDoanhThu.Location = new System.Drawing.Point(281, 191);
            this.grpTongDoanhThu.Name = "grpTongDoanhThu";
            this.grpTongDoanhThu.Size = new System.Drawing.Size(300, 130);
            this.grpTongDoanhThu.TabIndex = 8;
            this.grpTongDoanhThu.TabStop = false;
            this.grpTongDoanhThu.Text = "Tổng doanh thu";
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThu.Location = new System.Drawing.Point(3, 22);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(158, 60);
            this.lblDoanhThu.TabIndex = 0;
            this.lblDoanhThu.Text = "0 VNĐ";
            this.lblDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpTongSanPham
            // 
            this.grpTongSanPham.Controls.Add(this.lblSoSanPham);
            this.grpTongSanPham.Location = new System.Drawing.Point(613, 191);
            this.grpTongSanPham.Name = "grpTongSanPham";
            this.grpTongSanPham.Size = new System.Drawing.Size(200, 130);
            this.grpTongSanPham.TabIndex = 9;
            this.grpTongSanPham.TabStop = false;
            this.grpTongSanPham.Text = "Tổng sản phẩm đã bán";
            // 
            // lblSoSanPham
            // 
            this.lblSoSanPham.AutoSize = true;
            this.lblSoSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoSanPham.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoSanPham.Location = new System.Drawing.Point(3, 22);
            this.lblSoSanPham.Name = "lblSoSanPham";
            this.lblSoSanPham.Size = new System.Drawing.Size(50, 60);
            this.lblSoSanPham.TabIndex = 0;
            this.lblSoSanPham.Text = "0";
            this.lblSoSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvBaoCaoHoaDon
            // 
            this.dgvBaoCaoHoaDon.AllowUserToAddRows = false;
            this.dgvBaoCaoHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaoCaoHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoHoaDon.Location = new System.Drawing.Point(53, 371);
            this.dgvBaoCaoHoaDon.MultiSelect = false;
            this.dgvBaoCaoHoaDon.Name = "dgvBaoCaoHoaDon";
            this.dgvBaoCaoHoaDon.ReadOnly = true;
            this.dgvBaoCaoHoaDon.RowHeadersWidth = 62;
            this.dgvBaoCaoHoaDon.RowTemplate.Height = 28;
            this.dgvBaoCaoHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCaoHoaDon.Size = new System.Drawing.Size(760, 153);
            this.dgvBaoCaoHoaDon.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "BỘ LỌC THỜI GIAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "THỐNG KÊ TỔNG QUAN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "DANH SÁCH HÓA ĐƠN";
            // 
            // frmInvoiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 694);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBaoCaoHoaDon);
            this.Controls.Add(this.grpTongSanPham);
            this.Controls.Add(this.grpTongDoanhThu);
            this.Controls.Add(this.grpTongHoaDon);
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInvoiceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo hóa đơn bán hàng";
            this.grpTongHoaDon.ResumeLayout(false);
            this.grpTongHoaDon.PerformLayout();
            this.grpTongDoanhThu.ResumeLayout(false);
            this.grpTongDoanhThu.PerformLayout();
            this.grpTongSanPham.ResumeLayout(false);
            this.grpTongSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.GroupBox grpTongHoaDon;
        private System.Windows.Forms.GroupBox grpTongDoanhThu;
        private System.Windows.Forms.GroupBox grpTongSanPham;
        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label lblSoSanPham;
        private System.Windows.Forms.DataGridView dgvBaoCaoHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}