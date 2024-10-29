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
using WinFormsControl = System.Windows.Forms.Control;

namespace GUI
{
    public partial class DashBoard : Form
    {
        DashboardControl dashboardControl = new DashboardControl();
        FlightControl flightControlMain = new FlightControl();
        SchedulingControl schedulingControl = new SchedulingControl();
        SellTicketControl sellTicketControl = new SellTicketControl();
        ReportControl reportControl = new ReportControl();
        SettingControl settingControl = new SettingControl();
        DonateControl donateControl = new DonateControl();
        #region Methods
        public DashBoard()
        {
            InitializeComponent();

        }
        private void ShowControl(UserControl controlToShow)
        {
            // Ẩn tất cả các UserControl
            foreach (WinFormsControl control in this.Controls)
            {
                if (control is UserControl)
                {
                    control.Hide();
                }
            }


            // Hiển thị UserControl được chọn
            controlToShow.Show();
            controlToShow.BringToFront();
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

        #endregion

        #region Events
        private void DashBoard_Load(object sender, EventArgs e)
        {
            PanelDashBoardHighlight.BackColor = Color.Blue;
            // Đặt DockStyle.Fill cho tất cả các UserControl
            dashboardControl.Dock = DockStyle.Fill;
            flightControlMain.Dock = DockStyle.Fill;
            schedulingControl.Dock = DockStyle.Fill;
            sellTicketControl.Dock = DockStyle.Fill;
            reportControl.Dock = DockStyle.Fill;
            settingControl.Dock = DockStyle.Fill;
            donateControl.Dock = DockStyle.Fill;

            // Thêm tất cả các UserControl vào panelDashBoard
            panelDashBoard.Controls.Add(dashboardControl);
            panelDashBoard.Controls.Add(flightControlMain);
            panelDashBoard.Controls.Add(schedulingControl);
            panelDashBoard.Controls.Add(sellTicketControl);
            panelDashBoard.Controls.Add(reportControl);
            panelDashBoard.Controls.Add(settingControl);
            panelDashBoard.Controls.Add(donateControl);

            // Hiển thị UserControl đầu tiên
            ShowControl(dashboardControl);





        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            SetHighlightPanel("dashboard");
            ShowControl(dashboardControl);

        }

        private void btnScheduling_Click(object sender, EventArgs e)
        {
            SetHighlightPanel("scheduling");
            ShowControl(schedulingControl);

        }

        private void btnSellTicket_Click(object sender, EventArgs e)
        {
            SetHighlightPanel("sellTicket");
            ShowControl(sellTicketControl);

        }

        private void btnFlight_Click(object sender, EventArgs e)
        {
            SetHighlightPanel("flight");
            ShowControl(flightControlMain);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SetHighlightPanel("report");
            ShowControl(reportControl);

        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            SetHighlightPanel("donate");
            ShowControl(donateControl);

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SetHighlightPanel("setting");
            ShowControl(settingControl);

        }



        private void flightControl1_Load(object sender, EventArgs e)
        {

        }

        private void panelDashBoard_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void schedulingControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
