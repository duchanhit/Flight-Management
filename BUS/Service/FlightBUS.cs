using DAL;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS
{
    public class FlightBUS
    {
        private readonly FlightDAL _flightDAL;

        // Constructor
        public FlightBUS()
        {
            _flightDAL = new FlightDAL();
        }

        // Method to get all flights
        public IEnumerable<Flight> GetAllFlights()
        {
            return _flightDAL.GetAll();
        }

        // Method to get flight by ID
        public Flight GetFlightById(string flightId)
        {
            return _flightDAL.GetById(flightId);
        }

        // Method to add a new flight
        public void AddFlight(Flight flight)
        {
            _flightDAL.Add(flight);
        }

        // Method to update an existing flight
        public void UpdateFlight(Flight flight)
        {
            _flightDAL.Update(flight);
        }

        // Method to delete a flight (disable it)
        public void DeleteFlight(string flightId)
        {
            _flightDAL.Delete(flightId);
        }
    }
}
