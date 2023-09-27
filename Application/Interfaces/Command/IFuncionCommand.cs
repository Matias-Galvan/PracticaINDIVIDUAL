using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Command
{
    public interface IFuncionCommand
    {
        Task<FuncionDTOResponse> crearFuncion(Funcion funcion);
        Task<FuncionDTOResponse> actualizarFuncion(int funcionId);
        Task<FuncionDTOResponseDetail> eliminarFuncion(int funcionId);
        Task<TicketDTOResponseTickets> crearTicketFuncion(int id, TicketDTO request);
    }
}
