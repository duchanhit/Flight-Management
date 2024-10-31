using DAL;
using DAL.DataAccess;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class ChairBookedBUS
    {
        private readonly ChairBookedDAL _chairBookedDAL;

        // Constructor
        public ChairBookedBUS()
        {
            _chairBookedDAL = new ChairBookedDAL();
        }

        // Method to get all booked chairs
        public IEnumerable<ChairBooked> GetAllBookedChairs()
        {
            return _chairBookedDAL.GetAll();
        }

        // Method to get a booked chair by ID
        public ChairBooked GetBookedChairById(int id)
        {
            return _chairBookedDAL.GetById(id);
        }

        // Method to add a new booked chair
        public void AddBookedChair(ChairBooked chairBooked)
        {
            _chairBookedDAL.Add(chairBooked);
        }

        // Method to update an existing booked chair
        public void UpdateBookedChair(ChairBooked chairBooked)
        {
            _chairBookedDAL.Update(chairBooked);
        }

        // Method to delete a booked chair
        public void DeleteBookedChair(int id)
        {
            _chairBookedDAL.Delete(id);
        }
    }
}
