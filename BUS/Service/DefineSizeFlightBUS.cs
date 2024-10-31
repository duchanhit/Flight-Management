using DAL;
using DAL.DataAccess;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class DefineSizeFlightBUS
    {
        private readonly DefineSizeFlightDAL _defineSizeFlightDAL;

        // Constructor
        public DefineSizeFlightBUS()
        {
            _defineSizeFlightDAL = new DefineSizeFlightDAL();
        }

        // Method to get all define size flights
        public IEnumerable<DefineSizeFlight> GetAllDefineSizeFlights()
        {
            return _defineSizeFlightDAL.GetAll();
        }

        // Method to get define size flight by ID
        public DefineSizeFlight GetDefineSizeFlightById(int id)
        {
            return _defineSizeFlightDAL.GetById(id);
        }

        // Method to add a new define size flight
        public void AddDefineSizeFlight(DefineSizeFlight defineSizeFlight)
        {
            _defineSizeFlightDAL.Add(defineSizeFlight);
        }

        // Method to update an existing define size flight
        public void UpdateDefineSizeFlight(DefineSizeFlight defineSizeFlight)
        {
            _defineSizeFlightDAL.Update(defineSizeFlight);
        }

        // Method to delete a define size flight
        public void DeleteDefineSizeFlight(int id)
        {
            _defineSizeFlightDAL.Delete(id);
        }
    }
}
