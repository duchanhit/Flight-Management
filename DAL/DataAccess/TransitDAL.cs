using DAL.IAccess;
using DTO;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TransitDAL : IRepository<Transit>
    {
        private readonly string connectionString;
        private readonly FlightModel _context;
        private readonly string _connectionString;

        // Constructor nhận connectionString
        public TransitDAL()
        {

            connectionString = ConfigurationManager.ConnectionStrings["FlightModel"].ConnectionString;
            _context = new FlightModel();
        }

        public IEnumerable<Transit> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Transits.ToList();
            }
        }

        // Lấy thông tin trạm trung chuyển theo ID
        public Transit GetById(string transitId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Transits.SingleOrDefault(t => t.transitID == transitId.ToString());
            }
        }

        // Thêm trạm trung chuyển vào cơ sở dữ liệu
        public void Add(Transit transit)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Transits.Add(transit);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin trạm trung chuyển
        public void Update(Transit transit)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingTransit = context.Transits.SingleOrDefault(t => t.transitID == transit.transitID.ToString());
                if (existingTransit != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingTransit.flightID = transit.flightID;
                    existingTransit.airportID = transit.airportID;
                    existingTransit.transitOrder = transit.transitOrder;
                    existingTransit.transitTime = transit.transitTime;
                    existingTransit.transitNote = transit.transitNote;
                    existingTransit.isActive = transit.isActive;
                    context.SaveChanges();
                }
            }
        }

        // Xóa trạm trung chuyển khỏi cơ sở dữ liệu
        public void Delete(string transitId)
        {
            using (FlightModel context = new FlightModel())
            {
                var transitToDelete = context.Transits.SingleOrDefault(t => t.transitID == transitId.ToString());
                if (transitToDelete != null)
                {
                    context.Transits.Remove(transitToDelete);
                    context.SaveChanges();
                }
            }
        }




        public List<Transit> GetTransitsByFlightId(string flightId)
        {
            List<Transit> transitList = new List<Transit>();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT 
            transitID,
            airportID,
            transitTime,
            transitNote,
            flightID
        FROM 
            Transit
        WHERE 
            flightID = @flightId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@flightId", SqlDbType.NVarChar).Value = (object)flightId ?? DBNull.Value;


                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transit transit = new Transit
                            {
                                transitID = reader["transitID"].ToString(),
                                airportID = reader["airportID"].ToString(),
                                transitTime = reader["transitTime"] as TimeSpan?,
                                transitNote = reader["transitNote"].ToString(),
                                flightID = reader["flightID"].ToString()
                            };

                            transitList.Add(transit);
                        }
                    }
                }
            }

            return transitList;
        }



    }

}
