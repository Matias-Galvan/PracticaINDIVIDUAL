using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Funcion
    {
 
        public DateTime Fecha { get; set; }
        public DateTime Horario { get; set; }
        public int SalaId { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public int PeliculaId { get; set; }
        public virtual Pelicula Pelicula { get; set; }
        public virtual Sala Sala { get; set; }

        
        public int FuncionId { get; set; }
    }
}
