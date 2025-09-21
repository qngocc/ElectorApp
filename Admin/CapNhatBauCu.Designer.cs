namespace ElectorApp.Forms
{
    partial class CapNhatBauCu
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
            label1 = new Label();
            txtTenBauCu = new TextBox();
            label2 = new Label();
            label3 = new Label();
            dtpNgayBatDau = new DateTimePicker();
            label4 = new Label();
            dtpNgayKetThuc = new DateTimePicker();
            btnCapNhat = new Button();
            btnHuy = new Button();
            txtMoTa = new TextBox();
            label5 = new Label();
            label6 = new Label();
            txtLuaChon = new TextBox();
            btnThemLuaChon = new Button();
            btnXoaLuaChon = new Button();
            lstbLuaChon = new ListBox();
            lbshowmessage = new Label();
            numericUpDown1 = new NumericUpDown();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 95);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(186, 25);
            label1.TabIndex = 0;
            label1.Text = "Tên cuộc bầu cử:";
            // 
            // txtTenBauCu
            // 
            txtTenBauCu.Font = new Font("Segoe UI", 11F);
            txtTenBauCu.Location = new Point(217, 92);
            txtTenBauCu.Margin = new Padding(4, 5, 4, 5);
            txtTenBauCu.Name = "txtTenBauCu";
            txtTenBauCu.Size = new Size(615, 32);
            txtTenBauCu.TabIndex = 1;
            txtTenBauCu.TextChanged += txtTenBauCu_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(39, 173);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 2;
            label2.Text = "Mô tả:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label3.Location = new Point(23, 273);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(155, 25);
            label3.TabIndex = 4;
            label3.Text = "Ngày bắt đầu:";
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayBatDau.Font = new Font("Segoe UI", 11F);
            dtpNgayBatDau.Format = DateTimePickerFormat.Custom;
            dtpNgayBatDau.Location = new Point(217, 269);
            dtpNgayBatDau.Margin = new Padding(4, 5, 4, 5);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(615, 32);
            dtpNgayBatDau.TabIndex = 5;
            dtpNgayBatDau.ValueChanged += dtpNgayBatDau_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label4.Location = new Point(23, 332);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(160, 25);
            label4.TabIndex = 6;
            label4.Text = "Ngày kết thúc:";
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayKetThuc.Font = new Font("Segoe UI", 11F);
            dtpNgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtpNgayKetThuc.Location = new Point(217, 332);
            dtpNgayKetThuc.Margin = new Padding(4, 5, 4, 5);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(615, 32);
            dtpNgayKetThuc.TabIndex = 7;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.Orange;
            btnCapNhat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.Location = new Point(313, 620);
            btnCapNhat.Margin = new Padding(4, 5, 4, 5);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(120, 45);
            btnCapNhat.TabIndex = 8;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Gray;
            btnHuy.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(509, 620);
            btnHuy.Margin = new Padding(4, 5, 4, 5);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(120, 45);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // txtMoTa
            // 
            txtMoTa.Font = new Font("Segoe UI", 11F);
            txtMoTa.Location = new Point(217, 134);
            txtMoTa.Margin = new Padding(4, 5, 4, 5);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(615, 125);
            txtMoTa.TabIndex = 3;
            txtMoTa.TextChanged += txtMoTa_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DarkOrange;
            label5.Location = new Point(325, 9);
            label5.Name = "label5";
            label5.Size = new Size(294, 35);
            label5.TabIndex = 10;
            label5.Text = "CẬP NHẬT BẦU CỬ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label6.Location = new Point(23, 372);
            label6.Name = "label6";
            label6.Size = new Size(116, 25);
            label6.TabIndex = 10;
            label6.Text = "Lựa chọn:";
            // 
            // txtLuaChon
            // 
            txtLuaChon.Font = new Font("Segoe UI", 11F);
            txtLuaChon.Location = new Point(217, 372);
            txtLuaChon.Name = "txtLuaChon";
            txtLuaChon.Size = new Size(429, 32);
            txtLuaChon.TabIndex = 11;
            // 
            // btnThemLuaChon
            // 
            btnThemLuaChon.BackColor = SystemColors.Highlight;
            btnThemLuaChon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemLuaChon.ForeColor = SystemColors.Control;
            btnThemLuaChon.Location = new Point(667, 372);
            btnThemLuaChon.Name = "btnThemLuaChon";
            btnThemLuaChon.Size = new Size(75, 32);
            btnThemLuaChon.TabIndex = 12;
            btnThemLuaChon.Text = "Thêm";
            btnThemLuaChon.UseVisualStyleBackColor = false;
            btnThemLuaChon.Click += btnThemLuaChon_Click;
            // 
            // btnXoaLuaChon
            // 
            btnXoaLuaChon.BackColor = Color.Red;
            btnXoaLuaChon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoaLuaChon.ForeColor = SystemColors.Control;
            btnXoaLuaChon.Location = new Point(757, 372);
            btnXoaLuaChon.Name = "btnXoaLuaChon";
            btnXoaLuaChon.Size = new Size(75, 32);
            btnXoaLuaChon.TabIndex = 13;
            btnXoaLuaChon.Text = "Xóa";
            btnXoaLuaChon.UseVisualStyleBackColor = false;
            btnXoaLuaChon.Click += btnXoaLuaChon_Click;
            // 
            // lstbLuaChon
            // 
            lstbLuaChon.Font = new Font("Segoe UI", 11F);
            lstbLuaChon.FormattingEnabled = true;
            lstbLuaChon.Location = new Point(217, 433);
            lstbLuaChon.Name = "lstbLuaChon";
            lstbLuaChon.Size = new Size(615, 129);
            lstbLuaChon.TabIndex = 14;
            // 
            // lbshowmessage
            // 
            lbshowmessage.AutoSize = true;
            lbshowmessage.BackColor = Color.FromArgb(192, 0, 0);
            lbshowmessage.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbshowmessage.ForeColor = SystemColors.ButtonHighlight;
            lbshowmessage.Location = new Point(268, 55);
            lbshowmessage.Name = "lbshowmessage";
            lbshowmessage.Size = new Size(92, 23);
            lbshowmessage.TabIndex = 15;
            lbshowmessage.Text = "Thong bao";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(217, 570);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(615, 27);
            numericUpDown1.TabIndex = 16;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label7.Location = new Point(23, 568);
            label7.Name = "label7";
            label7.Size = new Size(133, 25);
            label7.TabIndex = 17;
            label7.Text = "Đa lựa chọn";
            // 
            // CapNhatBauCu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(924, 690);
            Controls.Add(label7);
            Controls.Add(numericUpDown1);
            Controls.Add(lbshowmessage);
            Controls.Add(lstbLuaChon);
            Controls.Add(btnXoaLuaChon);
            Controls.Add(btnThemLuaChon);
            Controls.Add(txtLuaChon);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnHuy);
            Controls.Add(btnCapNhat);
            Controls.Add(dtpNgayKetThuc);
            Controls.Add(label4);
            Controls.Add(dtpNgayBatDau);
            Controls.Add(label3);
            Controls.Add(txtMoTa);
            Controls.Add(label2);
            Controls.Add(txtTenBauCu);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CapNhatBauCu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cập Nhật Cuộc Bầu Cử";
            FormClosing += CapNhatBauCu_FormClosing;
            Load += CapNhatBauCu_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTenBauCu;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpNgayBatDau;
        private Label label4;
        private DateTimePicker dtpNgayKetThuc;
        private Button btnCapNhat;
        private Button btnHuy;
        private TextBox txtMoTa;
        private Label label5;
        private Label label6;
        private TextBox txtLuaChon;
        private Button btnThemLuaChon;
        private Button btnXoaLuaChon;
        private ListBox lstbLuaChon;
        private Label lbshowmessage;
        private NumericUpDown numericUpDown1;
        private Label label7;
    }
}