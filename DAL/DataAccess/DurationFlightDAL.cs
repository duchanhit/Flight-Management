
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class DurationFlightDAL 
    {
        // Lấy tất cả các thời gian chuyến bay từ cơ sở dữ liệu
        public IEnumerable<DurationFlight> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.DurationFlights.ToList();
            }
        }

        // Lấy thông tin thời gian chuyến bay theo ID
        public DurationFlight GetById(int durationFlightId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.DurationFlights.SingleOrDefault(d => d.IDDurationFlight == durationFlightId.ToString());
            }
        }

        // Thêm thời gian chuyến bay vào cơ sở dữ liệu
        public void Add(DurationFlight durationFlight)
        {
            using (FlightModel context = new FlightModel())
            {
                context.DurationFlights.Add(durationFlight);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin thời gian chuyến bay
        public void Update(DurationFlight durationFlight)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingDurationFlight = context.DurationFlights.SingleOrDefault(d => d.IDDurationFlight == durationFlight.IDDurationFlight.ToString());
                if (existingDurationFlight != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingDurationFlight.Duration = durationFlight.Duration;
                    context.SaveChanges();
                }
            }
        }

        // Xóa thời gian chuyến bay khỏi cơ sở dữ liệu
        public void Delete(int durationFlightId)
        {
            using (FlightModel context = new FlightModel())
            {
                var durationFlightToDelete = context.DurationFlights.SingleOrDefault(d => d.IDDurationFlight == durationFlightId.ToString());
                if (durationFlightToDelete != null)
                {
                    context.DurationFlights.Remove(durationFlightToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}


