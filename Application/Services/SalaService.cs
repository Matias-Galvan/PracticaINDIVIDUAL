using Application.ErrorHandler;
using Application.Interfaces.Salas;
using Domain.Entities;

namespace Application.Services
{
    public class SalaService : ISalaService
    {
        private readonly ISalaQuery _SalaQuery;
        public SalaService(ISalaQuery SalaQuery)
        {
            _SalaQuery = SalaQuery;
        }
        public List<Sala> GetAll()
        {
            return _SalaQuery.GetAll();
        }
        public Sala GetSala(int id)
        {
            return _SalaQuery.GetSala(id) ?? throw new ElementDoesNotExistException("No se encontró la sala");
        }
    }
}
