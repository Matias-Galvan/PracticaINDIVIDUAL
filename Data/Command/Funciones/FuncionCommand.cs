using Application.DTO;
using Application.Interfaces.Funciones;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command.Funciones
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly CineDBContext _context;
        public FuncionCommand(CineDBContext context)
        {
            _context = context;
        }

        public Task<FuncionDTOResponse> ActualizarFuncion(int FuncionId)
        {
            throw new NotImplementedException();
        }

        public void CrearFuncion(Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            _context.SaveChanges();

        }

        public Task<FuncionDTOResponse> CrearFnc(Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            _context.SaveChanges();
            return Task.FromResult(new FuncionDTOResponse
            {

            });

        }


        public Task<FuncionDTOResponseDetail> EliminarFuncion(int FuncionId)
        {
            _context.Funciones.Remove(_context.Funciones.Find(FuncionId));
            _context.SaveChanges();
            return Task.FromResult(new FuncionDTOResponseDetail
            {

            });
        }
    }
}
