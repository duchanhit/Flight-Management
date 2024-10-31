// DAL/RestrictionsDAL.cs
using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class RestrictionsDAL
    {
        private string connectionString;

        public RestrictionsDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["FlightModel"].ConnectionString;
        }

        public bool SaveRestrictions(TimeSpan minFlightTime, int maxTransit, TimeSpan minTransitTime, TimeSpan maxTransitTime, int latestBookingTime, int latestCancelingTime)
        {
            string query = "INSERT INTO Restrictions (MinFlightTime, MaxTransit, MinTransitTime, MaxTransitTime, LatestBookingTime, LatestCancelingTime) " +
                           "VALUES (@MinFlightTime, @MaxTransit, @MinTransitTime, @MaxTransitTime, @LatestBookingTime, @LatestCancelingTime)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MinFlightTime", minFlightTime);
                    cmd.Parameters.AddWithValue("@MaxTransit", maxTransit);
                    cmd.Parameters.AddWithValue("@MinTransitTime", minTransitTime);
                    cmd.Parameters.AddWithValue("@MaxTransitTime", maxTransitTime);
                    cmd.Parameters.AddWithValue("@LatestBookingTime", latestBookingTime);
                    cmd.Parameters.AddWithValue("@LatestCancelingTime", latestCancelingTime);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
