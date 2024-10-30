using DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class RevenueBUS
    {
        private readonly RevenueDAL _revenueDAL;

        public RevenueBUS()
        {
            _revenueDAL = new RevenueDAL();
        }

        public DataTable LoadRevenueReport()
        {
            // Gọi phương thức từ lớp DAL để lấy dữ liệu
            return _revenueDAL.LoadRevenueReport();
        }
        public DataTable LoadRevenueReportByYear(int year)
        {
            // Gọi phương thức từ lớp DAL để lấy dữ liệu
            return _revenueDAL.LoadRevenueReportByYear(year);
        }

    }
}
