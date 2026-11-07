namespace MiniMart_windev.Forms.BaoCao
{
    partial class frmInventoryReport
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
            this.panelFilter = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLoc = new System.Windows.Forms.Button();
            this.numNguongTon = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCanhBaoSapHet = new System.Windows.Forms.CheckBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelKPI = new System.Windows.Forms.Panel();
            this.panelCard3 = new System.Windows.Forms.Panel();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelCard2 = new System.Windows.Forms.Panel();
            this.lblTongTonKho = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelCard1 = new System.Windows.Forms.Panel();
            this.lblTongMatHang = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
                        this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNguongTon)).BeginInit();
            this.panelKPI.SuspendLayout();
            this.panelCard3.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(950, 50);
            this.panelTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(371, 25);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "BÁO CÁO TỒN KHO && CẢNH BÁO NHẬP";
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.txtTimKiem);
            this.panelFilter.Controls.Add(this.label4);
            this.panelFilter.Controls.Add(this.btnLoc);
            this.panelFilter.Controls.Add(this.numNguongTon);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.chkCanhBaoSapHet);
            this.panelFilter.Controls.Add(this.cboDanhMuc);
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 50);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(950, 60);
            this.panelFilter.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(670, 17);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(150, 25);
            this.txtTimKiem.TabIndex = 7;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label4.Location = new System.Drawing.Point(605, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tìm kiếm:";
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(830, 13);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 33);
            this.btnLoc.TabIndex = 5;
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // numNguongTon
            // 
            this.numNguongTon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numNguongTon.Location = new System.Drawing.Point(535, 17);
            this.numNguongTon.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numNguongTon.Name = "numNguongTon";
            this.numNguongTon.Size = new System.Drawing.Size(60, 25);
            this.numNguongTon.TabIndex = 4;
            this.numNguongTon.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label2.Location = new System.Drawing.Point(445, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngưỡng tồn:";
            // 
            // chkCanhBaoSapHet
            // 
            this.chkCanhBaoSapHet.AutoSize = true;
            this.chkCanhBaoSapHet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkCanhBaoSapHet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.chkCanhBaoSapHet.Location = new System.Drawing.Point(280, 20);
            this.chkCanhBaoSapHet.Name = "chkCanhBaoSapHet";
            this.chkCanhBaoSapHet.Size = new System.Drawing.Size(145, 21);
            this.chkCanhBaoSapHet.TabIndex = 2;
            this.chkCanhBaoSapHet.Text = "Chỉ xem SP sắp hết";
            this.chkCanhBaoSapHet.UseVisualStyleBackColor = true;
            this.chkCanhBaoSapHet.CheckedChanged += new System.EventHandler(this.chkCanhBaoSapHet_CheckedChanged);
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(90, 17);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(170, 25);
            this.cboDanhMuc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh mục:";
            // 
            // panelKPI
            // 
            this.panelKPI.Controls.Add(this.panelCard3);
            this.panelKPI.Controls.Add(this.panelCard2);
            this.panelKPI.Controls.Add(this.panelCard1);
            this.panelKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPI.Location = new System.Drawing.Point(0, 110);
            this.panelKPI.Name = "panelKPI";
            this.panelKPI.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelKPI.Size = new System.Drawing.Size(950, 105);
            this.panelKPI.TabIndex = 2;
            // 
            // panelCard3
            // 
            this.panelCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelCard3.Controls.Add(this.lblCanhBao);
            this.panelCard3.Controls.Add(this.label6);
            this.panelCard3.Location = new System.Drawing.Point(630, 10);
            this.panelCard3.Name = "panelCard3";
            this.panelCard3.Size = new System.Drawing.Size(290, 85);
            this.panelCard3.TabIndex = 2;
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCanhBao.ForeColor = System.Drawing.Color.White;
            this.lblCanhBao.Location = new System.Drawing.Point(15, 38);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(260, 35);
            this.lblCanhBao.TabIndex = 1;
            this.lblCanhBao.Text = "0";
            this.lblCanhBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(15, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "SP CẦN NHẬP (SẮP HẾT)";
            // 
            // panelCard2
            // 
            this.panelCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelCard2.Controls.Add(this.lblTongTonKho);
            this.panelCard2.Controls.Add(this.label5);
            this.panelCard2.Location = new System.Drawing.Point(325, 10);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(290, 85);
            this.panelCard2.TabIndex = 1;
            // 
            // lblTongTonKho
            // 
            this.lblTongTonKho.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongTonKho.ForeColor = System.Drawing.Color.White;
            this.lblTongTonKho.Location = new System.Drawing.Point(15, 38);
            this.lblTongTonKho.Name = "lblTongTonKho";
            this.lblTongTonKho.Size = new System.Drawing.Size(260, 35);
            this.lblTongTonKho.TabIndex = 1;
            this.lblTongTonKho.Text = "0";
            this.lblTongTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(15, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "TỔNG SỐ LƯỢNG TỒN";
            // 
            // panelCard1
            // 
            this.panelCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelCard1.Controls.Add(this.lblTongMatHang);
            this.panelCard1.Controls.Add(this.label3);
            this.panelCard1.Location = new System.Drawing.Point(20, 10);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(290, 85);
            this.panelCard1.TabIndex = 0;
            // 
            // lblTongMatHang
            // 
            this.lblTongMatHang.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongMatHang.ForeColor = System.Drawing.Color.White;
            this.lblTongMatHang.Location = new System.Drawing.Point(15, 38);
            this.lblTongMatHang.Name = "lblTongMatHang";
            this.lblTongMatHang.Size = new System.Drawing.Size(260, 35);
            this.lblTongMatHang.TabIndex = 1;
            this.lblTongMatHang.Text = "0";
            this.lblTongMatHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "TỔNG SỐ MẶT HÀNG";
            // 
            // dgvTonKho
            // 
            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AllowUserToDeleteRows = false;
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonKho.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaSP,
            this.colTenSP,
            this.colTenDanhMuc,
            this.colDonGia,
            this.colSoLuongTon,
            this.colTinhTrang});
            this.dgvTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTonKho.Location = new System.Drawing.Point(0, 215);
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.RowHeadersVisible = false;
            this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.Size = new System.Drawing.Size(950, 385);
            this.dgvTonKho.TabIndex = 3;
            this.dgvTonKho.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTonKho_CellContentClick);
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "STT";
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 50;
            // 
            // colMaSP
            // 
            this.colMaSP.DataPropertyName = "MaSanPham";
            this.colMaSP.HeaderText = "Mã SP";
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.ReadOnly = true;
            this.colMaSP.Width = 90;
            // 
            // colTenSP
            // 
            this.colTenSP.DataPropertyName = "TenSanPham";
            this.colTenSP.HeaderText = "Tên sản phẩm";
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.ReadOnly = true;
            this.colTenSP.Width = 220;
            // 
            // colTenDanhMuc
            // 
            this.colTenDanhMuc.DataPropertyName = "TenDanhMuc";
            this.colTenDanhMuc.HeaderText = "Danh mục";
            this.colTenDanhMuc.Name = "colTenDanhMuc";
            this.colTenDanhMuc.ReadOnly = true;
            this.colTenDanhMuc.Width = 140;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DonGia";
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            this.colDonGia.Width = 100;
            // 
            // colSoLuongTon
            // 
            this.colSoLuongTon.DataPropertyName = "SoLuongTon";
            this.colSoLuongTon.HeaderText = "SL Tồn";
            this.colSoLuongTon.Name = "colSoLuongTon";
            this.colSoLuongTon.ReadOnly = true;
            this.colSoLuongTon.Width = 90;
            // 
            // colTinhTrang
            // 
            this.colTinhTrang.DataPropertyName = "TinhTrang";
            this.colTinhTrang.HeaderText = "Tình trạng tồn";
            this.colTinhTrang.Name = "colTinhTrang";
            this.colTinhTrang.ReadOnly = true;
            this.colTinhTrang.Width = 150;
            // 
            // frmInventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.dgvTonKho);
            this.Controls.Add(this.panelKPI);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "frmInventoryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Tồn Kho & Cảnh Báo";
            this.Load += new System.EventHandler(this.frmInventoryReport_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNguongTon)).EndInit();
            this.panelKPI.ResumeLayout(false);
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.CheckBox chkCanhBaoSapHet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numNguongTon;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelKPI;
        private System.Windows.Forms.Panel panelCard1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTongMatHang;
        private System.Windows.Forms.Panel panelCard2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTongTonKho;
        private System.Windows.Forms.Panel panelCard3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhTrang;
    }
}