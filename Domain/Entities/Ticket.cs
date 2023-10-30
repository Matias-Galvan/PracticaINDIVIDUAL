using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    [Table("Tickets")]
    public class Ticket
    {
        public Guid TicketId { get; set; }

        public int FuncionId { get; set; }
        public Funcion Funciones { get; set; }

        public string Usuario { get; set; }
    }
}
