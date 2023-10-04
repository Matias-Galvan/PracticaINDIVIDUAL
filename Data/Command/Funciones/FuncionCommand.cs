using Application.Interfaces.Funciones;
using Domain.Entities;
using Infraestructure.Persistence;
namespace Infraestructure.Command.Funciones
{
    public class FuncionCommand: IFuncionCommand
    {
        private readonly CineDBContext _context;
        public FuncionCommand(CineDBContext context)
        {
            _context = context;
        }

        public void CrearFuncion(Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            _context.SaveChanges();

        }
    }
}
