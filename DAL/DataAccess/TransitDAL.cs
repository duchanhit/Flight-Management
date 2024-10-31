using DAL.IAccess;
using DTO;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TransitDAL : IRepository<Transit>
    {
        public IEnumerable<Transit> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Transits.ToList();
            }
        }

        // Lấy thông tin trạm trung chuyển theo ID
        public Transit GetById(string transitId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Transits.SingleOrDefault(t => t.transitID == transitId.ToString());
            }
        }

        // Thêm trạm trung chuyển vào cơ sở dữ liệu
        public void Add(Transit transit)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Transits.Add(transit);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin trạm trung chuyển
        public void Update(Transit transit)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingTransit = context.Transits.SingleOrDefault(t => t.transitID == transit.transitID.ToString());
                if (existingTransit != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingTransit.flightID = transit.flightID;
                    existingTransit.airportID = transit.airportID;
                    existingTransit.transitOrder = transit.transitOrder;
                    existingTransit.transitTime = transit.transitTime;
                    existingTransit.transitNote = transit.transitNote;
                    existingTransit.isActive = transit.isActive;
                    context.SaveChanges();
                }
            }
        }

        // Xóa trạm trung chuyển khỏi cơ sở dữ liệu
        public void Delete(string transitId)
        {
            using (FlightModel context = new FlightModel())
            {
                var transitToDelete = context.Transits.SingleOrDefault(t => t.transitID == transitId.ToString());
                if (transitToDelete != null)
                {
                    context.Transits.Remove(transitToDelete);
                    context.SaveChanges();
                }
            }
        }
    }

}
