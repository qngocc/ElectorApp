namespace ElectorApp.Users
{
    partial class UserHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserHome));
            label1 = new Label();
            txtUserName = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            btnThamGiaBau = new Button();
            btnXemKetQua = new Button();
            comboBox1 = new ComboBox();
            label4 = new Label();
            lbshowmessage = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 0;
            label1.Text = "Chào mừng:";
            // 
            // txtUserName
            // 
            txtUserName.AutoSize = true;
            txtUserName.BackColor = Color.FromArgb(0, 0, 0, 0);
            txtUserName.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUserName.ForeColor = Color.MediumSlateBlue;
            txtUserName.Location = new Point(124, 9);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(83, 20);
            txtUserName.TabIndex = 1;
            txtUserName.Text = "username";
            txtUserName.Click += txtUserName_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.Location = new Point(80, 132);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1011, 300);
            dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(370, 9);
            label2.Name = "label2";
            label2.Size = new Size(440, 32);
            label2.TabIndex = 3;
            label2.Text = "Hệ thống quản lí bình chọn, bầu cử";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(80, 100);
            label3.Name = "label3";
            label3.Size = new Size(242, 23);
            label3.TabIndex = 4;
            label3.Text = "Các cuộc bình chọn , bầu cử";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 0, 0);
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1072, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 38);
            button1.TabIndex = 5;
            button1.Text = "Đăng xuất";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 255, 128);
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(972, 12);
            button2.Name = "button2";
            button2.Size = new Size(94, 38);
            button2.TabIndex = 6;
            button2.Text = "Làm mới";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnThamGiaBau
            // 
            btnThamGiaBau.BackColor = Color.Blue;
            btnThamGiaBau.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThamGiaBau.ForeColor = Color.White;
            btnThamGiaBau.Location = new Point(440, 448);
            btnThamGiaBau.Name = "btnThamGiaBau";
            btnThamGiaBau.Size = new Size(120, 40);
            btnThamGiaBau.TabIndex = 7;
            btnThamGiaBau.Text = "Tham gia bầu";
            btnThamGiaBau.UseVisualStyleBackColor = false;
            btnThamGiaBau.Click += btnThamGiaBau_Click;
            // 
            // btnXemKetQua
            // 
            btnXemKetQua.BackColor = Color.Orange;
            btnXemKetQua.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXemKetQua.ForeColor = Color.Black;
            btnXemKetQua.Location = new Point(596, 448);
            btnXemKetQua.Name = "btnXemKetQua";
            btnXemKetQua.Size = new Size(120, 40);
            btnXemKetQua.TabIndex = 8;
            btnXemKetQua.Text = "Xem kết quả";
            btnXemKetQua.UseVisualStyleBackColor = false;
            btnXemKetQua.Click += xemKetquua;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Đã tham gia", "Chưa tham gia", "Đã kết thúc", "Đang diễn ra", "Đã khóa", "Mới nhất", "Chưa bắt đầu" });
            comboBox1.Location = new Point(940, 99);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 0, 0);
            label4.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(896, 102);
            label4.Name = "label4";
            label4.Size = new Size(38, 21);
            label4.TabIndex = 10;
            label4.Text = "Lọc";
            // 
            // lbshowmessage
            // 
            lbshowmessage.AutoSize = true;
            lbshowmessage.BackColor = Color.FromArgb(192, 0, 0);
            lbshowmessage.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbshowmessage.ForeColor = SystemColors.ButtonHighlight;
            lbshowmessage.Location = new Point(391, 67);
            lbshowmessage.Name = "lbshowmessage";
            lbshowmessage.Size = new Size(61, 23);
            lbshowmessage.TabIndex = 11;
            lbshowmessage.Text = "label5";
            lbshowmessage.Click += label5_Click;
            // 
            // UserHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_6008188_960_720;
            ClientSize = new Size(1178, 517);
            Controls.Add(lbshowmessage);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(btnXemKetQua);
            Controls.Add(btnThamGiaBau);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(txtUserName);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1196, 564);
            MinimumSize = new Size(1196, 564);
            Name = "UserHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserHome";
            FormClosing += UserHome_FormClosing;
            Load += UserHome_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label txtUserName;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button btnThamGiaBau;
        private Button btnXemKetQua;
        private ComboBox comboBox1;
        private Label label4;
        private Label lbshowmessage;
    }
}