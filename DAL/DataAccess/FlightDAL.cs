using DAL.IAccess;
using DTO;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class FlightDAL : IRepository<Flight>
    {
        private readonly string connectionString;
        private readonly FlightModel _context;

        public FlightDAL()
        {

            connectionString = ConfigurationManager.ConnectionStrings["FlightModel"].ConnectionString;
            _context = new FlightModel();
        }

        // Lấy tất cả các chuyến bay từ cơ sở dữ liệu
        public IEnumerable<Flight> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Flights.ToList();
            }
        }

        // Lấy thông tin chuyến bay theo ID
        public Flight GetById(string flightId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Flights.SingleOrDefault(f => f.FlightId == flightId);
            }
        }

        // Thêm chuyến bay vào cơ sở dữ liệu
        public void Add(Flight flight)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Flight (FlightId, Price, OriginAP, DestinationAP, TotalSeat, isActive, Duration, DepartureDateTime) VALUES (@FlightId, @Price, @OriginAP, @DestinationAP, @TotalSeat, @isActive, @Duration, @DepartureDateTime)", connection))
                {
                    command.Parameters.AddWithValue("@FlightId", flight.FlightId);
                    command.Parameters.AddWithValue("@Price", flight.Price);
                    command.Parameters.AddWithValue("@OriginAP", flight.OriginAP);
                    command.Parameters.AddWithValue("@DestinationAP", flight.DestinationAP);
                    command.Parameters.AddWithValue("@TotalSeat", flight.TotalSeat);
                    command.Parameters.AddWithValue("@isActive", flight.isActive);
                    command.Parameters.AddWithValue("@Duration", flight.Duration);
                    command.Parameters.AddWithValue("@DepartureDateTime", flight.DepartureDateTime ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Cập nhật thông tin chuyến bay
        public void Update(Flight flight)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingFlight = context.Flights.SingleOrDefault(f => f.FlightId == flight.FlightId);
                if (existingFlight != null)
                {
                    existingFlight.Price = flight.Price;
                    existingFlight.OriginAP = flight.OriginAP;
                    existingFlight.DestinationAP = flight.DestinationAP;
                    existingFlight.TotalSeat = flight.TotalSeat;
                    existingFlight.isActive = flight.isActive;
                    existingFlight.Duration = flight.Duration;
                    existingFlight.DepartureDateTime = flight.DepartureDateTime;
                    context.SaveChanges();
                }
            }
        }

        // Xóa chuyến bay khỏi cơ sở dữ liệu
        public void Delete(string flightId)
        {
            using (FlightModel context = new FlightModel())
            {
                var flightToDelete = context.Flights.SingleOrDefault(f => f.FlightId == flightId);
                if (flightToDelete != null)
                {
                    context.Flights.Remove(flightToDelete);
                    context.SaveChanges();
                }
            }
        }

        // Lấy danh sách các chuyến bay dưới dạng DataTable
        public DataTable GetFlightsDataTable()
        {
            var dataTable = new DataTable();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM View_FlightsWithAirportNames";

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }

        // Lấy mã sân bay dựa trên tên sân bay
        public string GetAirportCodeByName(string airportName)
        {
            string airportCode = null;

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AirportId FROM Airport WHERE AirportName = @airportName";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@airportName", airportName);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        airportCode = result.ToString();
                    }
                }
            }

            return airportCode;
        }
    }
}