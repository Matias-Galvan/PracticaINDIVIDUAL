using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PeliculaDTO
    {
        public string Titulo { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public string Sinopsis { get; set; }
        public int generoId { get; set; }
    }
}
