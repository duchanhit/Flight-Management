using DAL;
using DAL.IAccess;
using DTO;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class FlightBUS
    {
        private readonly IRepository<Flight> _flightRepository;
        private readonly FlightDAL _flightDAL;
        // Constructor Injection
        public FlightBUS()
        {
            _flightDAL = new FlightDAL();
            _flightRepository = new FlightDAL();
        }

        // Method to get all flights
        public IEnumerable<Flight> GetAllFlights()
        {
            return _flightRepository.GetAll();
        }

        // Method to get flight by ID
        public Flight GetById(int id)
        {
            return _flightRepository.GetById(id);
        }

        // Method to add a new flight
        public void AddFlight(Flight flight)
        {
            _flightRepository.Add(flight);
        }

        // Method to update an existing flight
        public void UpdateFlight(Flight flight)
        {
            _flightRepository.Update(flight);
        }

        // Method to delete a flight
        public void DeleteFlight(int id)
        {
            _flightRepository.Delete(id);
        }

        public DataTable GetFlightsWithAirportNames()
        {
            return _flightDAL.GetFlightsDataTable();
        }
        public string GetAirportCodeByName(string airportName)
        {
            return _flightDAL.GetAirportCodeByName(airportName);
        }


    }

}
