using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Generos
{
    public interface IGeneroQuery
    {
        Task<List<GeneroDTOResponse>> GetAll();
        Task<GeneroDTOResponse> GetById(int id);
        Genero GetGenero(int id);
        List<Genero> GetGeneros();
    }
}
