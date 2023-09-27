using Aplication.ErrorHandler;
using Application.DTO;
using Application.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IFuncionQuery
    {
        Task<List<FuncionDTOResponse>> listarFunciones(FuncionFilters filters);
        Task<FuncionDTOResponse> obtenerFuncionPorId(int funcionId);
        Task<List<Funcion>> GetFuncionPeliculaYDia(int peliculaNombre, DateTime fecha);

    }
}
