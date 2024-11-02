using DAL;
using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class TransitBUS
    {
        private readonly IRepository<Transit> _transitRepository;
        private readonly TransitDAL _transitDAL;
        // Constructor Injection

        public TransitBUS(IRepository<Transit> transitRepository)
        {
            _transitRepository = transitRepository;
            _transitDAL = new TransitDAL();
        }
        public TransitBUS()
        {
            _transitRepository = new TransitDAL();
            _transitDAL = new TransitDAL();
        }

        // Method to get all transits
        public IEnumerable<Transit> GetAllTransits()
        {
            return _transitRepository.GetAll();
        }

        // Method to get transit by ID
        public Transit GetTransitById(string id)
        {
            return _transitRepository.GetById(id);
        }

        // Method to add a new transit
        public void AddTransit(Transit transit)
        {
            _transitRepository.Add(transit);
        }

        // Method to update an existing transit
        public void UpdateTransit(Transit transit)
        {
            _transitRepository.Update(transit);
        }

        // Method to delete a transit
        public void DeleteTransit(string id)
        {
            _transitRepository.Delete(id);
        }
        public List<Transit> GetTransitsByFlightId(string flightId)
        {
            return _transitDAL.GetTransitsByFlightId(flightId);
        }
    }
}
