using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Funciones
{
    public interface IFuncionCommand
    {
        void CrearFuncion(Funcion funcion);
        Task<FuncionDTOResponse> crearFuncion(Funcion funcion);
        Task<FuncionDTOResponse> actualizarFuncion(int funcionId);
        Task<FuncionDTOResponseDetail> eliminarFuncion(int funcionId);
        Task<TicketDTOResponseTickets> crearTicketFuncion(int id, TicketDTO request);
    }
}
