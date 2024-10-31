using DAL;
using DAL.DataAccess;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class CityBUS
    {
        private readonly CityDAL _cityDAL;

        // Constructor
        public CityBUS()
        {
            _cityDAL = new CityDAL();
        }

        // Method to get all cities
        public IEnumerable<City> GetAllCities()
        {
            return _cityDAL.GetAll();
        }

        // Method to get a city by ID
        public City GetCityById(int id)
        {
            return _cityDAL.GetById(id);
        }

        // Method to add a new city
        public void AddCity(City city)
        {
            _cityDAL.Add(city);
        }

        // Method to update an existing city
        public void UpdateCity(City city)
        {
            _cityDAL.Update(city);
        }

        // Method to delete a city
        public void DeleteCity(int id)
        {
            _cityDAL.Delete(id);
        }
    }
}
