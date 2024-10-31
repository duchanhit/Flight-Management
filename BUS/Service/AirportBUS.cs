using DAL;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class AirportBUS
    {
        private readonly AirportDAL _airportDAL;

        // Constructor
        public AirportBUS()
        {
            _airportDAL = new AirportDAL();
        }

        // Method to get all airports
        public IEnumerable<Airport> GetAllAirports()
        {
            return _airportDAL.GetAll();
        }

        // Method to get an airport by ID
        public Airport GetAirportById(int airportId)
        {
            return _airportDAL.GetById(airportId);
        }

        // Method to add a new airport
        public void AddAirport(Airport airport)
        {
            _airportDAL.Add(airport);
        }

        // Method to update an existing airport
        public void UpdateAirport(Airport airport)
        {
            _airportDAL.Update(airport);
        }

        // Method to delete an airport
        public void DeleteAirport(int airportId)
        {
            _airportDAL.Delete(airportId);
        }
    }
}
