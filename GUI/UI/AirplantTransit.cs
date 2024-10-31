using BUS.Service;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class AirplantTransit : Form
    {
        private List<Tuple<string, TimeSpan?, string>> transitDataList; // Danh sách tạm lưu sân bay, thời gian và ghi chú
        public event Action<List<Tuple<string, TimeSpan?, string>>> TransitListUpdated;
        private AirportBUS _airportBUS;
        public AirplantTransit()
        {
            InitializeComponent();

            transitDataList = new List<Tuple<string, TimeSpan?, string>>(); // Khởi tạo danh sách tạm

            _airportBUS = new AirportBUS(); // Khởi tạo AirportBUS
            LoadAirportIds(); // Gọi hàm để load dữ liệu vào ComboBox
        }
        private void LoadAirportIds()
        {
            try
            {
                // Lấy danh sách tất cả các sân bay
                List<Airport> airports = _airportBUS.GetAllAirports().ToList();

                // Thiết lập dữ liệu nguồn cho ComboBox
                cmbAirport.DataSource = airports;
                cmbAirport.DisplayMember = "AirportId"; // Hiển thị ID sân bay
                cmbAirport.ValueMember = "AirportId";   // Giá trị cũng là ID sân bay

                cmbAirport.IntegralHeight = false;
                cmbAirport.MaxDropDownItems = 10;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách ID sân bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeTextBox()
        {
            txtTime.BorderThickness = 0;
            txtTime.FillColor = Color.White; // Nền trắng
            txtTime.ForeColor = Color.Black; // Chữ đen
            txtTime.PlaceholderText = "1:00"; // Văn bản mẫu (placeholder)
            txtTime.PlaceholderForeColor = Color.Black; // Màu placeholder
        }

        private Guna.UI2.WinForms.Guna2Panel CreateUnderlinePanel()
        {
            Guna.UI2.WinForms.Guna2Panel underlinePanel = new Guna.UI2.WinForms.Guna2Panel();
            underlinePanel.Height = 2; // Chiều cao viền
            underlinePanel.Dock = DockStyle.Bottom;
            underlinePanel.FillColor = Color.Black; // Màu đen cho viền dưới
            return underlinePanel;
        }

        private void AddUnderlineToTextBox()
        {
            Guna.UI2.WinForms.Guna2Panel underlinePanel = CreateUnderlinePanel();
            txtTime.Controls.Add(underlinePanel); // Thêm viền dưới vào TextBox
        }

        private void AirplantTransit_Load(object sender, EventArgs e)
        {
            InitializeTextBox();
            AddUnderlineToTextBox();

        }

        // Phương thức để lấy danh sách tạm, có thể dùng ở form khác
        public List<Tuple<string, TimeSpan?, string>> GetTransitDataList()
        {
            return transitDataList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy thông tin sân bay, thời gian và ghi chú từ người dùng
            string airport = cmbAirport.SelectedValue.ToString();
            TimeSpan? time = TimeSpan.TryParse(txtTime.Text, out TimeSpan parsedTime) ? parsedTime : (TimeSpan?)null;
            string note = txtNote.Text;

            // Thêm bộ ba thông tin vào danh sách tạm
            transitDataList.Add(new Tuple<string, TimeSpan?, string>(airport, time, note));

            // Gọi sự kiện để cập nhật dữ liệu sang form SchedulingControl
            TransitListUpdated?.Invoke(transitDataList);

            // Hiển thị thông báo thành công
            MessageBox.Show("Đã lưu thông tin trung chuyển vào danh sách tạm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset các ô nhập liệu để người dùng có thể tiếp tục thêm mới
            cmbAirport.SelectedIndex = -1;
            txtTime.Clear();
            txtNote.Clear();

        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Gọi sự kiện TransitListUpdated để truyền danh sách transitDataList cho form khác
            TransitListUpdated?.Invoke(transitDataList);
            this.Close(); // Đóng form sau khi xác nhận
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
