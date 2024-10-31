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
    public class CityBUS
    {
        private readonly IRepository<City> _cityRepository;

        // Constructor Injection
        public CityBUS ()
        {
            _cityRepository = new CityDAL();
        }
        public CityBUS(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // Method to get all cities
        public IEnumerable<City> GetAllCities()
        {
            return _cityRepository.GetAll();
        }

        // Method to get city by ID
        public City GetCityById(string id)
        {
            return _cityRepository.GetById(id);
        }

        // Method to add a new city
        public void AddCity(City city)
        {
            _cityRepository.Add(city);
        }

        // Method to update an existing city
        public void UpdateCity(City city)
        {
            _cityRepository.Update(city);
        }

        // Method to delete a city
        public void DeleteCity(string id)
        {
            _cityRepository.Delete(id);
        }
    }
}
