// DAL/DashboardDAL.cs
using System;
using System.Data.SqlClient;
using System.Configuration;
using DTO.Entities;
using System.Linq;

namespace DAL
{
    public class DashboardDAL
    {
 
        public DashboardDAL()
        {
           
        }

        public int GetDailyTicketCount()
        {
            int ticketCount = 0;
            string query = "SELECT TotalTickets FROM View_TicketCountByDate WHERE BookingDate = CAST(GETDATE() AS DATE)";

            using (FlightModel context = new FlightModel())
            {
                try
                {
                    // Use context.Database.SqlQuery<T>() for raw SQL queries
                    var result = context.Database.SqlQuery<int?>(query).FirstOrDefault();
                    ticketCount = result ?? 0; // If result is null, return 0
                }
                catch (Exception ex)
                {
                    // Handle exceptions (consider logging the error)
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return ticketCount;
        }


        public decimal GetDailyRevenue()
        {
            decimal dailyRevenue = 0;
            string query = "SELECT TotalRevenue FROM View_TotalRevenueByDate WHERE BookingDate = CAST(GETDATE() AS DATE)";

            using (FlightModel context = new FlightModel())
            {
                try
                {
                    // Use context.Database.SqlQuery<T>() for raw SQL queries
                    var result = context.Database.SqlQuery<decimal?>(query).FirstOrDefault();
                    dailyRevenue = result ?? 0; // If result is null, return 0
                }
                catch (Exception ex)
                {
                    // Handle exceptions (consider logging the error)
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return dailyRevenue;
        }

    }
}
