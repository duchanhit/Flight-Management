using DAL;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class TransitBUS
    {
        private readonly TransitDAL _transitDAL;

        // Constructor
        public TransitBUS()
        {
            _transitDAL = new TransitDAL();
        }

        // Method to get all transits
        public IEnumerable<Transit> GetAllTransits()
        {
            return _transitDAL.GetAll();
        }

        // Method to get a transit by ID
        public Transit GetTransitById(int id)
        {
            return _transitDAL.GetById(id);
        }

        // Method to add a new transit
        public void AddTransit(Transit transit)
        {
            _transitDAL.Add(transit);
        }

        // Method to update an existing transit
        public void UpdateTransit(Transit transit)
        {
            _transitDAL.Update(transit);
        }

        // Method to delete a transit
        public void DeleteTransit(int id)
        {
            _transitDAL.Delete(id);
        }

        // Custom method to save a transit with additional business logic
        public bool SaveTransit(Transit transit)
        {
            // Add any business logic here if needed
            return _transitDAL.SaveTransit(transit);
        }
    }
}
