using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectorApp.Users
{
    public partial class KetQua : Form
    {
        int tongSoPhieu { get; set; }
        int BauCuId { get; set; }
        const string baucuPath = "data/baucu.txt";

        HashSet<string> luachonSet = new HashSet<string>();
        Dictionary<string, int> ketquaDict = new Dictionary<string, int>();
        int daluachon = 1; // Số lượng lựa chọn tối đa mà mỗi người được chọn

        public KetQua(int baucuId)
        {
            InitializeComponent();
            this.BauCuId = baucuId;
        }

        private void KetQua_Load(object sender, EventArgs e)
        {
            // Khởi tạo ComboBox với các tùy chọn sắp xếp
            InitializeComboBox();
            pnKetqua.AutoScroll = true;

            // Bước 1: Đọc thông tin bầu cử từ file baucu.txt
            if (System.IO.File.Exists(baucuPath))
            {
                var lines = System.IO.File.ReadAllLines(baucuPath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2 && int.Parse(parts[0]) == BauCuId)
                    {
                        lbtenbaucu.Text = parts[1]; // Hiển thị tên cuộc bầu cử

                        // Lấy số lượng lựa chọn tối đa
                        if (parts.Length > 6 && int.TryParse(parts[6], out int maxChoices))
                        {
                            daluachon = maxChoices;
                        }

                        // Lấy danh sách lựa chọn từ parts[7]
                        if (parts.Length > 7 && !string.IsNullOrEmpty(parts[7]))
                        {
                            var luachonArray = parts[7].Split(';');
                            foreach (var lc in luachonArray)
                            {
                                if (!string.IsNullOrWhiteSpace(lc))
                                {
                                    luachonSet.Add(lc.Trim()); // Lấy danh sách đầy đủ các lựa chọn
                                }
                            }
                        }
                        break; // Thoát vòng lặp sau khi tìm thấy
                    }
                }
            }

            // Bước 2: Gọi phương thức để tính toán và hiển thị kết quả
            tinhKetQua();
        }

        private void InitializeComboBox()
        {
            cmbFilter.Items.Add("Số phiếu: Cao -> Thấp");
            cmbFilter.Items.Add("Số phiếu: Thấp -> Cao");
            cmbFilter.Items.Add("Tên: A -> Z");
            cmbFilter.Items.Add("Tên: Z -> A");

            // Đặt giá trị mặc định
            cmbFilter.SelectedIndex = 0;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng thay đổi lựa chọn sắp xếp, cập nhật lại hiển thị
            hienThiKetQua();
        }

        private void tinhKetQua()
        {
            string phieubauPath = $"data/phieubau{BauCuId}.txt";
            if (System.IO.File.Exists(phieubauPath))
            {
                var lines = System.IO.File.ReadAllLines(phieubauPath);
                tongSoPhieu = lines.Length;

                // Cập nhật tổng số phiếu vào label
                lbsophieu.Text = tongSoPhieu.ToString();

                // Khởi tạo số phiếu cho tất cả các lựa chọn là 0
                ketquaDict.Clear();
                foreach (var lc in luachonSet)
                {
                    ketquaDict[lc] = 0;
                }

                // Đếm số phiếu cho mỗi lựa chọn
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(',');
                    if (parts.Length >= 2) // Ít nhất có userId và 1 lựa chọn
                    {
                        // Bỏ qua phần tử đầu tiên (userId), đếm từ phần tử thứ 2 trở đi
                        for (int i = 1; i < parts.Length; i++)
                        {
                            var choice = parts[i].Trim();
                            if (!string.IsNullOrEmpty(choice) && ketquaDict.ContainsKey(choice))
                            {
                                ketquaDict[choice]++;
                            }
                        }
                    }
                }
            }
            else
            {
                // Hiển thị thông báo khi không có phiếu bầu
                tongSoPhieu = 0;
                lbsophieu.Text = "0";

                // Vẫn khởi tạo ketquaDict với giá trị 0 cho tất cả lựa chọn
                ketquaDict.Clear();
                foreach (var lc in luachonSet)
                {
                    ketquaDict[lc] = 0;
                }
            }

            // Hiển thị kết quả với sắp xếp mặc định
            hienThiKetQua();
        }

        private void hienThiKetQua()
        {
            // Xóa các controls cũ
            pnKetqua.Controls.Clear();

            if (ketquaDict.Count == 0)
            {
                Label lblNoData = new Label();
                lblNoData.Text = "Không có dữ liệu lựa chọn.";
                lblNoData.Location = new System.Drawing.Point(10, 10);
                lblNoData.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
                lblNoData.AutoSize = true;
                pnKetqua.Controls.Add(lblNoData);
                return;
            }

            // Sắp xếp theo lựa chọn của người dùng
            IEnumerable<KeyValuePair<string, int>> sortedResults;

            switch (cmbFilter.SelectedIndex)
            {
                case 0: // Số phiếu: Cao -> Thấp
                    sortedResults = ketquaDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
                    break;
                case 1: // Số phiếu: Thấp -> Cao
                    sortedResults = ketquaDict.OrderBy(x => x.Value).ThenBy(x => x.Key);
                    break;
                case 2: // Tên: A -> Z
                    sortedResults = ketquaDict.OrderBy(x => x.Key);
                    break;
                case 3: // Tên: Z -> A
                    sortedResults = ketquaDict.OrderByDescending(x => x.Key);
                    break;
                case 4: // Chỉ hiển thị Top 1
                    if (ketquaDict.Values.Any())
                    {
                        var maxVotes = ketquaDict.Values.Max();
                        sortedResults = ketquaDict.Where(x => x.Value == maxVotes).OrderBy(x => x.Key);
                    }
                    else
                    {
                        sortedResults = ketquaDict;
                    }
                    break;
                default: // Mặc định: Số phiếu cao -> thấp
                    sortedResults = ketquaDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
                    break;
            }

            if (tongSoPhieu == 0)
            {
                Label lblNoVotes = new Label();
                lblNoVotes.Text = "Chưa có phiếu bầu nào.";
                lblNoVotes.Location = new System.Drawing.Point(10, 10);
                lblNoVotes.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
                lblNoVotes.AutoSize = true;
                pnKetqua.Controls.Add(lblNoVotes);
                return;
            }

            // Hiển thị kết quả lên giao diện một cách gọn gàng và đẹp mắt
            int yPosition = 10;
            int rank = 1;

            foreach (var kvp in sortedResults)
            {
                // Tạo một panel cho mỗi lựa chọn với thiết kế đẹp
                Panel resultPanel = new Panel();
                resultPanel.Size = new Size(pnKetqua.Width - 30, 70);
                resultPanel.Location = new Point(15, yPosition);
                resultPanel.BackColor = Color.White;
                resultPanel.BorderStyle = BorderStyle.None;

                // Tạo shadow effect bằng cách thêm panel phía sau
                Panel shadowPanel = new Panel();
                shadowPanel.Size = new Size(resultPanel.Width, resultPanel.Height);
                shadowPanel.Location = new Point(17, yPosition + 2);
                shadowPanel.BackColor = Color.FromArgb(220, 220, 220);
                shadowPanel.BorderStyle = BorderStyle.None;
                pnKetqua.Controls.Add(shadowPanel);

                // Label cho thứ hạng (chỉ hiện khi không phải Top 1)
                if (cmbFilter.SelectedIndex != 4)
                {
                    Label lblRank = new Label();
                    lblRank.Text = $"#{rank}";
                    lblRank.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                    lblRank.ForeColor = Color.FromArgb(70, 130, 180);
                    lblRank.AutoSize = true;
                    lblRank.Location = new Point(10, 15);
                    resultPanel.Controls.Add(lblRank);
                }

                // Label cho tên lựa chọn
                Label lblChoice = new Label();
                lblChoice.Text = kvp.Key;
                lblChoice.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblChoice.ForeColor = Color.FromArgb(50, 50, 50);
                lblChoice.AutoSize = true;
                lblChoice.MaximumSize = new Size(400, 0);
                int choiceX = cmbFilter.SelectedIndex != 4 ? 55 : 15;
                lblChoice.Location = new Point(choiceX, 12);
                resultPanel.Controls.Add(lblChoice);

                // Label cho số phiếu
                Label lblVotes = new Label();
                lblVotes.Text = $"{kvp.Value} phiếu";
                lblVotes.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                lblVotes.ForeColor = Color.FromArgb(100, 100, 100);
                lblVotes.AutoSize = true;
                lblVotes.Location = new Point(resultPanel.Width - 120, 12);
                resultPanel.Controls.Add(lblVotes);

                // Label cho phần trăm nếu có phiếu bầu
                if (tongSoPhieu > 0)
                {
                    Label lblPercent = new Label();
                    // Tính phần trăm dựa trên tổng số phiếu thực tế, không nhân với daluachon
                    double percentage = (double)kvp.Value / (tongSoPhieu * daluachon) * 100;
                    lblPercent.Text = $"{percentage:F1}%";
                    lblPercent.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    lblPercent.ForeColor = Color.FromArgb(150, 150, 150);
                    lblPercent.AutoSize = true;
                    lblPercent.Location = new Point(resultPanel.Width - 120, 35);
                    resultPanel.Controls.Add(lblPercent);

                    // Thanh progress bar đơn giản
                    Panel progressBar = new Panel();
                    progressBar.Size = new Size((int)(300 * percentage / 100), 4);
                    progressBar.Location = new Point(choiceX, 50);
                    progressBar.BackColor = Color.FromArgb(70, 130, 180);
                    resultPanel.Controls.Add(progressBar);

                    // Background của progress bar
                    Panel progressBg = new Panel();
                    progressBg.Size = new Size(300, 4);
                    progressBg.Location = new Point(choiceX, 50);
                    progressBg.BackColor = Color.FromArgb(230, 230, 230);
                    resultPanel.Controls.Add(progressBg);
                    progressBg.SendToBack();
                }

                // Thêm border nhẹ
                resultPanel.Paint += (s, e) =>
                {
                    using (Pen pen = new Pen(Color.FromArgb(200, 200, 200), 1))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, resultPanel.Width - 1, resultPanel.Height - 1);
                    }
                };

                pnKetqua.Controls.Add(resultPanel);
                resultPanel.BringToFront();

                yPosition += 85;
                rank++;
            }
        }

        private void KetQua_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserSession.IsAdmin)
            {
                Form adminHome = new Admin.AdminHome();
                this.Hide();
                adminHome.Show();
                return;
            }
            else
            {
                Form home = new UserHome();
                this.Hide();
                home.Show();
            }
        }
    }
}