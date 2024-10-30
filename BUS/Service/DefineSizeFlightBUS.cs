using DAL.DataAccess;
using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class DefineSizeFlightBUS
    {
        private readonly IRepository<DefineSizeFlight> _defineSizeFlightRepository;

        // Constructor Injection
        public DefineSizeFlightBUS(IRepository<DefineSizeFlight> defineSizeFlightRepository)
        {
            _defineSizeFlightRepository = defineSizeFlightRepository;
        }

        // Method to get all define size flights
        public DefineSizeFlightBUS()
        {
            _defineSizeFlightRepository = new DefineSizeFlightDAL();
        }

        // Method to get define size flight by ID
        public DefineSizeFlight GetDefineSizeFlightById(int id)
        {
            return _defineSizeFlightRepository.GetById(id);
        }

        // Method to add a new define size flight
        public void AddDefineSizeFlight(DefineSizeFlight defineSizeFlight)
        {
            _defineSizeFlightRepository.Add(defineSizeFlight);
        }

        // Method to update an existing define size flight
        public void UpdateDefineSizeFlight(DefineSizeFlight defineSizeFlight)
        {
            _defineSizeFlightRepository.Update(defineSizeFlight);
        }

        // Method to delete a define size flight
        public void DeleteDefineSizeFlight(int id)
        {
            _defineSizeFlightRepository.Delete(id);
        }
    }
}
