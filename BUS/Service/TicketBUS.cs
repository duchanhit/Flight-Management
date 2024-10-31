using DAL;
using DTO.Entities;
using System.Collections.Generic;

namespace BUS.Service
{
    public class TicketBUS
    {
        private readonly TicketDAL _ticketDAL;

        // Constructor
        public TicketBUS()
        {
            _ticketDAL = new TicketDAL();
        }

        // Method to get all tickets
        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ticketDAL.GetAll();
        }

        // Method to get a ticket by ID
        public Ticket GetTicketById(int id)
        {
            return _ticketDAL.GetById(id);
        }

        // Method to add a new ticket
        public void AddTicket(Ticket ticket)
        {
            _ticketDAL.Add(ticket);
        }

        // Method to update an existing ticket
        public void UpdateTicket(Ticket ticket)
        {
            _ticketDAL.Update(ticket);
        }

        // Method to delete a ticket
        public void DeleteTicket(int id)
        {
            _ticketDAL.Delete(id);
        }
    }
}
