using Application.Interfaces.Salas;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Query.Salas
{
    public class SalaQuery : ISalaQuery
    {
        private readonly CineDBContext _dbContext;
        public SalaQuery(CineDBContext context)
        {
            _dbContext = context;
        }

        public List<Sala> GetAll()
        {
            return _dbContext.Salas.ToList();
        }

        public Sala GetSala(int id)
        {
            return _dbContext.Salas.Where(s => s.SalaId == id).FirstOrDefault();
        }
    }
}
