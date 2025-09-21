using ElectorApp.Models;
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

namespace ElectorApp.Admin
{
    public partial class AdminHome : Form
    {
        // Đường dẫn file dữ liệu bầu cử
        private const string FILE_BAUCU = "data/baucu.txt";

        // Lưu dữ liệu gốc để lọc
        private DataTable dulieugoc;

        public AdminHome()
        {
            InitializeComponent();
            KhoiTaoComboLoc();
        }

        // Khởi tạo combo box lọc dữ liệu
        private void KhoiTaoComboLoc()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = 0; // Chọn "Tất cả" làm mặc định
        }

        // Khi đóng form thì thoát ứng dụng
        private void AdminHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Khi load form
        private void AdminHome_Load(object sender, EventArgs e)
        {
            lbAdminName.Text = UserSession.FullName + "👑";
            TaiDuLieu();
            AnThongBao();
        }

        // Nút tạo bầu cử mới
        private void btncreate_Click(object sender, EventArgs e)
        {
            Forms.TaoBauCu form = new Forms.TaoBauCu();
            form.ShowDialog(this);
            TaiDuLieu();
        }

        // Nút cập nhật bầu cử
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (!KiemTraChon("Vui lòng chọn cuộc bầu cử cần cập nhật!"))
                return;

            try
            {
                int id = LayIDDuocChon();

                // Kiểm tra có phiếu bầu chưa
                if (CoPhieuBau(id) && !XacNhanCapNhat())
                    return;

                Form capnhat = new Forms.CapNhatBauCu(id);
                capnhat.ShowDialog(this);
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                HienThongBao($"Lỗi khi cập nhật: {ex.Message}", Color.DarkRed);
            }
        }

        // Nút đăng xuất
        private void button1_Click(object sender, EventArgs e)
        {
            UserSession.Logout();
            this.Hide();
            Form dangnhap = new Auth.DangNhap();
            dangnhap.Show();
        }

        // Nút làm mới dữ liệu
        private void btnload_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        // Nút xóa bầu cử
        private void btnremove_Click(object sender, EventArgs e)
        {
            if (!KiemTraChon("Vui lòng chọn cuộc bầu cử cần xóa!"))
                return;

            try
            {
                int id = LayIDDuocChon();
                string ten = LayTenDuocChon();

                if (XacNhanXoa(ten))
                {
                    XoaBauCu(id);
                }
            }
            catch (Exception ex)
            {
                HienThongBao($"Lỗi khi xóa: {ex.Message}", Color.DarkRed);
            }
        }

        // Nút khóa/mở khóa bầu cử
        private void btnlock_Click(object sender, EventArgs e)
        {
            if (!KiemTraChon("Vui lòng chọn cuộc bầu cử cần khóa/mở khóa!"))
                return;

            try
            {
                int id = LayIDDuocChon();
                string ten = LayTenDuocChon();
                string trangthai = LayTrangThaiDuocChon();

                bool daKhoa = trangthai == "Đã khóa";
                string hanhdong = daKhoa ? "mở khóa" : "khóa";

                if (XacNhanKhoa(ten, hanhdong))
                {
                    DoiTrangThaiKhoa(id, !daKhoa);
                }
            }
            catch (Exception ex)
            {
                HienThongBao($"Lỗi khi khóa/mở khóa: {ex.Message}", Color.DarkRed);
            }
        }

        // Nút xem kết quả bầu cử
        private void btnresutl_Click(object sender, EventArgs e)
        {
            if (!KiemTraChon("Vui lòng chọn cuộc bầu cử để xem kết quả!"))
                return;

            int id = LayIDDuocChon();
            Form ketqua = new Users.KetQua(id);
            this.Hide();
            ketqua.Show();
        }

        // Khi click vào dòng trong bảng
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CapNhatNutKhoa();
        }

        // Khi thay đổi bộ lọc
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApDungLoc();
        }

        #region Các hàm kiểm tra và lấy dữ liệu

        // Kiểm tra có chọn dòng nào không
        private bool KiemTraChon(string thongbao)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                HienThongBao(thongbao, Color.DarkRed);
                return false;
            }
            return true;
        }

        // Lấy ID bầu cử được chọn
        private int LayIDDuocChon()
        {
            return Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
        }

        // Lấy tên bầu cử được chọn
        private string LayTenDuocChon()
        {
            return dataGridView1.SelectedRows[0].Cells["Tên cuộc bầu cử"].Value.ToString();
        }

        // Lấy trạng thái bầu cử được chọn
        private string LayTrangThaiDuocChon()
        {
            return dataGridView1.SelectedRows[0].Cells["Trạng thái"].Value.ToString();
        }

        // Kiểm tra bầu cử có phiếu bầu chưa
        private bool CoPhieuBau(int id)
        {
            string duongdan = $"data/phieubau{id}.txt";
            return File.Exists(duongdan) && new FileInfo(duongdan).Length > 0;
        }

        // Xác nhận cập nhật khi đã có phiếu bầu
        private bool XacNhanCapNhat()
        {
            DialogResult ketqua = MessageBox.Show(
                "Cuộc bầu cử này đã có phiếu bầu. Việc cập nhật có thể ảnh hưởng đến kết quả.\nBạn có chắc chắn muốn tiếp tục?",
                "Cảnh báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            return ketqua == DialogResult.Yes;
        }

        // Xác nhận xóa bầu cử
        private bool XacNhanXoa(string ten)
        {
            DialogResult ketqua = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa cuộc bầu cử:\n'{ten}' không?\n\nLưu ý: Hành động này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            return ketqua == DialogResult.Yes;
        }

        // Xác nhận khóa/mở khóa
        private bool XacNhanKhoa(string ten, string hanhdong)
        {
            DialogResult ketqua = MessageBox.Show(
                $"Bạn có chắc chắn muốn {hanhdong} cuộc bầu cử:\n'{ten}' không?",
                $"Xác nhận {hanhdong}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return ketqua == DialogResult.Yes;
        }

        // Cập nhật giao diện nút khóa
        private void CapNhatNutKhoa()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string trangthai = LayTrangThaiDuocChon();
                if (trangthai == "Đã khóa")
                {
                    btnlock.BackColor = Color.Green;
                    btnlock.ForeColor = Color.White;
                    btnlock.Text = "Mở khóa";
                }
                else
                {
                    btnlock.BackColor = Color.Yellow;
                    btnlock.ForeColor = Color.Black;
                    btnlock.Text = "Khóa";
                }
            }
        }

        #endregion

        #region Hiển thị thông báo

        // Hiển thị thông báo có màu
        private async void HienThongBao(string noidung, Color mau)
        {
            lbshowmessage.Visible = true;
            lbshowmessage.Text = noidung;
            lbshowmessage.BackColor = mau;
            await Task.Delay(3000); // Hiển thị 3 giây
            AnThongBao();
        }

        // Ẩn thông báo
        private void AnThongBao()
        {
            lbshowmessage.Visible = false;
            lbshowmessage.Text = "";
            lbshowmessage.BackColor = Color.DarkRed;
        }

        #endregion

        #region Tải và lọc dữ liệu

        // Tải dữ liệu từ file
        private void TaiDuLieu()
        {
            try
            {
                dulieugoc = DocDuLieuTuFile();
                CauHinhBang();
                ApDungLoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đọc dữ liệu từ file
        private DataTable DocDuLieuTuFile()
        {
            if (!File.Exists(FILE_BAUCU))
            {
                return TaoBangTrong();
            }

            string[] lines = File.ReadAllLines(FILE_BAUCU);
            DataTable bang = TaoBangTrong();

            foreach (string dong in lines)
            {
                if (!string.IsNullOrWhiteSpace(dong))
                {
                    DataRow row = ChuyenDongThanhRow(bang, dong);
                    if (row != null)
                        bang.Rows.Add(row);
                }
            }

            return bang;
        }

        // Tạo bảng dữ liệu trống
        private DataTable TaoBangTrong()
        {
            DataTable bang = new DataTable();
            bang.Columns.Add("ID", typeof(int));
            bang.Columns.Add("Tên cuộc bầu cử", typeof(string));
            bang.Columns.Add("Mô tả", typeof(string));
            bang.Columns.Add("Ngày bắt đầu", typeof(DateTime));
            bang.Columns.Add("Ngày kết thúc", typeof(DateTime));
            bang.Columns.Add("Số lựa chọn", typeof(int));
            bang.Columns.Add("Tổng lựa chọn", typeof(int));
            bang.Columns.Add("Trạng thái", typeof(string));
            return bang;
        }

        // Chuyển đổi dòng text thành DataRow
        private DataRow ChuyenDongThanhRow(DataTable bang, string dong)
        {
            try
            {
                string[] fields = dong.Split(',');
                if (fields.Length < 6) return null;

                DataRow row = bang.NewRow();
                row["ID"] = int.Parse(fields[0]);
                row["Tên cuộc bầu cử"] = fields[1];
                row["Mô tả"] = fields[2];

                // Xử lý ngày tháng
                row["Ngày bắt đầu"] = DateTime.TryParse(fields[3], out DateTime batdau)
                    ? batdau : DateTime.MinValue;
                row["Ngày kết thúc"] = DateTime.TryParse(fields[4], out DateTime ketthuc)
                    ? ketthuc : DateTime.MinValue;

                // Số lựa chọn tối đa
                int soluachon = fields.Length > 6 && int.TryParse(fields[6], out int max)
                    ? max : 1;
                row["Số lựa chọn"] = soluachon;

                // Đếm tổng số lựa chọn
                int tongluachon = 0;
                if (fields.Length > 7 && !string.IsNullOrEmpty(fields[7]))
                {
                    var luachons = fields[7].Split(';');
                    tongluachon = luachons.Count(lc => !string.IsNullOrWhiteSpace(lc));
                }
                row["Tổng lựa chọn"] = tongluachon;

                // Xác định trạng thái
                bool khoa = fields.Length > 5 && bool.TryParse(fields[5], out khoa) && khoa;
                row["Trạng thái"] = XacDinhTrangThai(khoa, batdau, ketthuc);

                return row;
            }
            catch
            {
                return null; // Bỏ qua dòng lỗi
            }
        }

        // Xác định trạng thái bầu cử
        private string XacDinhTrangThai(bool khoa, DateTime batdau, DateTime ketthuc)
        {
            DateTime hientai = DateTime.Now;

            if (khoa) return "Đã khóa";
            if (hientai < batdau) return "Chưa bắt đầu";
            if (hientai > ketthuc) return "Đã kết thúc";
            return "Đang diễn ra";
        }

        // Cấu hình bảng hiển thị
        private void CauHinhBang()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            // Định dạng cột ngày
            DinhDangCotNgay();

            // Tùy chỉnh độ rộng cột
            TuyChinhCot();
        }

        // Định dạng cột ngày tháng
        private void DinhDangCotNgay()
        {
            if (dataGridView1.Columns["Ngày bắt đầu"] != null)
                dataGridView1.Columns["Ngày bắt đầu"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            if (dataGridView1.Columns["Ngày kết thúc"] != null)
                dataGridView1.Columns["Ngày kết thúc"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        // Tùy chỉnh độ rộng cột
        private void TuyChinhCot()
        {
            if (dataGridView1.Columns["Số lựa chọn"] != null)
            {
                dataGridView1.Columns["Số lựa chọn"].Width = 80;
                dataGridView1.Columns["Số lựa chọn"].HeaderText = "Chọn tối đa";
            }

            if (dataGridView1.Columns["Tổng lựa chọn"] != null)
            {
                dataGridView1.Columns["Tổng lựa chọn"].Width = 80;
                dataGridView1.Columns["Tổng lựa chọn"].HeaderText = "Tổng lựa chọn";
            }
        }

        // Áp dụng bộ lọc dữ liệu
        private void ApDungLoc()
        {
            if (dulieugoc == null) return;

            DataView view = new DataView(dulieugoc);
            string boLoc = LayBieuThucLoc();

            if (!string.IsNullOrEmpty(boLoc))
                view.RowFilter = boLoc;

            // Áp dụng sắp xếp
            string sapXep = LayBieuThucSapXep();
            if (!string.IsNullOrEmpty(sapXep))
                view.Sort = sapXep;

            dataGridView1.DataSource = view;
        }

        // Tạo biểu thức lọc
        private string LayBieuThucLoc()
        {
            string lua_chon = comboBox1.SelectedItem?.ToString();

            switch (lua_chon)
            {
                case "Đang diễn ra":
                    return "[Trạng thái] = 'Đang diễn ra'";
                case "Đã khóa":
                    return "[Trạng thái] = 'Đã khóa'";
                case "Chưa bắt đầu":
                    return "[Trạng thái] = 'Chưa bắt đầu'";
                case "Đã kết thúc":
                    return "[Trạng thái] = 'Đã kết thúc'";
                default:
                    return string.Empty; // Tất cả
            }
        }

        // Tạo biểu thức sắp xếp
        private string LayBieuThucSapXep()
        {
            string lua_chon = comboBox1.SelectedItem?.ToString();

            switch (lua_chon)
            {
                case "A-Z":
                    return "[Tên cuộc bầu cử] ASC";
                case "Z-A":
                    return "[Tên cuộc bầu cử] DESC";
                case "Mới tạo":
                    return "ID DESC";
                default:
                    return string.Empty;
            }
        }

        #endregion

        #region Thao tác với file

        // Xóa bầu cử
        private void XoaBauCu(int id)
        {
            string duongdan_phieu = $"data/phieubau{id}.txt";
            try
            {
                if (!File.Exists(FILE_BAUCU))
                {
                    HienThongBao("File dữ liệu không tồn tại!", Color.DarkRed);
                    return;
                }

                string[] lines = File.ReadAllLines(FILE_BAUCU);
                var dong_moi = lines.Where(dong =>
                    !string.IsNullOrWhiteSpace(dong) &&
                    !dong.StartsWith($"{id},")).ToList();

                if (dong_moi.Count < lines.Length)
                {
                    // Xóa file phiếu bầu nếu có
                    if (File.Exists(duongdan_phieu))
                        File.Delete(duongdan_phieu);

                    File.WriteAllLines(FILE_BAUCU, dong_moi);
                    HienThongBao("Xóa cuộc bầu cử thành công!", Color.Green);
                    TaiDuLieu();
                }
                else
                {
                    HienThongBao("Không tìm thấy cuộc bầu cử để xóa!", Color.DarkRed);
                }
            }
            catch (Exception ex)
            {
                HienThongBao($"Lỗi khi xóa cuộc bầu cử: {ex.Message}", Color.DarkRed);
            }
        }

        // Đổi trạng thái khóa
        private void DoiTrangThaiKhoa(int id, bool khoa)
        {
            try
            {
                if (!File.Exists(FILE_BAUCU))
                {
                    HienThongBao("File dữ liệu không tồn tại!", Color.DarkRed);
                    return;
                }

                string[] lines = File.ReadAllLines(FILE_BAUCU);
                bool tim_thay = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lines[i]))
                    {
                        string[] fields = lines[i].Split(',');
                        if (fields.Length >= 6 && int.TryParse(fields[0], out int current_id) && current_id == id)
                        {
                            fields[5] = khoa.ToString();
                            lines[i] = string.Join(",", fields);
                            tim_thay = true;
                            break;
                        }
                    }
                }

                if (tim_thay)
                {
                    File.WriteAllLines(FILE_BAUCU, lines);
                    string thongbao = khoa ? "Đã khóa cuộc bầu cử thành công!" : "Đã mở khóa cuộc bầu cử thành công!";
                    HienThongBao(thongbao, Color.Green);
                    TaiDuLieu();
                }
                else
                {
                    HienThongBao("Không tìm thấy cuộc bầu cử để cập nhật!", Color.DarkRed);
                }
            }
            catch (Exception ex)
            {
                HienThongBao($"Lỗi khi cập nhật trạng thái khóa: {ex.Message}", Color.DarkRed);
            }
        }

        #endregion

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}