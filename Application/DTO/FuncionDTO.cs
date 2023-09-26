using Aplication.UseCase.Controller;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class FuncionDTO
    {
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public int SalaId { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public int PeliculaId { get; set; }
        public virtual PeliculaDTO Pelicula { get; set; }
        public virtual SalaDTO Sala { get; set; }


        public int FuncionId { get; set; }
    }

    public class SalaDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaId { get; set; }
        [StringLength(50)]
        public required string Nombre { get; set; }
        public int Capacidad { get; set; }
        
    }

    public class PeliculaDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeliculaId { get; set; }
        [StringLength(50)]
        public required string Nombre { get; set; }
        public int Duracion { get; set; }
        
    }
}
