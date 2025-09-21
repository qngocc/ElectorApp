using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace ElectorApp.Auth
{
    partial class DangKy
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
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKy));
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            backgrPanel = new Panel();
            showmessage = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            viewPass = new CheckBox();
            btnRegister = new Button();
            txtFullName = new TextBox();
            label3 = new Label();
            backgrPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblUsername.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(334, 113);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(120, 25);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tài khoản:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F);
            txtUsername.Location = new Point(460, 113);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 34);
            txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.FromArgb(0, 0, 0, 0);
            lblPassword.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            lblPassword.Location = new Point(334, 240);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(119, 25);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(460, 234);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(300, 34);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.Location = new Point(460, 392);
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
            label2.Location = new Point(479, 45);
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
            backgrPanel.Size = new Size(1178, 40);
            backgrPanel.TabIndex = 7;
            backgrPanel.Visible = false;
            // 
            // showmessage
            // 
            showmessage.AutoSize = true;
            showmessage.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            showmessage.ForeColor = SystemColors.ButtonHighlight;
            showmessage.Location = new Point(479, 7);
            showmessage.Name = "showmessage";
            showmessage.Size = new Size(60, 23);
            showmessage.TabIndex = 0;
            showmessage.Text = "label3";
            showmessage.Visible = false;
            // 
            // viewPass
            // 
            viewPass.AutoSize = true;
            viewPass.BackColor = Color.FromArgb(0, 0, 0, 0);
            viewPass.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewPass.Location = new Point(460, 274);
            viewPass.Name = "viewPass";
            viewPass.Size = new Size(128, 23);
            viewPass.TabIndex = 8;
            viewPass.Text = "Hiện mật khẩu";
            viewPass.UseVisualStyleBackColor = false;
            viewPass.CheckedChanged += viewPass_CheckedChanged;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Blue;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = SystemColors.ButtonHighlight;
            btnRegister.Location = new Point(460, 328);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(300, 45);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Đăng kí";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 12F);
            txtFullName.Location = new Point(460, 172);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(300, 34);
            txtFullName.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label3.Location = new Point(347, 172);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 11;
            label3.Text = "Họ tên:";
            // 
            // DangKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background_6008188_960_720;
            ClientSize = new Size(1178, 517);
            Controls.Add(label3);
            Controls.Add(txtFullName);
            Controls.Add(btnRegister);
            Controls.Add(viewPass);
            Controls.Add(backgrPanel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1196, 564);
            MinimumSize = new Size(1196, 564);
            Name = "DangKy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            FormClosing += DangKy_FormClosing;
            Load += DangKy_Load;
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
        private Button btnRegister;
        private TextBox txtFullName;
        private Label label3;
    }
}