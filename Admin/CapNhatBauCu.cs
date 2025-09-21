using System;
using System.IO;
using System.Windows.Forms;
using ElectorApp.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace ElectorApp.Forms
{
    public partial class CapNhatBauCu : Form
    {
        // Hằng số cho đường dẫn file
        private const string filePath = "data/baucu.txt";
        private int bauCuId;
        int daluachon = 1;
        public CapNhatBauCu(int id)
        {
            InitializeComponent();
            bauCuId = id;
        }

        private void CapNhatBauCu_Load(object sender, EventArgs e)
        {
            hideMessage();
            LoadBauCuData();
            numericUpDown1.Minimum = 1;
            numericUpDown1.ReadOnly = true;
        }

        // Hàm tải dữ liệu bầu cử hiện tại
        private void LoadBauCuData()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    showMessage("File dữ liệu không tồn tại!", Color.DarkRed);
                    this.Close();
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);
                bool found = false;

                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split(',');
                        if (fields.Length >= 6 && int.TryParse(fields[0], out int currentId) && currentId == bauCuId)
                        {
                            // Load dữ liệu vào form
                            txtTenBauCu.Text = fields[1];
                            txtMoTa.Text = fields[2];

                            if (DateTime.TryParse(fields[3], out DateTime ngayBatDau))
                                dtpNgayBatDau.Value = ngayBatDau;

                            if (DateTime.TryParse(fields[4], out DateTime ngayKetThuc))
                                dtpNgayKetThuc.Value = ngayKetThuc;

                            // Load các lựa chọn nếu có
                            if (fields.Length > 6)
                            {
                                daluachon = int.Parse(fields[6]);
                                numericUpDown1.Value = daluachon;
                                string[] luaChons = fields[7].Split(';');
                                foreach (string luaChon in luaChons)
                                {
                                    if (!string.IsNullOrWhiteSpace(luaChon))
                                    {
                                        lstbLuaChon.Items.Add(luaChon);
                                    }
                                }
                            }

                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    showMessage("Không tìm thấy cuộc bầu cử!", Color.DarkRed);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                showMessage($"Lỗi khi tải dữ liệu: {ex.Message}", Color.DarkRed);
            }
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
                showMessage("Vui lòng nhập tên cuộc bầu cử!", Color.DarkRed);
                txtTenBauCu.Focus();
                return false;
            }

            // Kiểm tra mô tả
            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                showMessage("Vui lòng nhập mô tả cho cuộc bầu cử!", Color.DarkRed);
                txtMoTa.Focus();
                return false;
            }

            // Kiểm tra ngày kết thúc phải sau ngày bắt đầu
            if (dtpNgayKetThuc.Value <= dtpNgayBatDau.Value)
            {
                showMessage("Ngày kết thúc phải sau ngày bắt đầu!", Color.DarkRed);
                dtpNgayKetThuc.Focus();
                return false;
            }

            // Kiểm tra không được chứa dấu phẩy (vì sử dụng CSV format)
            if (txtTenBauCu.Text.Contains(',') || txtMoTa.Text.Contains(','))
            {
                showMessage("Tên và mô tả không được chứa dấu phẩy!", Color.DarkRed);
                return false;
            }

            // Kiểm tra phải có ít nhất 2 lựa chọn
            if (lstbLuaChon.Items.Count < 2)
            {
                showMessage("Vui lòng thêm ít nhất 2 lựa chọn!", Color.DarkRed);
                return false;
            }

            return true;
        }

        // Hàm kiểm tra xem tên cuộc bầu cử đã tồn tại chưa (trừ cuộc bầu cử hiện tại)
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
                    if (fields.Length >= 2 && int.TryParse(fields[0], out int currentId))
                    {
                        // Bỏ qua cuộc bầu cử hiện tại
                        if (currentId != bauCuId && fields[1].Equals(tenBauCu, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Hàm cập nhật thông tin cuộc bầu cử
        private void UpdateBauCu()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    showMessage("File dữ liệu không tồn tại!", Color.DarkRed);
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);
                bool found = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lines[i]))
                    {
                        string[] fields = lines[i].Split(',');
                        if (fields.Length >= 6 && int.TryParse(fields[0], out int currentId) && currentId == bauCuId)
                        {
                            // Tạo HashSet từ danh sách các lựa chọn trong ListBox
                            HashSet<string> luaChon = new HashSet<string>();
                            foreach (var item in lstbLuaChon.Items)
                            {
                                luaChon.Add(item.ToString());
                            }

                            // Cập nhật dữ liệu
                            daluachon = getDaluachon();
                            if( daluachon > luaChon.Count)
                            {
                                showMessage("Số lựa chọn tối đa lớn hơn tổng số lựa chon.", Color.DarkRed);
                                return;
                            }
                            if( daluachon < 1)
                            {
                                showMessage("Số lựa chọn tối đa phải lớn hơn hoặc bằng 1.", Color.DarkRed);
                                return;
                            }
                            string tenBauCu = txtTenBauCu.Text.Trim();
                            string moTa = txtMoTa.Text.Trim();
                            DateTime ngayBatDau = dtpNgayBatDau.Value;
                            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
                            string luaChonString = string.Join(";", luaChon);

                            // Giữ nguyên trạng thái khóa
                            string trangThaiKhoa = fields.Length > 5 ? fields[5] : "false";

                            // Format dữ liệu mới
                            string dataLine = $"{bauCuId},{tenBauCu},{moTa},{ngayBatDau:yyyy-MM-dd HH:mm:ss},{ngayKetThuc:yyyy-MM-dd HH:mm:ss},{trangThaiKhoa},{daluachon},{luaChonString}";
                            lines[i] = dataLine;

                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                {
                    File.WriteAllLines(filePath, lines);
                    daluachon = 1;
                    showMessage("Cập nhật cuộc bầu cử thành công!", Color.Green);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    showMessage("Không tìm thấy cuộc bầu cử để cập nhật!", Color.DarkRed);
                }
            }
            catch (Exception ex)
            {
                showMessage($"Lỗi khi cập nhật: {ex.Message}", Color.DarkRed);
            }
        }

        // Event handler cho nút Cập nhật
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            if (IsBauCuNameExists(txtTenBauCu.Text.Trim()))
            {
                showMessage("Tên cuộc bầu cử đã tồn tại! Vui lòng chọn tên khác.", Color.DarkRed);
                txtTenBauCu.Focus();
                txtTenBauCu.SelectAll();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn cập nhật cuộc bầu cử này?",
                "Xác nhận cập nhật",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UpdateBauCu();
            }
        }

        // Event handler cho nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy? Các thay đổi sẽ không được lưu.",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // Event handler khi form đóng
        private void CapNhatBauCu_FormClosing(object sender, FormClosingEventArgs e)
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
            // Kiểm tra độ dài tối đa
            if (txtTenBauCu.Text.Length > 100)
            {
                txtTenBauCu.Text = txtTenBauCu.Text.Substring(0, 100);
                txtTenBauCu.SelectionStart = txtTenBauCu.Text.Length;
            }
        }

        // Event handler cho việc nhập text trong mô tả
        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra độ dài tối đa
            if (txtMoTa.Text.Length > 500)
            {
                txtMoTa.Text = txtMoTa.Text.Substring(0, 500);
                txtMoTa.SelectionStart = txtMoTa.Text.Length;
            }
        }

        // Event handler cho nút Thêm lựa chọn
        private void btnThemLuaChon_Click(object sender, EventArgs e)
        {
            string luaChonMoi = txtLuaChon.Text.Trim();
            if (string.IsNullOrWhiteSpace(luaChonMoi))
            {
                showMessage("Vui lòng nhập lựa chọn để thêm.", Color.DarkRed);
                return;
            }
            if (luaChonMoi.Contains(';') || luaChonMoi.Contains(','))
            {
                showMessage("Lựa chọn không được chứa dấu phẩy (,) hoặc dấu chấm phẩy (;).", Color.DarkRed);
                return;
            }
            if (lstbLuaChon.Items.Contains(luaChonMoi))
            {
                showMessage("Lựa chọn này đã tồn tại.", Color.DarkRed);
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
                showMessage("Vui lòng chọn một lựa chọn để xóa.", Color.DarkRed);
            }
        }

        private int getDaluachon()
        {
            return (int)numericUpDown1.Value;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}