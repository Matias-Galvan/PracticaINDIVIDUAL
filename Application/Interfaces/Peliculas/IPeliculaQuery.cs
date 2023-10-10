using Domain.Entities;

namespace Application.Interfaces.Peliculas
{
    public interface IPeliculaQuery
    {
        List<Pelicula> GetAllPeliculas();
    }
}
