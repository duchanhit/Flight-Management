using BUS;
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
    public partial class DashboardControl : UserControl
    {
        private DashboardBUS dashboardBUS;

        public DashboardControl()
        {
            InitializeComponent();
            dashboardBUS = new DashboardBUS();

            // Gọi hàm để cập nhật dữ liệu cho các nhãn
            UpdateDashboardData();
        }

        private void UpdateDashboardData()
        {
            // Lấy dữ liệu doanh thu và số vé bán từ BUS
            decimal dailyRevenue = dashboardBUS.GetDailyRevenue();
            int ticketsSoldToday = dashboardBUS.GetDailyTicketCount();

            // Gắn dữ liệu vào các nhãn
            label5.Text = $"Doanh thu trong ngày: ${dailyRevenue:N2}"; // Hiển thị doanh thu theo định dạng tiền tệ
            label3.Text = $"Số vé đã bán trong ngày: {ticketsSoldToday}";
        }


        private void panelDashBoard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
