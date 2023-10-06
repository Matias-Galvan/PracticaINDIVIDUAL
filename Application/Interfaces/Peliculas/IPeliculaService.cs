using Domain.Entities;

namespace Application.Interfaces.Peliculas
{
    public interface IPeliculaService
    {
        void CrearPelicula(Pelicula pelicula);
        List<Pelicula> GetAllPelicula();
        Pelicula GetPelicula(int id);

    }
}
