using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TicketDAL
    {
        // Lấy tất cả các vé từ cơ sở dữ liệu
        public List<Ticket> GetAllTickets()
        {
            return new List<Ticket>();
        }

        // Lấy thông tin vé theo ID
        public Ticket GetTicketById(int ticketId)
        {

        }

        // Thêm vé mới vào cơ sở dữ liệu
        public void AddTicket(Ticket ticket)
        {
            // Thực hiện câu lệnh SQL để thêm vé
        }

        // Cập nhật thông tin vé
        public void UpdateTicket(Ticket ticket)
        {
            // Thực hiện câu lệnh SQL để cập nhật vé
        }

        // Xóa vé khỏi cơ sở dữ liệu
        public void DeleteTicket(int ticketId)
        {
            // Thực hiện câu lệnh SQL để xóa vé
        }
    }

}
