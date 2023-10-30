using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Peliculas
{
    public interface IPeliculaQuery
    {
        List<Pelicula> GetAllPeliculas();
        Task<List<PeliculaDTOResponse>> GetPeliculas();
        Task<PeliculaDTOResponseDetail> GetPeliculaById(int peliculaId);
        Pelicula GetPelicula(int id);
    }
}
