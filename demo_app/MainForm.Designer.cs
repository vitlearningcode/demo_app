namespace demo_app
{
    partial class MainForm
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
            label1 = new Label();
            flpTable = new FlowLayoutPanel();
            lvBill = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            lblTotalPrice = new Label();
            groupBox1 = new GroupBox();
            btnAddFood = new Button();
            numQuantity = new NumericUpDown();
            cbFood = new ComboBox();
            cbCategory = new ComboBox();
            groupBox2 = new GroupBox();
            btnPay = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(827, 40);
            label1.Name = "label1";
            label1.Size = new Size(183, 41);
            label1.TabIndex = 0;
            label1.Text = "Chào mừng!";
            label1.Click += label1_Click;
            // 
            // flpTable
            // 
            flpTable.AutoScroll = true;
            flpTable.Dock = DockStyle.Left;
            flpTable.Location = new Point(0, 0);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(247, 864);
            flpTable.TabIndex = 1;
            // 
            // lvBill
            // 
            lvBill.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvBill.GridLines = true;
            lvBill.Location = new Point(312, 152);
            lvBill.Name = "lvBill";
            lvBill.Size = new Size(602, 366);
            lvBill.TabIndex = 2;
            lvBill.UseCompatibleStateImageBehavior = false;
            lvBill.View = View.Details;
            lvBill.SelectedIndexChanged += lvBill_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Tên món";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Số Lượng";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Đơn giá";
            columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Thành tiền";
            columnHeader4.Width = 170;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Location = new Point(864, 542);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(34, 41);
            lblTotalPrice.TabIndex = 3;
            lblTotalPrice.Text = "0";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddFood);
            groupBox1.Controls.Add(numQuantity);
            groupBox1.Controls.Add(cbFood);
            groupBox1.Controls.Add(cbCategory);
            groupBox1.Location = new Point(981, 182);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 401);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thêm món";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(291, 323);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(188, 58);
            btnAddFood.TabIndex = 3;
            btnAddFood.Text = "Thêm món";
            btnAddFood.UseVisualStyleBackColor = true;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(64, 245);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(300, 47);
            numQuantity.TabIndex = 2;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cbFood
            // 
            cbFood.FormattingEnabled = true;
            cbFood.Location = new Point(56, 147);
            cbFood.Name = "cbFood";
            cbFood.Size = new Size(302, 49);
            cbFood.TabIndex = 1;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(56, 70);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(302, 49);
            cbCategory.TabIndex = 0;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnPay);
            groupBox2.Location = new Point(981, 602);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(500, 250);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chức năng";
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.DeepSkyBlue;
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(291, 154);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(188, 58);
            btnPay.TabIndex = 0;
            btnPay.Text = "Thanh toán";
            btnPay.UseVisualStyleBackColor = false;
            btnPay.Click += btnPay_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1516, 864);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblTotalPrice);
            Controls.Add(lvBill);
            Controls.Add(flpTable);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flpTable;
        private ListView lvBill;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label lblTotalPrice;
        private GroupBox groupBox1;
        private NumericUpDown numQuantity;
        private ComboBox cbFood;
        private ComboBox cbCategory;
        private Button btnAddFood;
        private GroupBox groupBox2;
        private Button btnPay;
    }
}