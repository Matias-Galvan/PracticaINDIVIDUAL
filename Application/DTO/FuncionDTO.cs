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
        public DateTime Fecha { get; set; }
        public string Horario { get; set; }
        public int SalaId { get; set; }

        public int PeliculaId { get; set; }

    }
}

