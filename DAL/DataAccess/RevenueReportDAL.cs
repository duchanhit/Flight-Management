using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.DataAccess
{
    public class RevenueDAL
    {
        private readonly string _connectionString;

        public RevenueDAL()
        {
            // Lấy chuỗi kết nối từ file cấu hình
            _connectionString = ConfigurationManager.ConnectionStrings["FlightModel"].ConnectionString;
        }

        public DataTable LoadRevenueReport()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM RevenueReport ORDER BY TotalRevenue DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable revenueData = new DataTable();
                    adapter.Fill(revenueData);
                    return revenueData;
                }
            }
            catch (Exception ex)
            {
                // Ném ngoại lệ lên tầng trên để xử lý
                throw new Exception("Lỗi khi tải dữ liệu từ DAL: " + ex.Message);
            }
        }

        public DataTable LoadRevenueReportByYear(int year)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    // Truy vấn từ View và lọc theo năm
                    string query = @"
                SELECT Tháng, [Số chuyến bay], [Lợi nhuận (VNĐ)], [Tỷ lệ (%)]
                FROM RevenueReportByYear
                WHERE Năm = @Year
                ORDER BY Tháng";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Year", year);

                    DataTable revenueData = new DataTable();
                    adapter.Fill(revenueData);
                    return revenueData;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu từ DAL: " + ex.Message);
            }
        }


    }
}
