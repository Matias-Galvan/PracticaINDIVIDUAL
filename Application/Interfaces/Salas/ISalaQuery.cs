using Domain.Entities;

namespace Application.Interfaces.Salas
{
    public interface ISalaQuery
    {
        List<Sala> GetAll();
        Sala GetSala(int id);
    }
}
