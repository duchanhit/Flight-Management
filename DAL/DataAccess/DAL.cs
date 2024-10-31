using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL.DataAccess
{


    public class DAL
    {
        private readonly string _connectionString;

        public DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method to get data from a stored procedure
        private DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable result = new DataTable();
                    adapter.Fill(result);
                    return result;
                }
            }
        }

        // Insert a new flight
        public void AddFlight(string flightId, string durationFlightId, string originAP, string destinationAP, int totalSeat, decimal price, int width, int height, TimeSpan duration)
        {
            SqlParameter[] parameters = {
            new SqlParameter("@flightID", flightId),
            new SqlParameter("@durationFlightID", durationFlightId),
            new SqlParameter("@originAP", originAP),
            new SqlParameter("@destinationAP", destinationAP),
            new SqlParameter("@totalSeat", totalSeat),
            new SqlParameter("@price", price),
            new SqlParameter("@width", width),
            new SqlParameter("@height", height),
            new SqlParameter("@duration", duration)
        };

            ExecuteStoredProcedure("ProcCreateFlight", parameters);
        }

        // Update a flight
        public void UpdateFlight(string flightId, string durationID, string originApID, string destinationAPID, decimal price, int width, int height, int totalSeat, TimeSpan duration)
        {
            SqlParameter[] parameters = {
            new SqlParameter("@flightID", flightId),
            new SqlParameter("@durationID", durationID),
            new SqlParameter("@originApID", originApID),
            new SqlParameter("@destinationAPID", destinationAPID),
            new SqlParameter("@price", price),
            new SqlParameter("@width", width),
            new SqlParameter("@height", height),
            new SqlParameter("@totalSeat", totalSeat),
            new SqlParameter("@duration", duration)
        };

            ExecuteStoredProcedure("ProcUpdateFlight", parameters);
        }

        // Delete (disable) a flight
        public void DisableFlight(string flightId)
        {
            SqlParameter[] parameters = {
            new SqlParameter("@flightID", flightId)
        };

            ExecuteStoredProcedure("ProcDisableFlight", parameters);
        }

        // Get all flights
        public DataTable GetAllFlights()
        {
            return ExecuteStoredProcedure("ProcGetFlightAll");
        }

        // Insert a new passenger
        public void AddPassenger(string passengerId, string name, string idCard, string tel)
        {
            SqlParameter[] parameters = {
            new SqlParameter("@IDPassenger", passengerId),
            new SqlParameter("@PassengerName", name),
            new SqlParameter("@PassengerIDCard", idCard),
            new SqlParameter("@PassenserTel", tel)
        };

            ExecuteStoredProcedure("ProcAddPassenger", parameters);
        }

        // Get passenger info by phone number
        public DataTable GetPassengerByTel(string tel)
        {
            SqlParameter[] parameters = {
            new SqlParameter("@tel", tel)
        };

            return ExecuteStoredProcedure("GetInfoPassenger", parameters);
        }
    }

}
