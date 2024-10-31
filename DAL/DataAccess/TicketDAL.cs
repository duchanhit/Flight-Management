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
    public class TicketDAL : IRepository<Ticket>
    {
        // Lấy tất cả vé từ cơ sở dữ liệu
        public IEnumerable<Ticket> GetAll()
        {
            using (FlightModel context = new FlightModel())
            {
                return context.Tickets.ToList();
            }
        }

        // Lấy thông tin vé theo ID từ cơ sở dữ liệu
        public Ticket GetById(string ticketId)
        {
            using (FlightModel context = new FlightModel())
            {
                string ticketIdString = ticketId.ToString();
                return context.Tickets.SingleOrDefault(t => t.TicketId == ticketIdString);
            }
        }

        // Thêm vé mới vào cơ sở dữ liệu
        public void Add(Ticket ticket)
        {
            using (FlightModel context = new FlightModel())
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
            }
        }

        // Cập nhật thông tin vé trong cơ sở dữ liệu
        public void Update(Ticket ticket)
        {
            using (FlightModel context = new FlightModel())
            {
                var existingTicket = context.Tickets.SingleOrDefault(t => t.TicketId == ticket.TicketId);
                if (existingTicket != null)
                {
                    // Cập nhật các thuộc tính cần thiết
                    existingTicket.TicketIDPassenger = ticket.TicketIDPassenger;
                    existingTicket.ClassId = ticket.ClassId;
                    existingTicket.FlightId = ticket.FlightId;
                    existingTicket.timeFlight = ticket.timeFlight;
                    existingTicket.TimeBooking = ticket.TimeBooking;
                    existingTicket.isPaid = ticket.isPaid;
                    context.SaveChanges();
                }
            }
        }

        // Xóa vé khỏi cơ sở dữ liệu
        public void Delete(string ticketId)
        {
            using (FlightModel context = new FlightModel())
            {
                string ticketIdString = ticketId.ToString();
                var ticketToDelete = context.Tickets.SingleOrDefault(t => t.TicketId == ticketIdString);
                if (ticketToDelete != null)
                {
                    context.Tickets.Remove(ticketToDelete);
                    context.SaveChanges();
                }
            }
        }

    }
}
