using DAL.IAccess;
using DTO;
using DTO.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AirportDAL : IRepository<Airport>
    {
        // Lấy tất cả các sân bay từ cơ sở dữ liệu
        public IEnumerable<Airport> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Airports.ToList();
            }
        }

        // Lấy thông tin sân bay theo ID
        public Airport GetById(int airportId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Airports.SingleOrDefault(a => a.AirportId == airportId.ToString());
            }
        }

        // Thêm sân bay vào cơ sở dữ liệu
        public void Add(Airport airport)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Airports.Add(airport);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin sân bay
        public void Update(Airport airport)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingAirport = context.Airports.SingleOrDefault(a => a.AirportId == airport.AirportId.ToString());
                if (existingAirport != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingAirport.AirportName = airport.AirportName;
                    existingAirport.CityId = airport.CityId;
                    existingAirport.lat = airport.lat;
                    existingAirport.lon = airport.lon;                
                    existingAirport.timezone = airport.timezone;
                    context.SaveChanges();
                }
            }
        }

        // Xóa sân bay khỏi cơ sở dữ liệu
        public void Delete(int airportId)
        {
            using (FlightModel context = new FlightModel())
            {
                var airportToDelete = context.Airports.SingleOrDefault(a => a.AirportId == airportId.ToString());
                if (airportToDelete != null)
                {
                    context.Airports.Remove(airportToDelete);
                    context.SaveChanges();
                }
            }
        }
    }

}
