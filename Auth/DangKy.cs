using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectorApp.Auth
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void viewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (viewPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }


        private async void showMessage(string message, Color color)
        {
            showmessage.Visible = true;
            backgrPanel.Visible = true;
            showmessage.Text = message;
            backgrPanel.BackColor = color;
            showmessage.Visible = true;

            await Task.Delay(3000); // Hiển thị thông báo trong 3 giây

            backgrPanel.Visible = false;
            showmessage.Visible = false;
            backgrPanel.BackColor = Color.DarkRed;
            showmessage.Text = "";
        }

        public int findUserId(string filePath)
        {
            int userId = 1; // mac dinh id la 1
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                if (lines.Length == 0) return 1; // neu file trong tra ve id la 1
                var lastLine = lines[lines.Length - 1];
                var parts = lastLine.Split(',');
                if (parts.Length >= 1 && int.Parse(parts[0]) >= userId)
                {
                    userId = int.Parse(parts[0]) + 1; // neu id lon hon thi tang len 1
                }
            }
            return userId;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string isAdmin = "False"; // de quyen mac dich la user
            string filePath = "data/user.txt"; // duong dan den file luu user ( bin/Debug/net9.0/user.txt )

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                showMessage("Vui lòng điền đầy đủ thông tin!", Color.DarkRed);
                return;
            }

            if (password.Length < 5)
            {
                showMessage("Mật khẩu phải có ít nhất 5 ký tự!", Color.DarkRed);
                return;
            }
            // su dung ki tu ',' de phan tach cac truong trong file txt nen khong duoc su dung ki tu nay de tranh loi trong qua trinh doc ghi file
            if (username.Contains(',') || password.Contains(',') || fullName.Contains(','))
            {
                showMessage("Thông tin không được chứa dấu phẩy!", Color.DarkRed);
                return;
            }
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2 && parts[0] == username)
                    {
                        showMessage("Tài khoản đã tồn tại!", Color.DarkRed);
                        return;
                    }
                }
                int userId = findUserId(filePath);

                File.AppendAllText(filePath, $"{userId},{username},{password},{fullName},{isAdmin}\n");
                showMessage("Đăng ký thành công!", Color.Green);
            }
            else
            {
                showMessage("File user.txt không tồn tại!", Color.DarkRed);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap loginForm = new DangNhap();
            loginForm.Show();
        }


        private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {

        }
    }
}
