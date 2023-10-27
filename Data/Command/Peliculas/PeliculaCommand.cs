using Application.DTO;
using Application.Interfaces.Peliculas;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command.Peliculas
{
    public class PeliculaCommand : IPeliculaCommand
    {
        public Task<PeliculaDTOResponseDetail> actualizarPelicula(int funcionId, PeliculaDTO request)
        {
            throw new NotImplementedException();
        }

        public void crearPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
