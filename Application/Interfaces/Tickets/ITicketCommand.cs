using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Tickets
{
    public interface ITicketCommand
    {
        Task<TicketDTOResponseTickets> CrearTicket(Ticket ticket);
    }
}
