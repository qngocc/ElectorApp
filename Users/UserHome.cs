using ElectorApp.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectorApp.Users
{
    public partial class UserHome : Form
    {
        private const string filePath = "data/baucu.txt";
        // Biến để lưu trữ toàn bộ dữ liệu bầu cử, dùng cho việc lọc
        private DataTable allBauCuData;

        public UserHome()
        {
            InitializeComponent();
        }

        private void UserHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadBauCuData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserSession.Logout();
            this.Hide();
            Form dangnhap = new Auth.DangNhap();
            dangnhap.Show();
        }

        private void UserHome_Load(object sender, EventArgs e)
        {
            txtUserName.Text = UserSession.FullName;
            LoadBauCuData();
            // Thiết lập sự kiện cho ComboBox khi form load
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // Chọn mục đầu tiên để hiển thị tất cả
            comboBox1.SelectedIndex = 5; // Mới nhất (hiển thị tất cả)
            hideMessage();
        }

        private async void showMessage(string message, Color color)
        {
            lbshowmessage.Visible = true;
            lbshowmessage.Text = message;
            lbshowmessage.BackColor = color;
            await Task.Delay(3000); // Hiển thị thông báo trong 3 giây
            hideMessage();
        }

        private void hideMessage()
        {
            lbshowmessage.Visible = false;
            lbshowmessage.Text = "";
            lbshowmessage.BackColor = Color.DarkRed;
        }

        // Phương thức chính để tải dữ liệu từ file
        private void LoadBauCuData()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    dataGridView1.DataSource = null;
                    allBauCuData = null;
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Tên cuộc bầu cử", typeof(string));
                dt.Columns.Add("Mô tả", typeof(string));
                dt.Columns.Add("Ngày bắt đầu", typeof(DateTime));
                dt.Columns.Add("Ngày kết thúc", typeof(DateTime));
                dt.Columns.Add("Số lựa chọn", typeof(int)); // Thêm cột hiển thị số lượng lựa chọn tối đa
                dt.Columns.Add("Trạng thái", typeof(string));
                dt.Columns.Add("Đã tham gia", typeof(string));

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split(',');
                        if (fields.Length >= 6)
                        {
                            DataRow row = dt.NewRow();
                            int bauCuId = int.Parse(fields[0]);
                            row["ID"] = bauCuId;
                            row["Tên cuộc bầu cử"] = fields[1];
                            row["Mô tả"] = fields[2];

                            if (DateTime.TryParse(fields[3], out DateTime ngayBatDau))
                                row["Ngày bắt đầu"] = ngayBatDau;
                            else
                                row["Ngày bắt đầu"] = DateTime.MinValue;

                            if (DateTime.TryParse(fields[4], out DateTime ngayKetThuc))
                                row["Ngày kết thúc"] = ngayKetThuc;
                            else
                                row["Ngày kết thúc"] = DateTime.MinValue;

                            // Lấy số lượng lựa chọn tối đa
                            int daluachon = 1; // Giá trị mặc định
                            if (fields.Length > 6 && int.TryParse(fields[6], out int maxChoices))
                            {
                                daluachon = maxChoices;
                            }
                            row["Số lựa chọn"] = daluachon;

                            bool ketThuc = false;
                            if (fields.Length > 5 && bool.TryParse(fields[5], out ketThuc))
                            {
                                // Use the parsed value
                            }

                            DateTime now = DateTime.Now;

                            string trangThai;
                            if (ketThuc)
                            {
                                trangThai = "Đã khóa";
                            }
                            else if (now < ngayBatDau)
                            {
                                trangThai = "Chưa bắt đầu";
                            }
                            else if (now > ngayKetThuc)
                            {
                                trangThai = "Đã kết thúc";
                            }
                            else
                            {
                                trangThai = "Đang diễn ra";
                            }

                            row["Trạng thái"] = trangThai;

                            row["Đã tham gia"] = dabau(bauCuId) ? "Đã tham gia" : "Chưa tham gia";

                            dt.Rows.Add(row);
                        }
                    }
                }

                // Lưu toàn bộ dữ liệu vào biến thành viên
                allBauCuData = dt;

                // Sắp xếp dữ liệu theo ngày bắt đầu giảm dần (mới nhất)
                DataView dv = allBauCuData.DefaultView;
                dv.Sort = "Ngày bắt đầu DESC";
                dataGridView1.DataSource = dv.ToTable();

                // Cấu hình DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.ReadOnly = true;

                if (dataGridView1.Columns["Ngày bắt đầu"] != null)
                {
                    dataGridView1.Columns["Ngày bắt đầu"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dataGridView1.Columns["Ngày kết thúc"] != null)
                {
                    dataGridView1.Columns["Ngày kết thúc"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức xử lý sự kiện khi ComboBox thay đổi lựa chọn
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem dữ liệu đã được load chưa
            if (allBauCuData == null)
            {
                return;
            }

            string filterText = comboBox1.SelectedItem.ToString();
            DataTable filteredData = allBauCuData.Clone(); // Tạo một DataTable rỗng có cùng cấu trúc

            // Lọc dữ liệu dựa trên lựa chọn
            foreach (DataRow row in allBauCuData.Rows)
            {
                string trangThai = row["Trạng thái"].ToString();
                string daThamGia = row["Đã tham gia"].ToString();

                bool shouldAddRow = false;

                switch (filterText)
                {
                    case "Đã tham gia":
                        if (daThamGia == "Đã tham gia")
                        {
                            shouldAddRow = true;
                        }
                        break;
                    case "Chưa tham gia":
                        if (daThamGia == "Chưa tham gia")
                        {
                            shouldAddRow = true;
                        }
                        break;
                    case "Đã kết thúc":
                        if (trangThai == "Đã kết thúc")
                        {
                            shouldAddRow = true;
                        }
                        break;
                    case "Đang diễn ra":
                        if (trangThai == "Đang diễn ra")
                        {
                            shouldAddRow = true;
                        }
                        break;
                    case "Đã khóa":
                        if (trangThai == "Đã khóa")
                        {
                            shouldAddRow = true;
                        }
                        break;
                    case "Chưa bắt đầu":
                        if (trangThai == "Chưa bắt đầu")
                        {
                            shouldAddRow = true;
                        }
                        break;
                    case "Mới nhất":
                        // "Mới nhất" hiển thị tất cả, đã được sắp xếp trong LoadBauCuData
                        shouldAddRow = true;
                        break;
                }

                if (shouldAddRow)
                {
                    filteredData.ImportRow(row);
                }
            }

            // Gán dữ liệu đã lọc vào DataGridView
            dataGridView1.DataSource = filteredData;
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            // Code xử lý sự kiện txtUserName_Click
        }

        public void xemKetquua(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                showMessage("Vui lòng chọn cuộc bầu cử để xem kết quả!", Color.DarkRed);
                return;
            }

            int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            Form formKetqua = new Users.KetQua(selectedId);
            this.Hide();
            formKetqua.Show();
        }

        private void btnThamGiaBau_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                showMessage("Vui lòng chọn cuộc bầu cử để tham gia!", Color.DarkRed);
                return;
            }

            try
            {
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                string tenBauCu = dataGridView1.SelectedRows[0].Cells["Tên cuộc bầu cử"].Value.ToString();
                string trangThai = dataGridView1.SelectedRows[0].Cells["Trạng thái"].Value.ToString();
                string daBau = dataGridView1.SelectedRows[0].Cells["Đã tham gia"].Value.ToString();
                int soLuaChon = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Số lựa chọn"].Value);

                // Kiểm tra trạng thái bầu cử
                if (trangThai != "Đang diễn ra")
                {
                    string message = "";
                    switch (trangThai)
                    {
                        case "Chưa bắt đầu":
                            message = "Cuộc bầu cử này chưa bắt đầu!";
                            break;
                        case "Đã kết thúc":
                            message = "Cuộc bầu cử này đã kết thúc!";
                            break;
                        case "Đã khóa":
                            message = "Cuộc bầu cử này đã bị khóa!";
                            break;
                        default:
                            message = "Không thể tham gia cuộc bầu cử này!";
                            break;
                    }
                    showMessage(message, Color.DarkRed);
                    return;
                }

                // Kiểm tra đã bầu chưa
                if (daBau == "Đã tham gia")
                {
                    showMessage("Bạn đã tham gia cuộc bầu cử này rồi!", Color.DarkRed);
                    return;
                }

                // Hiển thị thông báo về số lượng lựa chọn cần chọn
                string thongBao = soLuaChon == 1 ?
                    "Bạn sẽ chọn 1 lựa chọn trong cuộc bầu cử này." :
                    $"Bạn sẽ chọn {soLuaChon} lựa chọn trong cuộc bầu cử này.";

                DialogResult confirmResult = MessageBox.Show(
                    $"Tham gia cuộc bầu cử: {tenBauCu}\n\n{thongBao}\n\nBạn có muốn tiếp tục?",
                    "Xác nhận tham gia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (confirmResult == DialogResult.Yes)
                {
                    // Mở form bầu cử
                    int idBauCu = selectedId;
                    Form formThamGia = new Users.ThamGiaBauCu(idBauCu);
                    this.Hide();
                    formThamGia.Show();
                }

            }
            catch (Exception ex)
            {
                showMessage($"Lỗi khi tham gia bầu cử: {ex.Message}", Color.DarkRed);
            }
        }

        private bool dabau(int id)
        {
            string phieubauPath = $"data/phieubau{id}.txt";

            if (System.IO.File.Exists(phieubauPath))
            {
                var lines = System.IO.File.ReadAllLines(phieubauPath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2 && int.Parse(parts[0]) == UserSession.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Code xử lý sự kiện pictureBox1_Click
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}