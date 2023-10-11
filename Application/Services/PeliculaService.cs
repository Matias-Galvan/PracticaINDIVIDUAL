using Application.Interfaces.Peliculas;
using Domain.Entities;

namespace Application.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaQuery _PeliculaQuery;

        public PeliculaService(IPeliculaQuery peliculaQuery)
        {
            _PeliculaQuery = peliculaQuery;
        }

        public void CrearPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _PeliculaQuery.GetAllPeliculas();
        }

        public Pelicula GetPelicula(int id)
        {
            throw new NotImplementedException();
        }
    }
}
