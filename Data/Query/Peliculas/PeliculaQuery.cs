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
            throw new NotImplementedException();
        }

        public Task<List<PeliculaDTOResponse>> GetPeliculas()
        {
            throw new NotImplementedException();
        }
    }
}
