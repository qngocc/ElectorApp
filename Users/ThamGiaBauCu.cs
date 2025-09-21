using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectorApp.Users
{
    public partial class ThamGiaBauCu : Form
    {
        int BauCuId { get; set; }
        int UserId = UserSession.Id;
        List<string> selectedChoices = new List<string>(); // Thay đổi từ string thành List<string>
        string mota = "";
        int maxChoices = 1; // Số lượng lựa chọn tối đa cho phép

        // panel1 đã được thiết kế sẵn trên Form

        public ThamGiaBauCu(int bauCuId)
        {
            this.BauCuId = bauCuId;
            InitializeComponent();
        }

        private void ThamGiaBauCu_Load(object sender, EventArgs e)
        {
            // Bật thanh cuộn tự động cho panel1
            panel1.AutoScroll = true;

            string phieubauPath = $"data/phieubau{BauCuId}.txt";
            string baucuPath = "data/baucu.txt";
            if (System.IO.File.Exists(baucuPath))
            {
                var lines = System.IO.File.ReadAllLines(baucuPath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2 && int.Parse(parts[0]) == BauCuId)
                    {
                        lbtenbaucu.Text = parts[1];
                        mota = lbmota.Text = parts[2];

                        // Lấy số lượng lựa chọn tối đa từ trường daluachon
                        if (parts.Length > 6 && int.TryParse(parts[6], out int daluachon))
                        {
                            maxChoices = daluachon;
                        }

                        // Tách chuỗi lựa chọn từ parts[7] (thay vì parts[6])
                        if (parts.Length > 7 && !string.IsNullOrEmpty(parts[7]))
                        {
                            var luachonArray = parts[7].Split(';');
                            // Vòng lặp để tạo các Button động
                            for (int i = 0; i < luachonArray.Length; i++)
                            {
                                Button newButton = new Button();

                                // Gán Text từ mảng luachonArray
                                newButton.Text = luachonArray[i];
                                newButton.Size = new Size(750, 50);
                                newButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                                newButton.BackColor = Color.White;
                                newButton.ForeColor = Color.Black;
                                newButton.Tag = luachonArray[i]; // Lưu giá trị vào Tag để dễ xử lý

                                // Sắp xếp các button theo chiều dọc
                                newButton.Location = new Point(10, 50 * i + 40);
                                newButton.Click += new EventHandler(LuaChon_Click);

                                // Thêm button vào panel1
                                panel1.Controls.Add(newButton);
                            }
                        }

                        // Hiển thị thông tin về số lượng lựa chọn
                        Label lblInstruction = new Label();
                        lblInstruction.Text = $"Vui lòng chọn {maxChoices} lựa chọn";
                        lblInstruction.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                        lblInstruction.ForeColor = Color.Blue;
                        lblInstruction.AutoSize = true;
                        lblInstruction.Location = new Point(10, 10);
                        panel1.Controls.Add(lblInstruction);

                        break;
                    }
                }
            }
        }

        private void LuaChon_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string choice = clickedButton.Tag.ToString();

                if (selectedChoices.Contains(choice))
                {
                    // Nếu đã chọn rồi thì bỏ chọn
                    selectedChoices.Remove(choice);
                    clickedButton.BackColor = Color.White;
                    clickedButton.FlatAppearance.BorderColor = Color.Blue;
                }
                else
                {
                    // Kiểm tra xem đã chọn đủ số lượng chưa
                    if (selectedChoices.Count >= maxChoices)
                    {
                        MessageBox.Show($"Bạn chỉ được chọn tối đa {maxChoices} lựa chọn!",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm vào danh sách đã chọn
                    selectedChoices.Add(choice);
                    clickedButton.BackColor = Color.LightBlue;
                    clickedButton.FlatAppearance.BorderColor = Color.DarkBlue;
                }

                // Cập nhật hiển thị số lượng đã chọn
                UpdateSelectionDisplay();
            }
        }

        private void UpdateSelectionDisplay()
        {
            // Tìm và cập nhật label hiển thị số lượng đã chọn
            foreach (Control control in panel1.Controls)
            {
                if (control is Label && control.Name == "lblSelectionCount")
                {
                    panel1.Controls.Remove(control);
                    break;
                }
            }

            Label lblCount = new Label();
            lblCount.Name = "lblSelectionCount";
            lblCount.Text = $"Đã chọn: {selectedChoices.Count}/{maxChoices}";
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblCount.ForeColor = selectedChoices.Count == maxChoices ? Color.Green : Color.Red;
            lblCount.AutoSize = true;
            lblCount.Location = new Point(400, 10);
            panel1.Controls.Add(lblCount);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form UsersHome = new UserHome();
            this.Hide();
            UsersHome.Show();
        }

        private void ThamGiaBauCu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string phieubauPath = $"data/phieubau{BauCuId}.txt";

            // Kiểm tra xem đã chọn đủ số lượng lựa chọn chưa
            if (selectedChoices.Count != maxChoices)
            {
                MessageBox.Show($"Vui lòng chọn đúng {maxChoices} lựa chọn trước khi gửi phiếu bầu.",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem người dùng đã bầu chưa
            bool hasVoted = false;
            if (System.IO.File.Exists(phieubauPath))
            {
                var lines = System.IO.File.ReadAllLines(phieubauPath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2 && int.TryParse(parts[0], out int votedUserId) && votedUserId == UserId)
                    {
                        hasVoted = true;
                        break;
                    }
                }
            }

            if (hasVoted)
            {
                MessageBox.Show("Bạn đã tham gia bầu cử này rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo chuỗi hiển thị các lựa chọn đã chọn
            string choicesDisplay = string.Join(", ", selectedChoices);
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn gửi phiếu bầu cho:\n'{choicesDisplay}' không?",
                                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            // Lưu phiếu bầu với format: UserId,choice1,choice2,...
            string newVote = UserId + "," + string.Join(",", selectedChoices);
            System.IO.File.AppendAllText(phieubauPath, newVote + Environment.NewLine);

            MessageBox.Show("Bạn đã gửi phiếu bầu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form UsersHome = new UserHome();
            this.Hide();
            UsersHome.Show();
        }

        private void lbmota_Click(object sender, EventArgs e)
        {

        }
    }
}