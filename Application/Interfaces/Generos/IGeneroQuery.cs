using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Generos
{
    public interface IGeneroQuery
    {
        Task<List<GeneroDTOResponse>> GetAll();
        Task<GeneroDTOResponse> GetById(int id);
        Genero GetGenero(int id);
    }
}
