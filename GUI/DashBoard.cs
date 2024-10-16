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
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            PanelDashBoardHighlight.BackColor = Color.Blue;
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            PanelDashBoardHighlight.BackColor = Color.Blue;
            if(PanelDashBoardHighlight.BackColor == Color.Blue) 
            {
                pannelTicketHighlight.BackColor = Color.Transparent;
                panelSchedulingHighlight.BackColor = Color.Transparent;
                pannelDonateHighlight.BackColor = Color.Transparent; 
                pannelSettingHighlight.BackColor = Color.Transparent;
                pannelFilghtHighlight.BackColor = Color.Transparent;
                pannelReportHighlight.BackColor = Color.Transparent;
            }


        }

        private void btnScheduling_Click(object sender, EventArgs e)
        {
            panelSchedulingHighlight.BackColor = Color.Blue;
            if (panelSchedulingHighlight.BackColor == Color.Blue)
            {
                pannelTicketHighlight.BackColor = Color.Transparent;
                PanelDashBoardHighlight.BackColor = Color.Transparent;
                pannelDonateHighlight.BackColor = Color.Transparent;
                pannelSettingHighlight.BackColor = Color.Transparent;
                pannelFilghtHighlight.BackColor = Color.Transparent;
                pannelReportHighlight.BackColor = Color.Transparent;
            }
        }

        private void btnSellTicket_Click(object sender, EventArgs e)
        {
            pannelTicketHighlight.BackColor = Color.Blue;
            if (pannelTicketHighlight.BackColor == Color.Blue)
            {
                panelSchedulingHighlight.BackColor = Color.Transparent;
                PanelDashBoardHighlight.BackColor = Color.Transparent;
                pannelDonateHighlight.BackColor = Color.Transparent;
                pannelSettingHighlight.BackColor = Color.Transparent;
                pannelFilghtHighlight.BackColor = Color.Transparent;
                pannelReportHighlight.BackColor = Color.Transparent;
            }
        }

        private void btnFlight_Click(object sender, EventArgs e)
        {
            pannelFilghtHighlight.BackColor = Color.Blue;
            if (pannelFilghtHighlight.BackColor == Color.Blue)
            {
                panelSchedulingHighlight.BackColor = Color.Transparent;
                PanelDashBoardHighlight.BackColor = Color.Transparent;
                pannelDonateHighlight.BackColor = Color.Transparent;
                pannelSettingHighlight.BackColor = Color.Transparent;
                pannelTicketHighlight.BackColor = Color.Transparent;
                pannelReportHighlight.BackColor = Color.Transparent;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            pannelReportHighlight.BackColor = Color.Blue;
            if (pannelReportHighlight.BackColor == Color.Blue)
            {
                panelSchedulingHighlight.BackColor = Color.Transparent;
                PanelDashBoardHighlight.BackColor = Color.Transparent;
                pannelDonateHighlight.BackColor = Color.Transparent;
                pannelSettingHighlight.BackColor = Color.Transparent;
                pannelTicketHighlight.BackColor = Color.Transparent;
                pannelFilghtHighlight.BackColor = Color.Transparent;
            }
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            pannelDonateHighlight.BackColor = Color.Blue;
            if (pannelDonateHighlight.BackColor == Color.Blue)
            {
                panelSchedulingHighlight.BackColor = Color.Transparent;
                PanelDashBoardHighlight.BackColor = Color.Transparent;
                pannelReportHighlight.BackColor = Color.Transparent;
                pannelSettingHighlight.BackColor = Color.Transparent;
                pannelTicketHighlight.BackColor = Color.Transparent;
                pannelFilghtHighlight.BackColor = Color.Transparent;
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            pannelSettingHighlight.BackColor = Color.Blue;
            if (pannelSettingHighlight.BackColor == Color.Blue)
            {
                panelSchedulingHighlight.BackColor = Color.Transparent;
                PanelDashBoardHighlight.BackColor = Color.Transparent;
                pannelReportHighlight.BackColor = Color.Transparent;
                pannelDonateHighlight.BackColor = Color.Transparent;
                pannelTicketHighlight.BackColor = Color.Transparent;
                pannelFilghtHighlight.BackColor = Color.Transparent;
            }
        }
    }
}
