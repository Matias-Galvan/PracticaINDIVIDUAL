using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Tickets
{
    public interface ITicketQuery
    {
        Task<List<Ticket>> GetAll();
    }
}
