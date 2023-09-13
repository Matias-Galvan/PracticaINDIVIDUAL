using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pelicula
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeliculaId { get; set; }
        [StringLength(50)]
        public required string Titulo { get; set; }
        [StringLength(255)]
        public required string Sinopsis { get; set; }
        [StringLength(255)]
        public required string Poster { get; set; }
        [StringLength(255)]
        public required string Trailer { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

        public ICollection<Funcion>Funciones { get; set; }
    }
}
