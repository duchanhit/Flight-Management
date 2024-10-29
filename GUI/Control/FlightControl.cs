using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Control
{
    public partial class FlightControl : UserControl
    {
        public FlightControl()
        {
            InitializeComponent();
            InitializeAsync();
        }
        // Hàm khởi tạo WebView2
        private async void InitializeAsync()
        {
            // Đảm bảo WebView2 được khởi tạo
            await webViewMap.EnsureCoreWebView2Async(null);
            LoadMap();
        }

        // Hàm để tải file HTML vào WebView2
        private void LoadMap()
        {
            // Đường dẫn tuyệt đối tới file HTML
            string filePath = @"C:\Users\ducha\source\repos\duchanhit\Flight-Management\GUI\Resources\map.html";
            webViewMap.CoreWebView2.Navigate(filePath);
        }

        // Hàm để vẽ đường bay trên bản đồ bằng cách gọi hàm JavaScript trong HTML
        public void ShowFlightPath(double lat1, double lng1, double lat2, double lng2)
        {
            if (webViewMap.CoreWebView2 != null)
            {
                // Gọi hàm JavaScript `drawFlightPath` với các tham số tọa độ
                string script = $"drawFlightPath({lat1}, {lng1}, {lat2}, {lng2});";
                webViewMap.CoreWebView2.ExecuteScriptAsync(script);
            }
        }

        // Ví dụ sự kiện nút để vẽ đường bay khi nhấn nút
        private void btnShowPath_Click(object sender, EventArgs e)
        {
            double departureLat = 40.7128; // Tọa độ New York
            double departureLng = -74.0060;
            double destinationLat = 48.8566; // Tọa độ Paris
            double destinationLng = 2.3522;

            ShowFlightPath(departureLat, departureLng, destinationLat, destinationLng);
        }
    }
}
