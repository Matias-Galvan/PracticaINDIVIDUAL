using Domain.Entities;

namespace Application.Interfaces.Tickets
{
    public interface ITicketQuery
    {
        List<Ticket> GetAll();
        List<Ticket> GetByFuncion(int funcionId);
        Pelicula GetPelicula(int id);
    }
}
