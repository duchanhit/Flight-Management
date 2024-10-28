using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class ChairBookedBUS
    {
        private readonly IRepository<ChairBooked> _chairBookedRepository;

        // Constructor Injection
        public ChairBookedBUS(IRepository<ChairBooked> chairBookedRepository)
        {
            _chairBookedRepository = chairBookedRepository;
        }

        // Method to get all booked chairs
        public IEnumerable<ChairBooked> GetAllBookedChairs()
        {
            return _chairBookedRepository.GetAll();
        }

        // Method to get booked chair by ID
        public ChairBooked GetBookedChairById(int id)
        {
            return _chairBookedRepository.GetById(id);
        }

        // Method to add a new booked chair
        public void AddBookedChair(ChairBooked chairBooked)
        {
            _chairBookedRepository.Add(chairBooked);
        }

        // Method to update an existing booked chair
        public void UpdateBookedChair(ChairBooked chairBooked)
        {
            _chairBookedRepository.Update(chairBooked);
        }

        // Method to delete a booked chair
        public void DeleteBookedChair(int id)
        {
            _chairBookedRepository.Delete(id);
        }
    }
}
