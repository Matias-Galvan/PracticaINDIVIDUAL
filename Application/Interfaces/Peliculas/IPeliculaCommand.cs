using Domain.Entities;

namespace Application.Interfaces.Peliculas
{
    public interface IPeliculaCommand
    {
        void crearPelicula(Pelicula pelicula);
    }
}
