using Domain.Entities;

namespace Application.Interfaces.Salas
{
    public interface ISalaService
    {
        List<Sala> GetAll();
        Sala getSala(int id);
    }
}
