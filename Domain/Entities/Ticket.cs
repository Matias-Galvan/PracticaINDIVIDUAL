using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        [Key]
        public Guid TicketId { get; set; }
        public int FuncionId { get; set; }
        [StringLength(50)]
        public string Usuario { get; set; }
        public Funcion Funcion { get; set; }
    }
}
