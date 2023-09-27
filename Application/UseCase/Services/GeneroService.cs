using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure;


namespace Aplication.UseCase.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly CineDBContext _context;
        public GeneroService(CineDBContext context)
        {
            _context = context;
        }
        public List<Genero> getGeneros()
        {
            return _context.Generos.ToList();
        }
    }
}
