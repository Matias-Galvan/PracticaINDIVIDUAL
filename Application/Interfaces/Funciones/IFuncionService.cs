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
        Task<FuncionDTOResponse> actualizarFuncion(int funcionId);
        Task<FuncionDTOResponseDetail> eliminarFuncion(int funcionId);
        Task<List<FuncionDTOResponse>> ListarFunciones(FuncionFilters filters);
        Task<FuncionDTOResponse> ObtenerFuncionPorId(int funcionId);
        Task<TicketsDTOResponse> obtenerTicketsFuncionPorId(int id);
        Task<TicketDTOResponseTickets> crearTicketFuncion(int id, TicketDTO request);
    }
}
