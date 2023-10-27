using Application.DTO;
using Application.Filters;
using Domain.Entities;

namespace Application.Interfaces.Funciones
{
    public interface IFuncionQuery
    {
        List<Funcion> GetAllFunciones();
        List<Funcion> GetFuncionPelicula(int PeliculaNombre);
        List<Funcion> GetFuncionDia(DateTime dia);
        List<Funcion> GetFuncionPeliculaYDia(int PeliculaNombre, DateTime fecha);
        Task<List<FuncionDTOResponse>> listarFunciones(FuncionFilters filters);
        Task<FuncionDTOResponse> obtenerFuncionPorId(int funcionId);
        //Task<List<Funcion>> GetFuncionPeliculaYDia(int peliculaNombre, DateTime fecha);
        Task<TicketsDTOResponse> obtenerTicketsFuncionPorId(int id);
    }
}
