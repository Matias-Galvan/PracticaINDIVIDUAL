using Application.DTO;
using Application.ErrorHandler;
using Application.Interfaces.Peliculas;
using Domain.Entities;

namespace Application.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaQuery _PeliculaQuery;
        private readonly IPeliculaCommand _PeliculaCommand;

        public PeliculaService(IPeliculaQuery peliculaQuery, IPeliculaCommand peliculaCommand)
        {
            _PeliculaQuery = peliculaQuery;
            _PeliculaCommand = peliculaCommand;
        }

        public Task<PeliculaDTOResponseDetail> ActualizarPelicula(int funcionId, PeliculaDTO request)
        {
            var peliculas = _PeliculaQuery.GetAllPeliculas();
            var pelicula = _PeliculaQuery.GetPelicula(funcionId) ?? throw new ElementNotFoundException("Película no encontrada");
            if (peliculas.Any(x => x.Titulo == request.Titulo && x.PeliculaId != funcionId))
            {
                throw new ElementAlreadyExistException("Ya existe una película con ese título");
            }
            pelicula.Titulo = request.Titulo;
            pelicula.Poster = request.Poster;
            pelicula.Trailer = request.Trailer;
            pelicula.Sinopsis = request.Sinopsis;
            pelicula.Genero = request.genero;
            var response = _PeliculaCommand.UpdatePelicula(pelicula);
            var funciones = _PeliculaQuery.GetPeliculaById(funcionId).Result.funciones;

            return Task.FromResult(new PeliculaDTOResponseDetail
            {
                PeliculaId = pelicula.PeliculaId,
                Titulo = pelicula.Titulo,
                Poster = pelicula.Poster,
                Trailer = pelicula.Trailer,
                Sinopsis = pelicula.Sinopsis,
                genero = new GeneroDTOResponse
                {
                    id = pelicula.Genero,
                    Nombre = pelicula.Generos.Nombre
                },
                funciones = funciones
            });

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

        public Task<PeliculaDTOResponseDetail> GetPeliculaById(int peliculaId)
        {
            var response = _PeliculaQuery.GetPeliculaById(peliculaId);
            return response;
        }

        public Task<List<PeliculaDTOResponse>> GetPeliculas()
        {
            throw new NotImplementedException();
        }

        public Task<PeliculaDTOResponseDetail> UpdatePelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
