using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Peliculas
{
    public interface IPeliculaService
    {
        void CrearPelicula(Pelicula pelicula);
        List<Pelicula> GetAllPeliculas();
        Pelicula GetPelicula(int id);
        Task<List<PeliculaDTOResponse>> GetPeliculas();
        Task<PeliculaDTOResponseDetail> GetPeliculaById(int peliculaId);
        Task<PeliculaDTOResponseDetail> actualizarPelicula(int funcionId, PeliculaDTO request);

    }
}
