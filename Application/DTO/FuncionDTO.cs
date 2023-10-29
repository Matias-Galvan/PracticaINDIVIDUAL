using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Application.DTO
{
    public class FuncionDTO
    {
        public int Pelicula { get; set;}
        public int Sala { get; set; }
        public DateTime Fecha { get; set; }
        public string? Horario { get; set; }

    }
}
