using Application.DTO;
using Application.Interfaces.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Commands.Funcion
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly CineDBContext _context;

        public async Task actualizarFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }

        public async Task crearFuncion(Domain.Entities.Funcion funcion)
        {
            var totalFunciones = _context.Funciones.ToList().Count;
            int nextId;
            if (totalFunciones != 0)
            {
                nextId = totalFunciones + 1;
            }
            else
            {
                nextId = 1;
            }
            funcion.FuncionId = nextId;

            _context.Funciones.Add(funcion);
            await _context.SaveChangesAsync();
        }

        public Task eliminarFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }

    }
}
