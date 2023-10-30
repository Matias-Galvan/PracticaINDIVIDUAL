using Application.DTO;
using Application.Interfaces.Peliculas;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Query.Peliculas
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly CineDBContext _dbContext;
        public PeliculaQuery(CineDBContext context)
        {
            _dbContext = context;
        }
        public List<Pelicula> GetAllPeliculas()
        {
            return _dbContext.Peliculas.ToList();
        }

        public Task<PeliculaDTOResponseDetail> GetPeliculaById(int peliculaId)
        {
            var pelicula = _dbContext.Peliculas.Where(x => x.PeliculaId == peliculaId).FirstOrDefault();
            var genero = _dbContext.Generos.Where(x => x.GeneroId == pelicula.Genero).FirstOrDefault();
            var funciones = _dbContext.Funciones.Where(x => x.PeliculaId == peliculaId).ToList();
            return Task.FromResult(new PeliculaDTOResponseDetail
            {
                PeliculaId = pelicula.PeliculaId,
                Titulo = pelicula.Titulo,
                Poster = pelicula.Poster,
                Trailer = pelicula.Trailer,
                Sinopsis = pelicula.Sinopsis,
                genero = new GeneroDTOResponse
                {
                    id = genero.GeneroId,
                    Nombre = genero.Nombre
                },
                funciones = funciones.Select(x => new FuncionDTOResponseDetail
                {
                    FuncionId = x.FuncionId,
                    Fecha = x.Fecha,
                    Horario = x.Horario.ToString(),
                }).ToList()
            });

        }

        public Task<List<PeliculaDTOResponse>> GetPeliculas()
        {
            throw new NotImplementedException();
        }
        public Pelicula GetPelicula(int id)
        {
            return _dbContext.Peliculas.Where(x => x.PeliculaId == id).FirstOrDefault();
        }
    }
}
