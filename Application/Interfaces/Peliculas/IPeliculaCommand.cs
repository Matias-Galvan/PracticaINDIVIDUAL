using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Peliculas
{
    public interface IPeliculaCommand
    {
        void crearPelicula(Pelicula pelicula);
        Task<PeliculaDTOResponseDetail> actualizarPelicula(int funcionId, PeliculaDTO request);
    }
}
