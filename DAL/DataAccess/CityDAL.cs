using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class CityDAL : IRepository<City>
    {
        // Lấy tất cả các thành phố từ cơ sở dữ liệu
        public IEnumerable<City> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Cities.ToList();
            }
        }

        // Lấy thông tin thành phố theo ID
        public City GetById(string cityId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Cities.SingleOrDefault(c => c.CityId == cityId.ToString());
            }
        }

        // Thêm thành phố vào cơ sở dữ liệu
        public void Add(City city)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Cities.Add(city);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin thành phố
        public void Update(City city)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingCity = context.Cities.SingleOrDefault(c => c.CityId == city.CityId.ToString());
                if (existingCity != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingCity.CityName = city.CityName;
                    existingCity.countryname = city.countryname;
                    context.SaveChanges();
                }
            }
        }

        // Xóa thành phố khỏi cơ sở dữ liệu
        public void Delete(string cityId)
        {
            using (FlightModel context = new FlightModel())
            {
                var cityToDelete = context.Cities.SingleOrDefault(c => c.CityId == cityId.ToString());
                if (cityToDelete != null)
                {
                    context.Cities.Remove(cityToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
