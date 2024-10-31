
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class DefineSizeFlightDAL 
    {
        // Lấy tất cả các kích thước chuyến bay từ cơ sở dữ liệu
        public IEnumerable<DefineSizeFlight> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.DefineSizeFlights.ToList();
            }
        }

        // Lấy thông tin kích thước chuyến bay theo ID
        public DefineSizeFlight GetById(int defineSizeFlightId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.DefineSizeFlights.SingleOrDefault(d => d.IdFlight == defineSizeFlightId.ToString());
            }
        }

        // Thêm kích thước chuyến bay vào cơ sở dữ liệu
        public void Add(DefineSizeFlight defineSizeFlight)
        {
            using (FlightModel context = new FlightModel())
            {
                context.DefineSizeFlights.Add(defineSizeFlight);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin kích thước chuyến bay
        public void Update(DefineSizeFlight defineSizeFlight)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingDefineSizeFlight = context.DefineSizeFlights.SingleOrDefault(d => d.IdFlight == defineSizeFlight.IdFlight.ToString());
                if (existingDefineSizeFlight != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingDefineSizeFlight.width = defineSizeFlight.width;
                    existingDefineSizeFlight.height = defineSizeFlight.height;
                    

                    context.SaveChanges();
                }
            }
        }

        // Xóa kích thước chuyến bay khỏi cơ sở dữ liệu
        public void Delete(int defineSizeFlightId)
        {
            using (FlightModel context = new FlightModel())
            {
                var defineSizeFlightToDelete = context.DefineSizeFlights.SingleOrDefault(d => d.IdFlight == defineSizeFlightId.ToString());
                if (defineSizeFlightToDelete != null)
                {
                    context.DefineSizeFlights.Remove(defineSizeFlightToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
