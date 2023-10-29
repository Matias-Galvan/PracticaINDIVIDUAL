using Application.Interfaces.Tickets;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Query.Tickets
{
    public class TicketQuery : ITicketQuery
    {
        private readonly CineDBContext _dbContext;

        public TicketQuery(CineDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Ticket>> GetAll()
        {
            return _dbContext.Tickets.ToListAsync();
        }
    }
}
