using Application.DTO;
using Application.Interfaces.Generos;
using Domain.Entities;

namespace Application.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroQuery _generoQuery;

        public GeneroService(IGeneroQuery generoQuery)
        {
            _generoQuery = generoQuery;
        }

        public Task<List<GeneroDTOResponse>> GetAll()
        {
            return _generoQuery.GetAll();
            
        }

        public Task<GeneroDTOResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Genero> getGeneros()
        {
            throw new NotImplementedException();
        }
    }
}
