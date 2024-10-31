
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class FlightDAL 
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["FlightModel"].ConnectionString;

        // Get all flights
        public IEnumerable<Flight> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("ProcGetFlightAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        var flights = new List<Flight>();
                        while (reader.Read())
                        {
                            flights.Add(new Flight
                            {
                                FlightId = reader["FlightId"].ToString(),
                                OriginAP = reader["OriginAP"].ToString(),
                                DestinationAP = reader["DestinationAP"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                TotalSeat = Convert.ToInt32(reader["TotalSeat"]),
                                isActive = Convert.ToInt32(reader["isActive"]),
                            });
                        }
                        return flights;
                    }
                }
            }
        }

        // Get flight by ID
        public Flight GetById(string flightId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("ProcGetFlightInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@flightId", flightId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Flight
                            {
                                FlightId = flightId,
                                OriginAP = reader["originAp"].ToString(),
                                DestinationAP = reader["destinationAp"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                TotalSeat = Convert.ToInt32(reader["TotalSeat"]),
                                isActive = Convert.ToInt32(reader["isActive"]),
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Add a new flight
        public void Add(Flight flight)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("ProcCreateFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@flightID", flight.FlightId);
                    command.Parameters.AddWithValue("@originAP", flight.OriginAP);
                    command.Parameters.AddWithValue("@destinationAP", flight.DestinationAP);
                    command.Parameters.AddWithValue("@totalSeat", flight.TotalSeat);
                    command.Parameters.AddWithValue("@price", flight.Price);
                    command.Parameters.AddWithValue("@isActive", flight.isActive);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Update an existing flight
        public void Update(Flight flight)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("ProcUpdateFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@flightID", flight.FlightId);
                    command.Parameters.AddWithValue("@originApID", flight.OriginAP);
                    command.Parameters.AddWithValue("@destinationAPID", flight.DestinationAP);
                    command.Parameters.AddWithValue("@price", flight.Price);
                    command.Parameters.AddWithValue("@totalSeat", flight.TotalSeat);
                    command.Parameters.AddWithValue("@isActive", flight.isActive);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete a flight (disable it)
        public void Delete(string flightId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("ProcDisableFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@flightID", flightId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
