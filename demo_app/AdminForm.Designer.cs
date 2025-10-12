namespace demo_app
{
    partial class AdminForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox3 = new GroupBox();
            dgvMonBanChay = new DataGridView();
            groupBox2 = new GroupBox();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox1 = new GroupBox();
            lblBanCoKhach = new Label();
            lblTongHoaDon = new Label();
            lblDoanhThuHomNay = new Label();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            groupBox4 = new GroupBox();
            cboVaiTro = new ComboBox();
            chkTrangThai = new CheckBox();
            dtpNgayVaoLam = new DateTimePicker();
            txtMatKhau = new TextBox();
            txtTenDN = new TextBox();
            txtEmail = new TextBox();
            txtSDT = new TextBox();
            txtHoTen = new TextBox();
            btnXoa = new Button();
            btnLuu = new Button();
            btnThemMoi = new Button();
            btnDatLaiMatKhau = new Button();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label2 = new Label();
            dgvNhanVien = new DataGridView();
            tabPage3 = new TabPage();
            groupBox5 = new GroupBox();
            chkHoatDong = new CheckBox();
            numDonGia = new NumericUpDown();
            btnXoaMon = new Button();
            btnLuuMon = new Button();
            btnThemMoiMon = new Button();
            txtTenMon = new TextBox();
            lbl12 = new Label();
            lbl11 = new Label();
            dgvMonAn = new DataGridView();
            btnQuanLyDanhMuc = new Button();
            cboDanhMuc = new ComboBox();
            label11 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonBanChay).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            tabPage3.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1408, 1035);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(10, 58);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1388, 967);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tổng Quan";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvMonBanChay);
            groupBox3.Location = new Point(6, 508);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1376, 214);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Top 5 món bán chạy";
            // 
            // dgvMonBanChay
            // 
            dgvMonBanChay.AllowUserToOrderColumns = true;
            dgvMonBanChay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonBanChay.Dock = DockStyle.Fill;
            dgvMonBanChay.Location = new Point(3, 43);
            dgvMonBanChay.Name = "dgvMonBanChay";
            dgvMonBanChay.RowHeadersWidth = 102;
            dgvMonBanChay.Size = new Size(1370, 168);
            dgvMonBanChay.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chart1);
            groupBox2.Location = new Point(6, 259);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1376, 214);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Doanh thu tuần qua";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(170, 55);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Doanh Thu";
            chart1.Series.Add(series1);
            chart1.Size = new Size(924, 125);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblBanCoKhach);
            groupBox1.Controls.Add(lblTongHoaDon);
            groupBox1.Controls.Add(lblDoanhThuHomNay);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1376, 204);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông số trong ngày";
            // 
            // lblBanCoKhach
            // 
            lblBanCoKhach.AutoSize = true;
            lblBanCoKhach.Location = new Point(1150, 128);
            lblBanCoKhach.Name = "lblBanCoKhach";
            lblBanCoKhach.Size = new Size(184, 41);
            lblBanCoKhach.TabIndex = 0;
            lblBanCoKhach.Text = "BanCoKhach";
            // 
            // lblTongHoaDon
            // 
            lblTongHoaDon.AutoSize = true;
            lblTongHoaDon.Location = new Point(577, 128);
            lblTongHoaDon.Name = "lblTongHoaDon";
            lblTongHoaDon.Size = new Size(194, 41);
            lblTongHoaDon.TabIndex = 0;
            lblTongHoaDon.Text = "TongHoaDon";
            // 
            // lblDoanhThuHomNay
            // 
            lblDoanhThuHomNay.AutoSize = true;
            lblDoanhThuHomNay.Location = new Point(107, 128);
            lblDoanhThuHomNay.Name = "lblDoanhThuHomNay";
            lblDoanhThuHomNay.Size = new Size(255, 41);
            lblDoanhThuHomNay.TabIndex = 0;
            lblDoanhThuHomNay.Text = "doanhthuhomnay";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1180, 54);
            label5.Name = "label5";
            label5.Size = new Size(124, 41);
            label5.TabIndex = 0;
            label5.Text = "Bàn Bận";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(577, 54);
            label3.Name = "label3";
            label3.Size = new Size(136, 41);
            label3.TabIndex = 0;
            label3.Text = "Hoá Đơn";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 54);
            label1.Name = "label1";
            label1.Size = new Size(158, 41);
            label1.TabIndex = 0;
            label1.Text = "Doanh thu";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Controls.Add(dgvNhanVien);
            tabPage2.Location = new Point(10, 58);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1388, 967);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Quản Lý Nhân Viên";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cboVaiTro);
            groupBox4.Controls.Add(chkTrangThai);
            groupBox4.Controls.Add(dtpNgayVaoLam);
            groupBox4.Controls.Add(txtMatKhau);
            groupBox4.Controls.Add(txtTenDN);
            groupBox4.Controls.Add(txtEmail);
            groupBox4.Controls.Add(txtSDT);
            groupBox4.Controls.Add(txtHoTen);
            groupBox4.Controls.Add(btnXoa);
            groupBox4.Controls.Add(btnLuu);
            groupBox4.Controls.Add(btnThemMoi);
            groupBox4.Controls.Add(btnDatLaiMatKhau);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label2);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(3, 303);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1382, 661);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Chi Tiết Nhân Viên";
            // 
            // cboVaiTro
            // 
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Location = new Point(866, 216);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(302, 49);
            cboVaiTro.TabIndex = 5;
            // 
            // chkTrangThai
            // 
            chkTrangThai.AutoSize = true;
            chkTrangThai.Location = new Point(718, 290);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(225, 45);
            chkTrangThai.TabIndex = 4;
            chkTrangThai.Text = "Còn làm việc";
            chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // dtpNgayVaoLam
            // 
            dtpNgayVaoLam.Location = new Point(166, 258);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(500, 47);
            dtpNgayVaoLam.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(866, 153);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(250, 47);
            txtMatKhau.TabIndex = 2;
            // 
            // txtTenDN
            // 
            txtTenDN.Location = new Point(866, 98);
            txtTenDN.Name = "txtTenDN";
            txtTenDN.Size = new Size(250, 47);
            txtTenDN.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(166, 194);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 47);
            txtEmail.TabIndex = 2;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(166, 132);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(250, 47);
            txtSDT.TabIndex = 2;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(166, 67);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(250, 47);
            txtHoTen.TabIndex = 2;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(428, 374);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(188, 58);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(194, 374);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(188, 58);
            btnLuu.TabIndex = 1;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThemMoi
            // 
            btnThemMoi.Location = new Point(0, 374);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(188, 58);
            btnThemMoi.TabIndex = 1;
            btnThemMoi.Text = "Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = true;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // btnDatLaiMatKhau
            // 
            btnDatLaiMatKhau.Location = new Point(1143, 153);
            btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            btnDatLaiMatKhau.Size = new Size(242, 47);
            btnDatLaiMatKhau.TabIndex = 1;
            btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            btnDatLaiMatKhau.UseVisualStyleBackColor = true;
            btnDatLaiMatKhau.Click += btnDatLaiMatKhau_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(705, 224);
            label10.Name = "label10";
            label10.Size = new Size(113, 41);
            label10.TabIndex = 0;
            label10.Text = "Vai Trò:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(705, 167);
            label9.Name = "label9";
            label9.Size = new Size(149, 41);
            label9.TabIndex = 0;
            label9.Text = "Mật khẩu:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(705, 106);
            label8.Name = "label8";
            label8.Size = new Size(122, 41);
            label8.TabIndex = 0;
            label8.Text = "Tên ĐN:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(-1, 264);
            label7.Name = "label7";
            label7.Size = new Size(129, 41);
            label7.TabIndex = 0;
            label7.Text = "Ngày VL";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-3, 200);
            label6.Name = "label6";
            label6.Size = new Size(95, 41);
            label6.TabIndex = 0;
            label6.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(0, 135);
            label4.Name = "label4";
            label4.Size = new Size(78, 41);
            label4.TabIndex = 0;
            label4.Text = "SĐT:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(-3, 67);
            label2.Name = "label2";
            label2.Size = new Size(123, 41);
            label2.TabIndex = 0;
            label2.Text = "Họ tên: ";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Top;
            dgvNhanVien.Location = new Point(3, 3);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 102;
            dgvNhanVien.Size = new Size(1382, 300);
            dgvNhanVien.TabIndex = 0;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox5);
            tabPage3.Controls.Add(dgvMonAn);
            tabPage3.Controls.Add(btnQuanLyDanhMuc);
            tabPage3.Controls.Add(cboDanhMuc);
            tabPage3.Controls.Add(label11);
            tabPage3.Location = new Point(10, 58);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1388, 967);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Quản Lý Thực Đơn";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(chkHoatDong);
            groupBox5.Controls.Add(numDonGia);
            groupBox5.Controls.Add(btnXoaMon);
            groupBox5.Controls.Add(btnLuuMon);
            groupBox5.Controls.Add(btnThemMoiMon);
            groupBox5.Controls.Add(txtTenMon);
            groupBox5.Controls.Add(lbl12);
            groupBox5.Controls.Add(lbl11);
            groupBox5.Dock = DockStyle.Bottom;
            groupBox5.Location = new Point(3, 582);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1382, 382);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Gồm chi tiết món";
            // 
            // chkHoatDong
            // 
            chkHoatDong.AutoSize = true;
            chkHoatDong.Location = new Point(40, 232);
            chkHoatDong.Name = "chkHoatDong";
            chkHoatDong.Size = new Size(167, 45);
            chkHoatDong.TabIndex = 3;
            chkHoatDong.Text = "Còn Bán";
            chkHoatDong.UseVisualStyleBackColor = true;
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(269, 158);
            numDonGia.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(300, 47);
            numDonGia.TabIndex = 2;
            numDonGia.ThousandsSeparator = true;
            // 
            // btnXoaMon
            // 
            btnXoaMon.Location = new Point(561, 307);
            btnXoaMon.Name = "btnXoaMon";
            btnXoaMon.Size = new Size(188, 58);
            btnXoaMon.TabIndex = 2;
            btnXoaMon.Text = "Xoá món";
            btnXoaMon.UseVisualStyleBackColor = true;
            btnXoaMon.Click += btnXoaMon_Click;
            // 
            // btnLuuMon
            // 
            btnLuuMon.Location = new Point(292, 307);
            btnLuuMon.Name = "btnLuuMon";
            btnLuuMon.Size = new Size(188, 58);
            btnLuuMon.TabIndex = 2;
            btnLuuMon.Text = "Lưu thay đổi";
            btnLuuMon.UseVisualStyleBackColor = true;
            btnLuuMon.Click += btnLuuMon_Click;
            // 
            // btnThemMoiMon
            // 
            btnThemMoiMon.Location = new Point(6, 307);
            btnThemMoiMon.Name = "btnThemMoiMon";
            btnThemMoiMon.Size = new Size(250, 58);
            btnThemMoiMon.TabIndex = 2;
            btnThemMoiMon.Text = "Thêm món mới";
            btnThemMoiMon.UseVisualStyleBackColor = true;
            btnThemMoiMon.Click += btnThemMoiMon_Click;
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(266, 76);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(250, 47);
            txtTenMon.TabIndex = 1;
            // 
            // lbl12
            // 
            lbl12.AutoSize = true;
            lbl12.Location = new Point(37, 150);
            lbl12.Name = "lbl12";
            lbl12.Size = new Size(125, 41);
            lbl12.TabIndex = 0;
            lbl12.Text = "Đơn Giá";
            // 
            // lbl11
            // 
            lbl11.AutoSize = true;
            lbl11.Location = new Point(37, 76);
            lbl11.Name = "lbl11";
            lbl11.Size = new Size(140, 41);
            lbl11.TabIndex = 0;
            lbl11.Text = "Tên món:";
            // 
            // dgvMonAn
            // 
            dgvMonAn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMonAn.Dock = DockStyle.Fill;
            dgvMonAn.Location = new Point(3, 151);
            dgvMonAn.Name = "dgvMonAn";
            dgvMonAn.RowHeadersWidth = 102;
            dgvMonAn.Size = new Size(1382, 813);
            dgvMonAn.TabIndex = 3;
            dgvMonAn.CellClick += dgvMonAn_CellClick;
            // 
            // btnQuanLyDanhMuc
            // 
            btnQuanLyDanhMuc.Dock = DockStyle.Top;
            btnQuanLyDanhMuc.Location = new Point(3, 93);
            btnQuanLyDanhMuc.Name = "btnQuanLyDanhMuc";
            btnQuanLyDanhMuc.Size = new Size(1382, 58);
            btnQuanLyDanhMuc.TabIndex = 2;
            btnQuanLyDanhMuc.Text = "Quản lí danh mục";
            btnQuanLyDanhMuc.UseVisualStyleBackColor = true;
            btnQuanLyDanhMuc.Click += btnQuanLyDanhMuc_Click;
            // 
            // cboDanhMuc
            // 
            cboDanhMuc.Dock = DockStyle.Top;
            cboDanhMuc.FormattingEnabled = true;
            cboDanhMuc.Location = new Point(3, 44);
            cboDanhMuc.Name = "cboDanhMuc";
            cboDanhMuc.Size = new Size(1382, 49);
            cboDanhMuc.TabIndex = 1;
            cboDanhMuc.SelectedIndexChanged += cboDanhMuc_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Top;
            label11.Location = new Point(3, 3);
            label11.Name = "label11";
            label11.Size = new Size(236, 41);
            label11.TabIndex = 0;
            label11.Text = "Chọn danh mục:";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1408, 1035);
            Controls.Add(tabControl1);
            Name = "AdminForm";
            Text = "admin";
            Load += AdminForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMonBanChay).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label lblBanCoKhach;
        private Label lblTongHoaDon;
        private Label lblDoanhThuHomNay;
        private Label label5;
        private Label label3;
        private Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private DataGridView dgvMonBanChay;
        private DataGridView dgvNhanVien;
        private GroupBox groupBox4;
        private Button btnDatLaiMatKhau;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label2;
        private ComboBox cboVaiTro;
        private CheckBox chkTrangThai;
        private DateTimePicker dtpNgayVaoLam;
        private TextBox txtMatKhau;
        private TextBox txtTenDN;
        private TextBox txtEmail;
        private TextBox txtSDT;
        private TextBox txtHoTen;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnThemMoi;
        private TabPage tabPage3;
        private GroupBox groupBox5;
        private NumericUpDown numDonGia;
        private TextBox txtTenMon;
        private Label lbl12;
        private Label lbl11;
        private DataGridView dgvMonAn;
        private Button btnQuanLyDanhMuc;
        private ComboBox cboDanhMuc;
        private Label label11;
        private CheckBox chkHoatDong;
        private Button btnXoaMon;
        private Button btnLuuMon;
        private Button btnThemMoiMon;
    }
}