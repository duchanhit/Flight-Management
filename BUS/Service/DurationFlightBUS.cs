using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class DurationFlightBUS
    {
        private readonly IRepository<DurationFlight> _durationFlightRepository;

        // Constructor Injection
        public DurationFlightBUS(IRepository<DurationFlight> flightRepository)
        {
            _durationFlightRepository = flightRepository;
        }

        // Method to get all flights
        public IEnumerable<DurationFlight> GetAllFlights()
        {
            return _durationFlightRepository.GetAll();
        }

        // Method to get flight by ID
        public DurationFlight GetById(int id)
        {
            return _durationFlightRepository.GetById(id);
        }

        // Method to add a new flight
        public void AddDurationFlight(DurationFlight flight)
        {
            _durationFlightRepository.Add(flight);
        }

        // Method to update an existing flight
        public void UpdateDurationFlight(DurationFlight flight)
        {
            _durationFlightRepository.Update(flight);
        }

        // Method to delete a flight
        public void DeleteDurationFlight(int id)
        {
            _durationFlightRepository.Delete(id);
        }
    }

}
