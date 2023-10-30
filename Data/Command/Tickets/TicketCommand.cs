using Application.DTO;
using Application.Interfaces.Tickets;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command.Tickets
{
    public class TicketCommand : ITicketCommand
    {
        private readonly CineDBContext _dbContext;

        public TicketCommand(CineDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<TicketDTOResponseTickets> CrearTicket(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            return _dbContext.SaveChangesAsync().ContinueWith(t =>
            {
                return new TicketDTOResponseTickets
                {

                };
            });
        }
    }
}
