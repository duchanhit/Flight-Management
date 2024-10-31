using DAL;
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
        private readonly IRepository<Passenger> _passengerRepository;

        // Constructor Injection
        public TicketBUS(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public TicketBUS()
        {
            _ticketRepository = new TicketDAL();
        }

        // Method to get all tickets
        public IEnumerable<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll();
        }

        // Method to get ticket by ID
        public Ticket GetTicketById(string id)
        {
            return _ticketRepository.GetById(id);
        }

        // Method to add a new ticket
        public void AddTicket(Ticket ticket, Passenger passenger)
        {
            // Save the Passenger first
            _passengerRepository.Add(passenger);

            // Set the PassengerId in the Ticket object
            ticket.TicketIDPassenger = passenger.PassengerId;

            // Now save the Ticket
            _ticketRepository.Add(ticket);
        }

        // Method to update an existing ticket
        public void UpdateTicket(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }

        // Method to delete a ticket
        public void DeleteTicket(string id)
        {
            _ticketRepository.Delete(id);
        }
    }
}
