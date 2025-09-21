namespace ElectorApp.Users
{
    partial class ThamGiaBauCu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThamGiaBauCu));
            button1 = new Button();
            button2 = new Button();
            lbtenbaucu = new Label();
            lbmota = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(290, 539);
            button1.Name = "button1";
            button1.Size = new Size(116, 42);
            button1.TabIndex = 1;
            button1.Text = "Bỏ phiếu ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.AliceBlue;
            button2.Location = new Point(450, 539);
            button2.Name = "button2";
            button2.Size = new Size(167, 42);
            button2.TabIndex = 2;
            button2.Text = "Về trang chủ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // lbtenbaucu
            // 
            lbtenbaucu.AutoSize = true;
            lbtenbaucu.BackColor = Color.FromArgb(0, 0, 0, 0);
            lbtenbaucu.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbtenbaucu.ForeColor = Color.Blue;
            lbtenbaucu.Location = new Point(233, 9);
            lbtenbaucu.Name = "lbtenbaucu";
            lbtenbaucu.Size = new Size(257, 38);
            lbtenbaucu.TabIndex = 3;
            lbtenbaucu.Text = "Tên cuộc bầu cử";
            // 
            // lbmota
            // 
            lbmota.AutoSize = true;
            lbmota.BackColor = Color.FromArgb(0, 0, 0, 0);
            lbmota.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbmota.ForeColor = Color.DarkCyan;
            lbmota.Location = new Point(219, 83);
            lbmota.Name = "lbmota";
            lbmota.Size = new Size(59, 23);
            lbmota.TabIndex = 4;
            lbmota.Text = "Mô tả";
            lbmota.Click += lbmota_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Location = new Point(59, 156);
            panel1.Name = "panel1";
            panel1.Size = new Size(774, 350);
            panel1.TabIndex = 5;
            // 
            // ThamGiaBauCu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_6008188_960_720;
            ClientSize = new Size(882, 614);
            Controls.Add(panel1);
            Controls.Add(lbmota);
            Controls.Add(lbtenbaucu);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MaximumSize = new Size(900, 661);
            MinimumSize = new Size(900, 661);
            Name = "ThamGiaBauCu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tham Gia Bầu Cử";
            FormClosing += ThamGiaBauCu_FormClosing;
            Load += ThamGiaBauCu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private Label lbtenbaucu;
        private Label lbmota;
        private Panel panel1;
    }
}