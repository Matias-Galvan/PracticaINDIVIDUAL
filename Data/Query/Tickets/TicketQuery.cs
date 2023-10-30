using Application.Interfaces.Tickets;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Query.Tickets
{
    public class TicketQuery : ITicketQuery
    {
        private readonly CineDBContext _dbContext;

        public TicketQuery(CineDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Ticket> GetAll()
        {
            return _dbContext.Tickets.ToList();
        }

        public List<Ticket> GetByFuncion(int funcionId)
        {
            return _dbContext.Tickets.Where(t => t.FuncionId == funcionId).ToList();
        }

        public Pelicula GetPelicula(int id)
        {
            throw new NotImplementedException();
        }
    }
}
