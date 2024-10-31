using DAL;
using DAL.DataAccess;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class DurationFlightBUS
    {
        private readonly DurationFlightDAL _durationFlightDAL;

        // Constructor
        public DurationFlightBUS()
        {
            _durationFlightDAL = new DurationFlightDAL();
        }

        // Method to get all duration flights
        public IEnumerable<DurationFlight> GetAllDurationFlights()
        {
            return _durationFlightDAL.GetAll();
        }

        // Method to get a duration flight by ID
        public DurationFlight GetDurationFlightById(int id)
        {
            return _durationFlightDAL.GetById(id);
        }

        // Method to add a new duration flight
        public void AddDurationFlight(DurationFlight flight)
        {
            _durationFlightDAL.Add(flight);
        }

        // Method to update an existing duration flight
        public void UpdateDurationFlight(DurationFlight flight)
        {
            _durationFlightDAL.Update(flight);
        }

        // Method to delete a duration flight
        public void DeleteDurationFlight(int id)
        {
            _durationFlightDAL.Delete(id);
        }
    }
}
