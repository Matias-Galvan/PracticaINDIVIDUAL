using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Generos
{
    public interface IGeneroService
    {
        List<Genero> GetGeneros();
        Task<List<GeneroDTOResponse>> GetAll();
        Task<GeneroDTOResponse> GetById(int id);
        Genero GetGenero(int id);
    }
}
