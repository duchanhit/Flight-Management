using DAL.IAccess;
using DTO;
using DTO.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FlightDAL : IRepository<Flight>
    {
        // Lấy tất cả các chuyến bay từ cơ sở dữ liệu
        public IEnumerable<Flight> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Flights.ToList();
            }
        }

        // Lấy thông tin chuyến bay theo ID
        public Flight GetById(int flightId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Flights.SingleOrDefault(f => f.FlightId == flightId.ToString());
            }
        }

        // Thêm chuyến bay vào cơ sở dữ liệu
        public void Add(Flight flight)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Flights.Add(flight);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin chuyến bay
        public void Update(Flight flight)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingFlight = context.Flights.SingleOrDefault(f => f.FlightId == flight.FlightId);
                if (existingFlight != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingFlight.Price = flight.Price;
                    existingFlight.OriginAP = flight.OriginAP;
                    existingFlight.DestinationAP = flight.DestinationAP;
                    existingFlight.TotalSeat = flight.TotalSeat;
                    existingFlight.isActive = flight.isActive;
                    existingFlight.Duration = flight.Duration;
                    context.SaveChanges();
                }
            }
        }

        // Xóa chuyến bay khỏi cơ sở dữ liệu
        public void Delete(int flightId)
        {
            using (FlightModel context = new FlightModel())
            {
                var flightToDelete = context.Flights.SingleOrDefault(f => f.FlightId == flightId.ToString());
                if (flightToDelete != null)
                {
                    context.Flights.Remove(flightToDelete);
                    context.SaveChanges();
                }
            }
        }
    }


}
