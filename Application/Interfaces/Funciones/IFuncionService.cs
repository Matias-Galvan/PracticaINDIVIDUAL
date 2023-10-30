using Application.DTO;
using Application.Filters;
using Domain.Entities;

namespace Application.Interfaces.Funciones
{
    public interface IFuncionService
    {
        void CrearFuncion(int PeliculaId, int SalaId, DateTime fecha, TimeSpan hora);
        List<Funcion> GetAllFunciones();
        List<Funcion> GetFuncionPelicula(int PeliculaNombre);
        List<Funcion> GetFuncionDia(DateTime dia);
        List<Funcion> GetFuncionPeliculaYDia(int PeliculaNombre, DateTime fecha);
        Task<FuncionDTOResponse> CrearFuncion(Funcion funcion);
        Task<FuncionDTOResponse> ActualizarFuncion(int FuncionId);
        Task<FuncionDTOResponseDetail> EliminarFuncion(int FuncionId);
        Task<List<FuncionDTOResponse>> ListarFunciones(FuncionFilters filters);
        Task<FuncionDTOResponse> ObtenerFuncionPorId(int FuncionId);
        Task<TicketsDTOResponse> ObtenerTicketsFuncionPorId(int id);
        Task<TicketDTOResponseTickets> CrearTicketFuncion(int id, TicketDTO request);
    }
}
