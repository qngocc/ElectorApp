using System;
using System.IO;
using System.Windows.Forms;
using ElectorApp.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Security.Policy;

namespace ElectorApp.Forms
{
    public partial class TaoBauCu : Form
    {
        // Hằng số cho đường dẫn file
        private const string filePath = "data/baucu.txt";
        int daluachon = 1; // mac dich la don lua chon

        public TaoBauCu()
        {
            InitializeComponent();
        }

        private void TaoBauCu_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho DateTimePicker
            hideMessage();
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now.AddDays(7); // Mặc định kéo dài 7 ngày
            numericUpDown1.Minimum = 1;
            numericUpDown1.ReadOnly = true;
        }

        // Hàm lấy ID tiếp theo cho cuộc bầu cử mới
        private int GetNextId()
        {
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                return 1;
            }

            string[] lines = File.ReadAllLines(filePath);
            int maxId = 0;

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] fields = line.Split(',');
                    if (int.TryParse(fields[0], out int currentId))
                    {
                        if (currentId > maxId)
                        {
                            maxId = currentId;
                        }
                    }
                }
            }
            return maxId + 1;
        }

        // Hàm hiển thị thông báo tạm thời
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

        // Hàm kiểm tra tính hợp lệ của dữ liệu nhập
        private bool ValidateInput()
        {
            // Kiểm tra tên cuộc bầu cử
            if (string.IsNullOrWhiteSpace(txtTenBauCu.Text))
            {
                showMessage("Vui lòng nhập tên cuộc bầu cử!", System.Drawing.Color.DarkRed);
                txtTenBauCu.Focus();
                return false;
            }

            // Kiểm tra mô tả
            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                showMessage("Vui lòng nhập mô tả cho cuộc bầu cử!", System.Drawing.Color.DarkRed);
                txtMoTa.Focus();
                return false;
            }

            // Kiểm tra ngày kết thúc phải sau ngày bắt đầu
            if (dtpNgayKetThuc.Value <= dtpNgayBatDau.Value)
            {
                showMessage("Ngày kết thúc phải sau ngày bắt đầu!", System.Drawing.Color.DarkRed);
                dtpNgayKetThuc.Focus();
                return false;
            }

            // Kiểm tra ngày bắt đầu không được trong quá khứ
            if (dtpNgayBatDau.Value.Date < DateTime.Now.Date)
            {
                showMessage("Ngày bắt đầu không được trong quá khứ!", System.Drawing.Color.DarkRed);
                dtpNgayBatDau.Focus();
                return false;
            }

            // Kiểm tra không được chứa dấu phẩy (vì sử dụng CSV format)
            if (txtTenBauCu.Text.Contains(',') || txtMoTa.Text.Contains(','))
            {
                showMessage("Tên và mô tả không được chứa dấu phẩy!", System.Drawing.Color.DarkRed);
                return false;
            }

            // Kiểm tra phải có ít nhất 2 lựa chọn
            if (lstbLuaChon.Items.Count < 2)
            {
                showMessage("Vui lòng thêm ít nhất 2 lựa chọn!", System.Drawing.Color.DarkRed);
                return false;
            }

            return true;
        }

        // Hàm lưu thông tin cuộc bầu cử vào file
        private void SaveBauCu()
        {
            try
            {
                int newId = GetNextId();
                string tenBauCu = txtTenBauCu.Text.Trim();
                string moTa = txtMoTa.Text.Trim();
                DateTime ngayBatDau = dtpNgayBatDau.Value;
                DateTime ngayKetThuc = dtpNgayKetThuc.Value;

                // Tạo HashSet từ danh sách các lựa chọn trong ListBox
                HashSet<string> luaChon = new HashSet<string>();
                foreach (var item in lstbLuaChon.Items)
                {
                    luaChon.Add(item.ToString());
                }

                // Format dữ liệu để lưu vào file CSV, thêm các lựa chọn vào cuối
                string luaChonString = string.Join(";", luaChon); // Sử dụng ";" để phân tách các lựa chọn
                daluachon = getDaluachon();
                if(daluachon > luaChon.Count)
                {
                    showMessage("Số lựa chọn cần chọn lớn hơn tổng số lựa chọn.", System.Drawing.Color.DarkRed); 
                    return;
                }
                if (daluachon < 1)
                {
                    showMessage("Số lựa chọn tối đa phải lớn hơn hoặc bằng 1.", Color.DarkRed);
                    return;
                }
                string dataLine = $"{newId},{tenBauCu},{moTa},{ngayBatDau:yyyy-MM-dd HH:mm:ss},{ngayKetThuc:yyyy-MM-dd HH:mm:ss},false,{daluachon},{luaChonString}";

                // Tạo file nếu chưa tồn tại
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                string phieubauFilePath = $"data/phieubau{newId}.txt";
                if (!File.Exists(phieubauFilePath))
                {
                    File.Create(phieubauFilePath).Close(); // Tạo file phiếu bầu riêng cho cuộc bầu cử
                }
                else
                {
                    File.WriteAllText(phieubauFilePath, string.Empty); // Xóa nội dung cũ nếu file đã tồn tại
                }

                // Ghi dữ liệu vào file
                File.AppendAllText(filePath, dataLine + Environment.NewLine);

                showMessage("Tạo cuộc bầu cử thành công!", System.Drawing.Color.Green);
                daluachon = 1;
                // Reset form sau khi lưu thành công
                ResetForm();
            }
            catch (Exception ex)
            {
                showMessage($"Lỗi khi lưu: {ex.Message}", System.Drawing.Color.DarkRed);
            }
        }

        // Hàm reset form về trạng thái ban đầu
        private void ResetForm()
        {
            txtTenBauCu.Clear();
            txtMoTa.Clear();
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now.AddDays(7);
            txtLuaChon.Clear();
            lstbLuaChon.Items.Clear();
            txtTenBauCu.Focus();
        }

        // Event handler cho nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            if (IsBauCuNameExists(txtTenBauCu.Text.Trim()))
            {
                showMessage("Tên cuộc bầu cử đã tồn tại! Vui lòng chọn tên khác.", System.Drawing.Color.DarkRed);
                txtTenBauCu.Focus();
                txtTenBauCu.SelectAll();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn tạo cuộc bầu cử này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveBauCu();
            }
        }

        // Event handler cho nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTenBauCu.Text) ||
                !string.IsNullOrWhiteSpace(txtMoTa.Text) ||
                lstbLuaChon.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy? Dữ liệu đã nhập sẽ bị mất.",
                    "Xác nhận hủy",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }

        // Event handler khi form đóng
        private void TaoBauCu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Không làm gì đặc biệt
        }

        // Event handler khi DateTimePicker ngày bắt đầu thay đổi
        private void dtpNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayKetThuc.Value <= dtpNgayBatDau.Value)
            {
                dtpNgayKetThuc.Value = dtpNgayBatDau.Value.AddDays(1);
            }
        }

        // Event handler cho việc nhập text trong tên bầu cử
        private void txtTenBauCu_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra độ dài tối đa (tùy chọn)
            if (txtTenBauCu.Text.Length > 100)
            {
                txtTenBauCu.Text = txtTenBauCu.Text.Substring(0, 100);
                txtTenBauCu.SelectionStart = txtTenBauCu.Text.Length;
            }
        }

        // Event handler cho việc nhập text trong mô tả
        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra độ dài tối đa (tùy chọn)
            if (txtMoTa.Text.Length > 500)
            {
                txtMoTa.Text = txtMoTa.Text.Substring(0, 500);
                txtMoTa.SelectionStart = txtMoTa.Text.Length;
            }
        }

        // Hàm kiểm tra xem tên cuộc bầu cử đã tồn tại chưa
        private bool IsBauCuNameExists(string tenBauCu)
        {
            if (!File.Exists(filePath))
                return false;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] fields = line.Split(',');
                    if (fields.Length >= 2 && fields[1].Equals(tenBauCu, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Event handler cho nút Thêm lựa chọn
        private void btnThemLuaChon_Click(object sender, EventArgs e)
        {
            string luaChonMoi = txtLuaChon.Text.Trim();
            if (string.IsNullOrWhiteSpace(luaChonMoi))
            {
                showMessage("Vui lòng nhập lựa chọn để thêm.", System.Drawing.Color.DarkRed);
                return;
            }
            if (luaChonMoi.Contains(';') || luaChonMoi.Contains(','))
            {
                showMessage("Lựa chọn không được chứa dấu phẩy (,) hoặc dấu chấm phẩy (;).", System.Drawing.Color.DarkRed);
                return;
            }
            if (lstbLuaChon.Items.Contains(luaChonMoi))
            {
                showMessage("Lựa chọn này đã tồn tại.", System.Drawing.Color.DarkRed);
                return;
            }

            lstbLuaChon.Items.Add(luaChonMoi);
            txtLuaChon.Clear();
            txtLuaChon.Focus();
        }

        // Event handler cho nút Xóa lựa chọn
        private void btnXoaLuaChon_Click(object sender, EventArgs e)
        {
            if (lstbLuaChon.SelectedItem != null)
            {
                lstbLuaChon.Items.Remove(lstbLuaChon.SelectedItem);
            }
            else
            {
                showMessage("Vui lòng chọn một lựa chọn để xóa.", System.Drawing.Color.DarkRed);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }
        private int getDaluachon()
        {
            return (int)numericUpDown1.Value;
        }
    }
}