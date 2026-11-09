namespace MiniMart_windev.Forms.HeThong
{
    partial class frmRoleManagement
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
            this.grpVaiTro = new System.Windows.Forms.GroupBox();
            this.btnXoaVaiTro = new System.Windows.Forms.Button();
            this.btnThemVaiTro = new System.Windows.Forms.Button();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPhanQuyen = new System.Windows.Forms.GroupBox();
            this.dgvPhanQuyen = new System.Windows.Forms.DataGridView();
            this.colMaChucNang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenChucNang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuocPhep = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnLuuPhanQuyen = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.grpVaiTro.SuspendLayout();
            this.grpPhanQuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTop.Controls.Add(this.lblTieuDe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(780, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(395, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ VAI TRÒ && PHÂN QUYỀN";
            // 
            // grpVaiTro
            // 
            this.grpVaiTro.Controls.Add(this.btnXoaVaiTro);
            this.grpVaiTro.Controls.Add(this.btnThemVaiTro);
            this.grpVaiTro.Controls.Add(this.cboVaiTro);
            this.grpVaiTro.Controls.Add(this.label1);
            this.grpVaiTro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVaiTro.Location = new System.Drawing.Point(15, 75);
            this.grpVaiTro.Name = "grpVaiTro";
            this.grpVaiTro.Size = new System.Drawing.Size(750, 75);
            this.grpVaiTro.TabIndex = 1;
            this.grpVaiTro.TabStop = false;
            this.grpVaiTro.Text = "Lựa chọn nhóm quyền";
            // 
            // btnXoaVaiTro
            // 
            this.btnXoaVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnXoaVaiTro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaVaiTro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaVaiTro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaVaiTro.ForeColor = System.Drawing.Color.White;
            this.btnXoaVaiTro.Location = new System.Drawing.Point(545, 25);
            this.btnXoaVaiTro.Name = "btnXoaVaiTro";
            this.btnXoaVaiTro.Size = new System.Drawing.Size(100, 32);
            this.btnXoaVaiTro.TabIndex = 3;
            this.btnXoaVaiTro.Text = "🗑️ Xóa vai trò";
            this.btnXoaVaiTro.UseVisualStyleBackColor = false;
            this.btnXoaVaiTro.Click += new System.EventHandler(this.btnXoaVaiTro_Click);
            // 
            // btnThemVaiTro
            // 
            this.btnThemVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnThemVaiTro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemVaiTro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaiTro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemVaiTro.ForeColor = System.Drawing.Color.White;
            this.btnThemVaiTro.Location = new System.Drawing.Point(420, 25);
            this.btnThemVaiTro.Name = "btnThemVaiTro";
            this.btnThemVaiTro.Size = new System.Drawing.Size(110, 32);
            this.btnThemVaiTro.TabIndex = 2;
            this.btnThemVaiTro.Text = "➕ Thêm vai trò";
            this.btnThemVaiTro.UseVisualStyleBackColor = false;
            this.btnThemVaiTro.Click += new System.EventHandler(this.btnThemVaiTro_Click);
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(145, 29);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(250, 25);
            this.cboVaiTro.TabIndex = 1;
            this.cboVaiTro.SelectedIndexChanged += new System.EventHandler(this.cboVaiTro_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn vai trò:";
            // 
            // grpPhanQuyen
            // 
            this.grpPhanQuyen.Controls.Add(this.dgvPhanQuyen);
            this.grpPhanQuyen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPhanQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPhanQuyen.Location = new System.Drawing.Point(15, 160);
            this.grpPhanQuyen.Name = "grpPhanQuyen";
            this.grpPhanQuyen.Size = new System.Drawing.Size(750, 300);
            this.grpPhanQuyen.TabIndex = 2;
            this.grpPhanQuyen.TabStop = false;
            this.grpPhanQuyen.Text = "Danh sách quyền theo từng chức năng trong hệ thống";
            // 
            // dgvPhanQuyen
            // 
            this.dgvPhanQuyen.AllowUserToAddRows = false;
            this.dgvPhanQuyen.AllowUserToDeleteRows = false;
            this.dgvPhanQuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhanQuyen.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaChucNang,
            this.colTenChucNang,
            this.colMoTa,
            this.colDuocPhep});
            this.dgvPhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhanQuyen.Location = new System.Drawing.Point(3, 21);
            this.dgvPhanQuyen.Name = "dgvPhanQuyen";
            this.dgvPhanQuyen.RowHeadersVisible = false;
            this.dgvPhanQuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhanQuyen.Size = new System.Drawing.Size(744, 276);
            this.dgvPhanQuyen.TabIndex = 0;
            // 
            // colMaChucNang
            // 
            this.colMaChucNang.DataPropertyName = "MaChucNang";
            this.colMaChucNang.HeaderText = "Mã CN";
            this.colMaChucNang.Name = "MaChucNang";
            this.colMaChucNang.ReadOnly = true;
            // 
            // colTenChucNang
            // 
            this.colTenChucNang.DataPropertyName = "TenChucNang";
            this.colTenChucNang.HeaderText = "Tên chức năng";
            this.colTenChucNang.Name = "TenChucNang";
            this.colTenChucNang.ReadOnly = true;
            // 
            // colMoTa
            // 
            this.colMoTa.DataPropertyName = "MoTa";
            this.colMoTa.HeaderText = "Mô tả";
            this.colMoTa.Name = "MoTa";
            this.colMoTa.ReadOnly = true;
            // 
            // colDuocPhep
            // 
            this.colDuocPhep.DataPropertyName = "DuocPhep";
            this.colDuocPhep.HeaderText = "Cho phép truy cập";
            this.colDuocPhep.Name = "DuocPhep";
            // 
            // btnLuuPhanQuyen
            // 
            this.btnLuuPhanQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnLuuPhanQuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuPhanQuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuPhanQuyen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuPhanQuyen.ForeColor = System.Drawing.Color.White;
            this.btnLuuPhanQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuPhanQuyen.Location = new System.Drawing.Point(585, 470);
            this.btnLuuPhanQuyen.Name = "btnLuuPhanQuyen";
            this.btnLuuPhanQuyen.Size = new System.Drawing.Size(180, 38);
            this.btnLuuPhanQuyen.TabIndex = 3;
            this.btnLuuPhanQuyen.Text = "💾 Lưu cấu hình quyền";
            this.btnLuuPhanQuyen.UseVisualStyleBackColor = false;
            this.btnLuuPhanQuyen.Click += new System.EventHandler(this.btnLuuPhanQuyen_Click);
            // 
            // frmRoleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(780, 520);
            this.Controls.Add(this.btnLuuPhanQuyen);
            this.Controls.Add(this.grpPhanQuyen);
            this.Controls.Add(this.grpVaiTro);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmRoleManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý vai trò & Phân quyền";
            this.Load += new System.EventHandler(this.frmRoleManagement_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.grpVaiTro.ResumeLayout(false);
            this.grpVaiTro.PerformLayout();
            this.grpPhanQuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpVaiTro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Button btnThemVaiTro;
        private System.Windows.Forms.Button btnXoaVaiTro;
        private System.Windows.Forms.GroupBox grpPhanQuyen;
        private System.Windows.Forms.DataGridView dgvPhanQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaChucNang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenChucNang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoTa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDuocPhep;
        private System.Windows.Forms.Button btnLuuPhanQuyen;
    }
}
