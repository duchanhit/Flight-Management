using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GUI
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
            timerUpdateTemperature.Interval = 60000; // 1 phút
            timerUpdateTemperature.Tick += TimerUpdateTemperature_Tick;
            timerUpdateTemperature.Start();
        }
        // Sự kiện Timer gọi hàm cập nhật nhiệt độ
        private async void TimerUpdateTemperature_Tick(object sender, EventArgs e)
        {
            await UpdateWeatherAsync();
        }

        // Hàm để cập nhật thông tin thời tiết
        private async Task UpdateWeatherAsync()
        {
            string city = "Ho+Chi+Minh"; // Thay bằng thành phố mong muốn
            string weatherInfo = await GetWeatherInfoAsync(city);

            if (!string.IsNullOrEmpty(weatherInfo))
            {
                // Hiển thị thông tin thời tiết trong các TextBox hoặc Label
                lblWeatherInfo.Text = weatherInfo; // Hoặc phân tích chi tiết JSON để gán cho các TextBox khác nhau
            }
        }

        // Hàm gọi API để lấy thông tin thời tiết từ wttr.in
        private async Task<string> GetWeatherInfoAsync(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://wttr.in/{city}?format=%C+%t+%h+%w"; // %C: trạng thái thời tiết, %t: nhiệt độ, %h: độ ẩm, %w: tốc độ gió
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    MessageBox.Show("Không thể lấy dữ liệu thời tiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}
