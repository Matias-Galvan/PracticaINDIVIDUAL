using Application.DTO;
using Application.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IFuncionService
    {
        Task<FuncionDTOResponse> crearFuncion(Funcion funcion);
        Task<FuncionDTOResponse> actualizarFuncion(int funcionId);
        Task<FuncionDTOResponseDetail> eliminarFuncion(int funcionId);
        Task<List<FuncionDTOResponse>> listarFunciones(FuncionFilters filters);
        List<Funcion>GetAllFunciones();
        List<Funcion> GetFuncionPelicula(int peliculaNombre);
        List<Funcion> GetFuncionDia(DateTime dia);
        List<Funcion> GetFuncionPeliculaYDia(int peliculaNombre, DateTime fecha);
        Task<FuncionDTOResponse> obtenerFuncionPorId(int funcionId);
        Task<TicketsDTOResponse> obtenerTicketsFuncionPorId(int id);
        Task<TicketDTOResponseTickets> crearTicketFuncion(int id, TicketDTO request);
    }
}
