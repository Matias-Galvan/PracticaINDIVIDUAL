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
        Task<FuncionDTOResponse> eliminarFuncion(int funcionId);
        Task<TicketDTO> crearTicketFuncion(int id, TicketDTO request);
    }
}
