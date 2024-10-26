using GUI.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DashBoard : Form
    {
        DashboardControl dashboardControl = new DashboardControl();
        FlightControl flightControl = new FlightControl();


        public DashBoard()
        {
            InitializeComponent();

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            PanelDashBoardHighlight.BackColor = Color.Blue;
            dashboardControl.Dock = DockStyle.Fill;
            flightControl.Dock = DockStyle.Fill;

            panelDashBoard.Controls.Add(dashboardControl); 
            panelDashBoard.Controls.Add(flightControl);


            dashboardControl.BringToFront();


        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            PanelDashBoardHighlight.BackColor = Color.Blue;
            SetHighlightPanel("dashboard");

            flightControl.Hide();
            dashboardControl.Show();
            dashboardControl.BringToFront();

        }

        private void btnScheduling_Click(object sender, EventArgs e)
        {
            panelSchedulingHighlight.BackColor = Color.Blue;
            SetHighlightPanel("scheduling");
        }

        private void btnSellTicket_Click(object sender, EventArgs e)
        {
            pannelTicketHighlight.BackColor = Color.Blue;
            SetHighlightPanel("sellTicket");
        }

        private void btnFlight_Click(object sender, EventArgs e)
        {
            pannelFilghtHighlight.BackColor = Color.Blue;
            SetHighlightPanel("flight");

            dashboardControl.Hide();
            flightControl.Show();
            flightControl.BringToFront();




        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            pannelReportHighlight.BackColor = Color.Blue;
            SetHighlightPanel("report");
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            pannelDonateHighlight.BackColor = Color.Blue;
            SetHighlightPanel("donate");
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            pannelSettingHighlight.BackColor = Color.Blue;
            SetHighlightPanel("setting");
           
        }

        // Hàm để đặt các highlight cho nút
        private void SetHighlightPanel(string panelName)
        {
            // Đặt tất cả các highlight panel thành transparent
            panelSchedulingHighlight.BackColor = Color.Transparent;
            PanelDashBoardHighlight.BackColor = Color.Transparent;
            pannelDonateHighlight.BackColor = Color.Transparent;
            pannelSettingHighlight.BackColor = Color.Transparent;
            pannelTicketHighlight.BackColor = Color.Transparent;
            pannelFilghtHighlight.BackColor = Color.Transparent;
            pannelReportHighlight.BackColor = Color.Transparent;

            // Đặt panel được chọn thành màu xanh
            switch (panelName)
            {
                case "dashboard":
                    PanelDashBoardHighlight.BackColor = Color.Blue;
                    break;
                case "flight":
                    pannelFilghtHighlight.BackColor = Color.Blue;
                    break;
                case "scheduling":
                    panelSchedulingHighlight.BackColor = Color.Blue;
                    break;
                case "sellTicket":
                    pannelTicketHighlight.BackColor = Color.Blue;
                    break;
                case "report":
                    pannelReportHighlight.BackColor = Color.Blue;
                    break;
                case "donate":
                    pannelDonateHighlight.BackColor = Color.Blue;
                    break;
                case "setting":
                    pannelSettingHighlight.BackColor = Color.Blue;
                    break;
            }
        }

        private void flightControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
