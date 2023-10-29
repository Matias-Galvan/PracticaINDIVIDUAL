using Application.DTO;
using Application.Filters;
using Domain.Entities;

namespace Application.Interfaces.Funciones
{
    public interface IFuncionService
    {
        void CrearFuncion(int peliculaId, int salaId, DateTime fecha, TimeSpan hora);
        List<Funcion> GetAllFunciones();
        List<Funcion> GetFuncionPelicula(int PeliculaNombre);
        List<Funcion> GetFuncionDia(DateTime dia);
        List<Funcion> GetFuncionPeliculaYDia(int PeliculaNombre, DateTime fecha);
        Task<FuncionDTOResponse> CrearFuncion(Funcion funcion);
        Task<FuncionDTOResponse> ActualizarFuncion(int funcionId);
        Task<FuncionDTOResponseDetail> EliminarFuncion(int funcionId);
        Task<List<FuncionDTOResponse>> ListarFunciones(FuncionFilters filters);
        Task<FuncionDTOResponse> ObtenerFuncionPorId(int funcionId);
        Task<TicketsDTOResponse> ObtenerTicketsFuncionPorId(int id);
        Task<TicketDTOResponseTickets> CrearTicketFuncion(int id, TicketDTO request);
        Task<TicketDTOResponseTickets> CrearTicketFuncion(Ticket ticket);
    }
}
