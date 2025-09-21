namespace ElectorApp.Users
{
    partial class KetQua
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KetQua));
            lbtenbaucu = new Label();
            label1 = new Label();
            pnKetqua = new Panel();
            label2 = new Label();
            lbsophieu = new Label();
            button1 = new Button();
            cmbFilter = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // lbtenbaucu
            // 
            lbtenbaucu.AutoSize = true;
            lbtenbaucu.BackColor = Color.FromArgb(0, 0, 0, 0);
            lbtenbaucu.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbtenbaucu.Location = new Point(157, 24);
            lbtenbaucu.Name = "lbtenbaucu";
            lbtenbaucu.Size = new Size(144, 32);
            lbtenbaucu.TabIndex = 0;
            lbtenbaucu.Text = "Tên bầu cử";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Purple;
            label1.Location = new Point(39, 24);
            label1.Name = "label1";
            label1.Size = new Size(112, 32);
            label1.TabIndex = 1;
            label1.Text = "Kết quả:";
            // 
            // pnKetqua
            // 
            pnKetqua.BackColor = SystemColors.Window;
            pnKetqua.Location = new Point(39, 190);
            pnKetqua.Name = "pnKetqua";
            pnKetqua.Size = new Size(805, 335);
            pnKetqua.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Maroon;
            label2.Location = new Point(39, 88);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 4;
            label2.Text = "Tống số phiếu: ";
            // 
            // lbsophieu
            // 
            lbsophieu.AutoSize = true;
            lbsophieu.BackColor = Color.FromArgb(0, 0, 0, 0);
            lbsophieu.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbsophieu.Location = new Point(157, 88);
            lbsophieu.Name = "lbsophieu";
            lbsophieu.Size = new Size(77, 20);
            lbsophieu.TabIndex = 5;
            lbsophieu.Text = "Số phiếu";
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(378, 531);
            button1.Name = "button1";
            button1.Size = new Size(137, 42);
            button1.TabIndex = 6;
            button1.Text = "Về trang chủ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(643, 156);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(201, 28);
            cmbFilter.TabIndex = 7;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);
            label3.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkBlue;
            label3.Location = new Point(531, 160);
            label3.Name = "label3";
            label3.Size = new Size(106, 19);
            label3.TabIndex = 8;
            label3.Text = "Sắp xếp theo:";
            // 
            // KetQua
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_6008188_960_720;
            ClientSize = new Size(882, 614);
            Controls.Add(label3);
            Controls.Add(cmbFilter);
            Controls.Add(button1);
            Controls.Add(lbsophieu);
            Controls.Add(label2);
            Controls.Add(pnKetqua);
            Controls.Add(label1);
            Controls.Add(lbtenbaucu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(900, 661);
            MinimumSize = new Size(900, 661);
            Name = "KetQua";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kết Quả Bầu Cử";
            FormClosing += KetQua_FormClosing;
            Load += KetQua_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbtenbaucu;
        private Label label1;
        private Panel pnKetqua;
        private Label label2;
        private Label lbsophieu;
        private Button button1;
        private ComboBox cmbFilter;
        private Label label3;
    }
}