using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace ElectorApp.Auth
{
    partial class DangNhap
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

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            backgrPanel = new Panel();
            showmessage = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            viewPass = new CheckBox();
            button1 = new Button();
            txtPassword = new TextBox();
            cbkeeplogin = new CheckBox();
            backgrPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblUsername.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            lblUsername.Location = new Point(326, 141);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(120, 25);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tài khoản:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(452, 132);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 34);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblPassword.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            lblPassword.Location = new Point(326, 208);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(119, 25);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.Location = new Point(452, 323);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 45);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(569, 96);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(469, 58);
            label2.Name = "label2";
            label2.Size = new Size(262, 38);
            label2.TabIndex = 6;
            label2.Text = "Elector Manager";
            // 
            // backgrPanel
            // 
            backgrPanel.BackColor = Color.DarkRed;
            backgrPanel.Controls.Add(showmessage);
            backgrPanel.ForeColor = Color.Red;
            backgrPanel.Location = new Point(0, 2);
            backgrPanel.Name = "backgrPanel";
            backgrPanel.Size = new Size(1178, 49);
            backgrPanel.TabIndex = 7;
            backgrPanel.Visible = false;
            backgrPanel.Paint += backgrPanel_Paint;
            // 
            // showmessage
            // 
            showmessage.AutoSize = true;
            showmessage.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            showmessage.ForeColor = SystemColors.ButtonHighlight;
            showmessage.Location = new Point(375, 7);
            showmessage.Name = "showmessage";
            showmessage.Size = new Size(60, 23);
            showmessage.TabIndex = 0;
            showmessage.Text = "label3";
            showmessage.Visible = false;
            showmessage.Click += showmessage_Click;
            // 
            // viewPass
            // 
            viewPass.AutoSize = true;
            viewPass.BackColor = Color.FromArgb(0, 0, 0, 0);
            viewPass.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewPass.Location = new Point(452, 242);
            viewPass.Name = "viewPass";
            viewPass.Size = new Size(128, 23);
            viewPass.TabIndex = 8;
            viewPass.Text = "Hiện mật khẩu";
            viewPass.UseVisualStyleBackColor = false;
            viewPass.CheckedChanged += viewPass_CheckedChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(452, 388);
            button1.Name = "button1";
            button1.Size = new Size(300, 45);
            button1.TabIndex = 9;
            button1.Text = "Đăng kí";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(451, 202);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(300, 34);
            txtPassword.TabIndex = 10;
            // 
            // cbkeeplogin
            // 
            cbkeeplogin.AutoSize = true;
            cbkeeplogin.BackColor = Color.FromArgb(0, 0, 0, 0);
            cbkeeplogin.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbkeeplogin.Location = new Point(452, 272);
            cbkeeplogin.Name = "cbkeeplogin";
            cbkeeplogin.Size = new Size(108, 23);
            cbkeeplogin.TabIndex = 11;
            cbkeeplogin.Text = "Ghi nhớ tôi";
            cbkeeplogin.UseVisualStyleBackColor = false;
            cbkeeplogin.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_6008188_960_720;
            ClientSize = new Size(1178, 517);
            Controls.Add(cbkeeplogin);
            Controls.Add(txtPassword);
            Controls.Add(button1);
            Controls.Add(viewPass);
            Controls.Add(backgrPanel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1196, 564);
            MinimumSize = new Size(1196, 564);
            Name = "DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosing += DangNhap_FormClosing;
            Load += DangNhap_Load;
            backgrPanel.ResumeLayout(false);
            backgrPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel backgrPanel;
        private Label showmessage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CheckBox viewPass;
        private Button button1;
        private TextBox txtPassword;
        private CheckBox cbkeeplogin;
    }
}
