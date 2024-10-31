using DAL;
using DAL.IAccess;
using DTO;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PassengerBUS
    {
        private readonly IRepository<Passenger> _passengerRepository;

        // Constructor Injection
        public PassengerBUS(IRepository<Passenger> passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        // Method to get all passengers
        public IEnumerable<Passenger> GetAllPassengers()
        {
            return _passengerRepository.GetAll();
        }

        // Method to get passenger by ID
        public Passenger GetPassengerById(string id)
        {
            return _passengerRepository.GetById(id);
        }

        // Method to add a new passenger
        public void AddPassenger(Passenger passenger)
        {
            _passengerRepository.Add(passenger);
        }

        // Method to update an existing passenger
        public void UpdatePassenger(Passenger passenger)
        {
            _passengerRepository.Update(passenger);
        }

        // Method to delete a passenger
        public void DeletePassenger(string id)
        {
            _passengerRepository.Delete(id);
        }
    }

}
