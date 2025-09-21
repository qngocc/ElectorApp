using ElectorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ElectorApp.Auth
{
    public partial class DangNhap : Form
    {
        public DangNhap()
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
                txtPassword.PasswordChar = '•';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form dangky = new DangKy();
            dangky.Show();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void showMessage(string message, Color color)
        {
            showmessage.Visible = true;
            backgrPanel.Visible = true;
            showmessage.Text = message;
            backgrPanel.BackColor = color;
            showmessage.Visible = true;

            await Task.Delay(4000); // Hiển thị thông báo trong 4 giây

            backgrPanel.Visible = false;
            showmessage.Visible = false;
            backgrPanel.BackColor = Color.DarkRed;
            showmessage.Text = "";
        }

        private void saveLoginInfo(string username, string password)
        {
            string filePath = "data/login.txt"; // duong dan den file luu thong tin dang nhap
            File.WriteAllText(filePath, $"{username},{password}");
        }
        private void loadLoginInfo()
        {
            string filePath = "data/login.txt"; // duong dan den file luu thong tin dang nhap
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        txtUsername.Text = parts[0];
                        txtPassword.Text = parts[1];
                    }
                }
            }
        }
        public void clearLoginInfo()
        {
            string filePath = "data/login.txt"; // duong dan den file luu thong tin dang nhap
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string filePath = "data/user.txt"; // duong dan den file luu user ( bin/Debug/net9.0/user.txt )

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                showMessage("Vui lòng điền đầy đủ thông tin!", Color.DarkRed);
                return;
            }
            else
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length >= 5 && parts[1] == username && parts[2] == password)
                        {
                            bool isAdmin = false;
                            if (parts[4] != "False") isAdmin = true;
                            int userId = int.Parse(parts[0]);
                            User user = new User(userId, username, parts[3], isAdmin);
                            // Luu thong tin user vao session
                            UserSession.Login(user);
                            if (cbkeeplogin.Checked)
                            {
                                saveLoginInfo(username, password); // luu thong tin dang nhap
                            }
                            else
                            {
                                clearLoginInfo(); // xoa thong tin dang nhap
                            }
                            //showMessage("Đăng nhập thành công!", Color.Green);
                            if (isAdmin)
                            {
                                Form adminHone = new Admin.AdminHome();
                                this.Hide();
                                adminHone.Show();
                                return;
                            }
                            else
                            {
                                Form userHome = new Users.UserHome();
                                this.Hide();
                                userHome.Show();
                            }
                        }
                    }
                    // Nếu không tìm thấy tài khoản hoặc mật khẩu không đúng
                    showMessage("Tài khoản hoặc mật khẩu không đúng!", Color.DarkRed);
                }
                else
                {
                    showMessage("File user.txt không tồn tại!", Color.DarkRed);
                }
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            string directoryPath = "data"; // duong dan den thu muc chua file luu thong tin
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string UserFile = "data/user.txt"; 
            if(!File.Exists(UserFile))
            {
                // Neu chua co file user.txt thi tao file va them tai khoan admin mac dinh
                File.Create(UserFile).Close();
                File.WriteAllText(UserFile, "1,admin,admin,Huu Su Dev,True\n");
            }
            string LoginFile = "data/login.txt"; // duong dan den file luu thong tin dang nhap
            if (!File.Exists(LoginFile))
            {
                // Neu chua co file login.txt thi tao file
                File.Create(LoginFile).Close();
                File.WriteAllText(LoginFile, "");
            }
            string baucuFile = "data/baucu.txt"; // duong dan den file luu thong tin bau cu
            if (!File.Exists(baucuFile))
            {
                // Neu chua co file baucu.txt thi tao file
                File.Create(baucuFile).Close();
                File.WriteAllText(baucuFile, "");
            }
            showMessage(" Tài khoản quản trị: Tài khoản: admin | mật khẩu: admin", Color.DarkRed);
            loadLoginInfo();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void backgrPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showmessage_Click(object sender, EventArgs e)
        {

        }
    }
}
