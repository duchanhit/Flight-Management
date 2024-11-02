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
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI.Control
{
    public partial class DashboardControl : UserControl
    {
        private DashboardBUS dashboardBUS;
        private string[] messages = {
    "Khu vực Cầu Giấy, Hà Nội, VN: 28°C, trời nhiều mây.",
    "Quận 1, TP Hồ Chí Minh, VN: 32°C, nắng gắt, khuyến cáo tránh ra ngoài vào giữa trưa.",
    "Thành phố Đà Nẵng, VN: 26°C, mưa nhẹ suốt ngày, nhớ mang ô khi ra ngoài.",
    "Thị trấn Sa Pa, Lào Cai, VN: 18°C, sương mù dày đặc vào sáng sớm.",
    "Phố cổ Hội An, Quảng Nam, VN: 30°C, trời trong xanh, thích hợp để dạo phố.",
    "Quận Hải Châu, Đà Nẵng, VN: 27°C, gió nhẹ, trời mát mẻ dễ chịu.",
    "Khu vực Tây Hồ, Hà Nội, VN: 25°C, nhiều mây, có thể có mưa vào chiều tối.",
    "Thành phố Vũng Tàu, Bà Rịa - Vũng Tàu, VN: 29°C, gió mạnh, có sóng lớn tại bờ biển.",
    "Huyện Đức Trọng, Lâm Đồng, VN: 22°C, trời se lạnh, thích hợp để ngắm cảnh thiên nhiên.",
    "Quận Bình Thạnh, TP Hồ Chí Minh, VN: 31°C, trời trong xanh, ít mây.",
    "Thị xã Cửa Lò, Nghệ An, VN: 28°C, nắng đẹp, biển lặng sóng, rất thích hợp để tắm biển.",
    "Quận Liên Chiểu, Đà Nẵng, VN: 27°C, trời âm u, có thể có mưa rào.",
    "Huyện Mộc Châu, Sơn La, VN: 20°C, trời mát, sương mù vào buổi sáng.",
    "Thành phố Thủ Dầu Một, Bình Dương, VN: 30°C, trời nắng nhẹ, không khí khô ráo.",
    "Khu vực Phú Mỹ Hưng, TP Hồ Chí Minh, VN: 32°C, nóng ẩm, nhiệt độ cao vào buổi trưa.",
    "Phố núi Pleiku, Gia Lai, VN: 24°C, trời mát mẻ, gió nhẹ, không khí trong lành.",
    "Thành phố Huế, Thừa Thiên - Huế, VN: 28°C, trời trong xanh, có thể có nắng nhẹ.",
    "Huyện Bát Xát, Lào Cai, VN: 17°C, lạnh, có mưa phùn và sương mù dày đặc.",
    "Thành phố Phan Thiết, Bình Thuận, VN: 30°C, trời nắng, thích hợp để nghỉ dưỡng.",
    "Thành phố Cần Thơ, VN: 29°C, mây thưa, nắng nhẹ vào buổi chiều."


        };
        public DashboardControl DashboardControlInstance { get; private set; }
        private Random random = new Random();
        public void SetUsername(string username)
        {
            lblUser.Text = username; // Gắn tên người dùng vào label lblUser
        }



        public DashboardControl()
        {
            InitializeComponent();
            dashboardBUS = new DashboardBUS();

            // Cập nhật các nhãn với dữ liệu cần thiết
            UpdateDashboardData();
            // Gọi hàm để cập nhật dữ liệu cho các nhãn

            
        }
        private void DisplayRandomMessage()
        {
            // Select a random index from the array
            int index = random.Next(messages.Length);
            // Set the text of the label to the randomly selected message
            lblWeather.Text = messages[index];
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

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            DisplayRandomMessage();
        }
    }
}
