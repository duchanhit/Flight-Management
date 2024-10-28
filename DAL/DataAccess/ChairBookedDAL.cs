using DAL.IAccess;
using DTO.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class ChairBookedDAL : IRepository<ChairBooked>
    {
        // Lấy tất cả các ghế đã được đặt từ cơ sở dữ liệu
        public IEnumerable<ChairBooked> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.ChairBookeds.ToList();
            }
        }

        // Lấy thông tin ghế đã đặt theo ID
        public ChairBooked GetById(int chairBookedId)
        {
            using (FlightModel context = new FlightModel())
            {
                return context.ChairBookeds.SingleOrDefault(c => c.IDChairBooked == chairBookedId.ToString());
            }
        }

        // Thêm ghế đã đặt vào cơ sở dữ liệu
        public void Add(ChairBooked chairBooked)
        {
            using (FlightModel context = new FlightModel())
            {
                context.ChairBookeds.Add(chairBooked);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin ghế đã đặt
        public void Update(ChairBooked chairBooked)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingChairBooked = context.ChairBookeds.SingleOrDefault(c => c.IDChairBooked == chairBooked.IDChairBooked.ToString());
                if (existingChairBooked != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingChairBooked.FlightId = chairBooked.FlightId;
                    existingChairBooked.XPos = chairBooked.XPos;
                    existingChairBooked.YPos = chairBooked.YPos;
                    existingChairBooked.Time = chairBooked.Time;
                    existingChairBooked.TicketId = chairBooked.TicketId;
                    context.SaveChanges();
                }
            }
        }

        // Xóa ghế đã đặt khỏi cơ sở dữ liệu
        public void Delete(int chairBookedId)
        {
            using (FlightModel context = new FlightModel())
            {
                var chairBookedToDelete = context.ChairBookeds.SingleOrDefault(c => c.IDChairBooked == chairBookedId.ToString());
                if (chairBookedToDelete != null)
                {
                    context.ChairBookeds.Remove(chairBookedToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
