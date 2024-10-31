using DAL;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS
{
    public class PassengerBUS
    {
        private readonly PassengerDAL _passengerDAL;

        // Constructor
        public PassengerBUS()
        {
            _passengerDAL = new PassengerDAL();
        }

        // Method to get all passengers
        public IEnumerable<Passenger> GetAllPassengers()
        {
            return _passengerDAL.GetAll();
        }

        // Method to get a passenger by ID
        public Passenger GetPassengerById(int id)
        {
            return _passengerDAL.GetById(id);
        }

        // Method to add a new passenger
        public void AddPassenger(Passenger passenger)
        {
            _passengerDAL.Add(passenger);
        }

        // Method to update an existing passenger
        public void UpdatePassenger(Passenger passenger)
        {
            _passengerDAL.Update(passenger);
        }

        // Method to delete a passenger
        public void DeletePassenger(int id)
        {
            _passengerDAL.Delete(id);
        }
    }
}
