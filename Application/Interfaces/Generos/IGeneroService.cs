using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Generos
{
    public interface IGeneroService
    {
        List<Genero> getGeneros();
        Task<List<GeneroDTOResponse>> GetAll();
        Task<GeneroDTOResponse> GetById(int id);
    }
}
