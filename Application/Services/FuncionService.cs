using Aplication.ErrorHandler;
using Aplication.HandlerError;
using Application.Interfaces.Funciones;
using Domain.Entities;

namespace Aplication.UseCase.Services
{
    public class FuncionService 
    {
        private readonly IFuncionCommand _funcionCommand;
        private readonly IFuncionQuery _funcionQuery;
        private readonly IErrorHandler _errorHandler;
        
        public FuncionService(IFuncionCommand funcionCommand, IFuncionQuery funcionQuery, IErrorHandler errorHandler)
        {
            _funcionCommand = funcionCommand;
            _funcionQuery = funcionQuery;
            _errorHandler = errorHandler;
        }
        public void CrearFuncion(Funcion funcion)
        {
            _funcionCommand.CrearFuncion(funcion);
        }

        public List<Funcion> GetAllFunciones()
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionDia(DateTime dia)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionPelicula(int PeliculaNombre)
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionPeliculaYDia(int PeliculaNombre, DateTime fecha)
        {
            throw new NotImplementedException();
        }
    }
}
