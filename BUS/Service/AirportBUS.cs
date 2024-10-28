using DAL.IAccess;
using DTO.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class AirportBUS
    {
        private readonly IRepository<Airport> _airportRepository;

        // Constructor Injection
        public AirportBUS(IRepository<Airport> airportRepository)
        {
            _airportRepository = airportRepository;
        }

        // Method to get all airports
        public IEnumerable<Airport> GetAllAirports()
        {
            return _airportRepository.GetAll();
        }

        // Method to get airport by ID
        public Airport GetAirportById(int id)
        {
            return _airportRepository.GetById(id);
        }

        // Method to add a new airport
        public void AddAirport(Airport airport)
        {
            _airportRepository.Add(airport);
        }

        // Method to update an existing airport
        public void UpdateAirport(Airport airport)
        {
            _airportRepository.Update(airport);
        }

        // Method to delete an airport
        public void DeleteAirport(int id)
        {
            _airportRepository.Delete(id);
        }
    }
}
