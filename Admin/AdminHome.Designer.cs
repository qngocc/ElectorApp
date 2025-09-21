namespace ElectorApp.Admin
{
    partial class AdminHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminHome));
            label1 = new Label();
            dataGridView1 = new DataGridView();
            btncreate = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnremove = new Button();
            btnlock = new Button();
            btnresutl = new Button();
            label2 = new Label();
            button1 = new Button();
            btnload = new Button();
            lb1 = new Label();
            lbAdminName = new Label();
            btnupdate = new Button();
            lbshowmessage = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(366, 9);
            label1.Name = "label1";
            label1.Size = new Size(455, 32);
            label1.TabIndex = 0;
            label1.Text = "Quản trị các cuộc bình chọn , bầu cử";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(127, 168);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(920, 268);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btncreate
            // 
            btncreate.BackColor = Color.Lime;
            btncreate.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncreate.ForeColor = Color.Black;
            btncreate.Location = new Point(235, 456);
            btncreate.Name = "btncreate";
            btncreate.Size = new Size(97, 38);
            btncreate.TabIndex = 3;
            btncreate.Text = "Tạo ";
            btncreate.UseVisualStyleBackColor = false;
            btncreate.Click += btncreate_Click;
            // 
            // btnremove
            // 
            btnremove.BackColor = Color.FromArgb(192, 0, 0);
            btnremove.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnremove.ForeColor = Color.White;
            btnremove.Location = new Point(854, 456);
            btnremove.Name = "btnremove";
            btnremove.Size = new Size(97, 38);
            btnremove.TabIndex = 4;
            btnremove.Text = "Xóa";
            btnremove.UseVisualStyleBackColor = false;
            btnremove.Click += btnremove_Click;
            // 
            // btnlock
            // 
            btnlock.BackColor = Color.Yellow;
            btnlock.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlock.ForeColor = Color.Black;
            btnlock.Location = new Point(733, 456);
            btnlock.Name = "btnlock";
            btnlock.Size = new Size(97, 38);
            btnlock.TabIndex = 5;
            btnlock.Text = "Khóa ";
            btnlock.UseVisualStyleBackColor = false;
            btnlock.Click += btnlock_Click;
            // 
            // btnresutl
            // 
            btnresutl.BackColor = Color.FromArgb(255, 128, 0);
            btnresutl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnresutl.ForeColor = Color.Black;
            btnresutl.Location = new Point(554, 456);
            btnresutl.Name = "btnresutl";
            btnresutl.Size = new Size(97, 38);
            btnresutl.TabIndex = 6;
            btnresutl.Text = "Kết quả";
            btnresutl.UseVisualStyleBackColor = false;
            btnresutl.Click += btnresutl_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(127, 142);
            label2.Name = "label2";
            label2.Size = new Size(294, 23);
            label2.TabIndex = 7;
            label2.Text = "Các cuộc bình chọn, bầu cử đã tạo";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 0, 0);
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(1053, 12);
            button1.Name = "button1";
            button1.Size = new Size(111, 38);
            button1.TabIndex = 8;
            button1.Text = "Đăng xuất";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnload
            // 
            btnload.BackColor = Color.FromArgb(128, 255, 128);
            btnload.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnload.ForeColor = Color.Black;
            btnload.Location = new Point(936, 12);
            btnload.Name = "btnload";
            btnload.Size = new Size(111, 38);
            btnload.TabIndex = 9;
            btnload.Text = "Làm mới";
            btnload.UseVisualStyleBackColor = false;
            btnload.Click += btnload_Click;
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.BackColor = Color.FromArgb(0, 0, 0, 0);
            lb1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lb1.Location = new Point(12, 9);
            lb1.Name = "lb1";
            lb1.Size = new Size(111, 21);
            lb1.TabIndex = 10;
            lb1.Text = "Chào mừng: ";
            // 
            // lbAdminName
            // 
            lbAdminName.AutoSize = true;
            lbAdminName.BackColor = Color.FromArgb(0, 0, 0, 0);
            lbAdminName.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbAdminName.ForeColor = Color.FromArgb(192, 0, 192);
            lbAdminName.Location = new Point(119, 9);
            lbAdminName.Name = "lbAdminName";
            lbAdminName.Size = new Size(56, 20);
            lbAdminName.TabIndex = 11;
            lbAdminName.Text = "Admin";
            // 
            // btnupdate
            // 
            btnupdate.BackColor = Color.DeepSkyBlue;
            btnupdate.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnupdate.ForeColor = Color.Black;
            btnupdate.Location = new Point(357, 456);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(97, 38);
            btnupdate.TabIndex = 12;
            btnupdate.Text = "Cập nhật";
            btnupdate.UseVisualStyleBackColor = false;
            btnupdate.Click += btnupdate_Click;
            // 
            // lbshowmessage
            // 
            lbshowmessage.AutoSize = true;
            lbshowmessage.BackColor = Color.FromArgb(192, 0, 0);
            lbshowmessage.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbshowmessage.ForeColor = Color.White;
            lbshowmessage.Location = new Point(382, 79);
            lbshowmessage.Name = "lbshowmessage";
            lbshowmessage.Size = new Size(99, 23);
            lbshowmessage.TabIndex = 13;
            lbshowmessage.Text = "Thong bao";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tất cả", "Đang diễn ra", "Đã khóa", "Chưa bắt đầu", "Đã kết thúc", "Mới tạo", "A-Z", "Z-A" });
            comboBox1.Location = new Point(898, 134);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 14;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);
            label3.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(854, 137);
            label3.Name = "label3";
            label3.Size = new Size(38, 21);
            label3.TabIndex = 15;
            label3.Text = "Lọc";
            // 
            // AdminHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_6008188_960_720;
            ClientSize = new Size(1178, 517);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(lbshowmessage);
            Controls.Add(btnupdate);
            Controls.Add(lbAdminName);
            Controls.Add(lb1);
            Controls.Add(btnload);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(btnresutl);
            Controls.Add(btnlock);
            Controls.Add(btnremove);
            Controls.Add(btncreate);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1196, 564);
            MinimumSize = new Size(1196, 564);
            Name = "AdminHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminHome";
            FormClosing += AdminHome_FormClosing;
            Load += AdminHome_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Button btncreate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnremove;
        private Button btnlock;
        private Button btnresutl;
        private Label label2;
        private Button button1;
        private Button btnload;
        private Label lb1;
        private Label lbAdminName;
        private Button btnupdate;
        private Label lbshowmessage;
        private ComboBox comboBox1;
        private Label label3;
    }
}