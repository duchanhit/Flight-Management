using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PassengerBUS
    {
        private PassengerDAL passengerDAL = new PassengerDAL();

        public List<Passenger> GetAllPassengers()
        {
            return passengerDAL.GetAllPassengers();
        }

        public Passenger GetPassengerById(int passengerId)
        {
            return passengerDAL.GetPassengerById(passengerId);
        }

        public void AddPassenger(Passenger passenger)
        {
            passengerDAL.AddPassenger(passenger);
        }

        public void UpdatePassenger(Passenger passenger)
        {
            passengerDAL.UpdatePassenger(passenger);
        }

        public void DeletePassenger(int passengerId)
        {
            passengerDAL.DeletePassenger(passengerId);
        }
    }

}
