using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sala
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaId { get; set; }
        [StringLength(50)]
        public required string Nombre { get; set; }
        public int Capacidad { get; set; }
        public ICollection<Funcion> Funciones { get; set; }
    }
}
