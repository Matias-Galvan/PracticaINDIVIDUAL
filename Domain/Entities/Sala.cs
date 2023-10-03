using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Salas")]
    public class Sala
    {
        public int SalaId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }

        public ICollection<Funcion> Funciones { get; set; }
    }
}
