using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class TicketDTOResponseTickets
    {
        public List<TicketDTOResponseIDTicket> Tickets { get; set; }
        public FuncionDTOResponse Funcion { get; set; }
        public string Usuario { get; set; } 
    }
}
