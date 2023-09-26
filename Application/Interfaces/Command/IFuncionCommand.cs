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
        Task crearFuncion(Funcion funcion);
        Task actualizarFuncion(int funcionId);
        Task eliminarFuncion(int funcionId);
    }
}
