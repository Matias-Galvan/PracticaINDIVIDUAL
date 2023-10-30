using Domain.Entities;

namespace Application.Interfaces.Tickets
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAll();
    }
}
