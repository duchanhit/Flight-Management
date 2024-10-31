// BUS/DashboardBUS.cs
using DAL;

namespace BUS
{
    public class DashboardBUS
    {
        private DashboardDAL dashboardDAL;

        public DashboardBUS()
        {
            dashboardDAL = new DashboardDAL();
        }

        public int GetDailyTicketCount()
        {
            return dashboardDAL.GetDailyTicketCount();
        }

        public decimal GetDailyRevenue()
        {
            return dashboardDAL.GetDailyRevenue();
        }
    }
}
