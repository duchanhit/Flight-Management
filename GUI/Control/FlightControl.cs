using BUS;
using BUS.Service;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Control
{
    public partial class FlightControl : UserControl
    {
        private CityBUS _cityBus;
        private FlightBUS _flightBus;

        public FlightControl()
        {
            InitializeComponent();
            _cityBus = new CityBUS();
            _flightBus = new FlightBUS();

            // Thiết lập chiều cao tiêu đề cột
            dgvList.ColumnHeadersHeight = 20;

            LoadAirports();
            LoadAllFlights();
            LoadMap(); // Tải bản đồ vào WebView2

            // Đăng ký sự kiện SelectedIndexChanged cho cmbCity
            cmbCity.SelectedIndexChanged += CmbCity_SelectedIndexChanged;
        }

        private async void LoadMap()
        {
            // Đảm bảo rằng WebView2 đã được khởi tạo
            await webViewMap.EnsureCoreWebView2Async(null);

            // Đường dẫn tuyệt đối đến file HTML
            string filePath = @"file:///C:/Users/ducha/Desktop/NGU/GUI/Resources/map.html";
            webViewMap.CoreWebView2.Navigate(filePath);
        }

        public void ShowFlightPath(double lat1, double lng1, double lat2, double lng2)
        {
            // Kiểm tra WebView2 đã khởi tạo xong chưa
            if (webViewMap.CoreWebView2 != null)
            {
                // Gọi hàm JavaScript `drawFlightPath` trong file HTML để vẽ đường bay
                string script = $"drawFlightPath({lat1}, {lng1}, {lat2}, {lng2});";
                webViewMap.CoreWebView2.ExecuteScriptAsync(script);
            }
        }

        private void LoadAirports()
        {
            try
            {
                var cities = _cityBus.GetAllCities();
                cmbCity.DataSource = cities.ToList();
                cmbCity.DisplayMember = "CityName";
                cmbCity.ValueMember = "CityId";
                cmbCity.DropDownHeight = 200;
                cmbCity.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thành phố: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCity.SelectedIndex == -1)
            {
                LoadAllFlights();
                return;
            }

            string selectedCityId = cmbCity.SelectedValue.ToString();
            LoadFlightsByCity(selectedCityId);
        }

        private void LoadAllFlights()
        {
            try
            {
                DataTable flightsTable = _flightBus.GetFlightsWithAirportNames();
                BindFlightsToDataGridView(flightsTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFlightsByCity(string cityId)
        {
            try
            {
                DataTable flightsTable = _flightBus.GetFlightsByCityIds(cityId);
                BindFlightsToDataGridView(flightsTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chuyến bay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindFlightsToDataGridView(DataTable flightsTable)
        {
            dgvList.Columns.Clear();
            dgvList.AutoGenerateColumns = false;

            dgvList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điểm khởi hành",
                DataPropertyName = "OriginAP",
                Width = 120
            });

            dgvList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điểm kết thúc",
                DataPropertyName = "DestinationAP",
                Width = 120
            });

            dgvList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thời gian",
                DataPropertyName = "Duration",
                Width = 80
            });

            dgvList.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Transit",
                DataPropertyName = "TransitCount",
                Width = 100
            });

            dgvList.DataSource = flightsTable;
        }

        private void panelFlightList_Paint(object sender, PaintEventArgs e)
        {
            // Thực hiện các thao tác tùy chỉnh vẽ nếu cần
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
