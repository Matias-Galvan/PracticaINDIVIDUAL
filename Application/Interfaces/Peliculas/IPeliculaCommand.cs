using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Peliculas
{
    public interface IPeliculaCommand
    {
        void CrearPelicula(Pelicula pelicula);
        Task<PeliculaDTOResponseDetail> UpdatePelicula(Pelicula pelicula);
    }
}
