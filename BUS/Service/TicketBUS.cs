using DAL.IAccess;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class TicketBUS
    {
        private readonly IRepository<Ticket> _ticketRepository;

        // Constructor Injection
        public TicketBUS(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        // Method to get all tickets
        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll();
        }

        // Method to get ticket by ID
        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetById(id);
        }

        // Method to add a new ticket
        public void AddTicket(Ticket ticket)
        {
            _ticketRepository.Add(ticket);
        }

        // Method to update an existing ticket
        public void UpdateTicket(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }

        // Method to delete a ticket
        public void DeleteTicket(int id)
        {
            _ticketRepository.Delete(id);
        }
    }
}
