using Application.ErrorHandler;
using Application.Interfaces.Peliculas;
using Domain.Entities;
using System.Dynamic;

namespace Application.Services
{
    public class PeliculaService
    {
        private readonly IPeliculaCommand _PeliculaCommand;
        private readonly IPeliculaQuery _PeliculaQuery;
        private readonly IErrorHandler _ErrorHandler;

        public PeliculaService(IPeliculaCommand peliculaCommand, IPeliculaQuery peliculaQuery, IErrorHandler errorHandler)
        {
            _PeliculaCommand = peliculaCommand;
            _PeliculaQuery = peliculaQuery;
            _ErrorHandler = errorHandler;
        }

        public void crearPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public List<Pelicula> GetAllPeliculas()
        {
            return _PeliculaQuery.GetAllPeliculas();
        }
    }
}
