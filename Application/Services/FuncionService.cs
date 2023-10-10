using Application.ErrorHandler;
using Application.Interfaces.Funciones;
using Domain.Entities;

namespace Application.Services
{
    public class FuncionService
    {
        private readonly IFuncionCommand _FuncionCommand;
        private readonly IFuncionQuery _FuncionQuery;
        private readonly IErrorHandler _ErrorHandler;

        public FuncionService(IFuncionCommand funcionCommand, IFuncionQuery funcionQuery, IErrorHandler errorHandler)
        {
            _FuncionCommand = funcionCommand;
            _FuncionQuery = funcionQuery;
            _ErrorHandler = errorHandler;
        }
        public void CrearFuncion(int peliculaId, int salaId, DateTime fecha, TimeSpan hora)
        {
            Funcion funcion = new()
            {
                PeliculaId = peliculaId,
                SalaId = salaId,
                Fecha = fecha,
                Horario = hora
            };
            _FuncionCommand.CrearFuncion(funcion);
        }

        public List<Funcion> GetAllFunciones()
        {
            throw new NotImplementedException();
        }

        public List<Funcion> GetFuncionDia(DateTime dia)
        {
            return _FuncionQuery.GetFuncionDia(dia) ?? throw new ElementNotFoundException("No hay funciones para el día seleccionado");
        }

        public List<Funcion> GetFuncionPelicula(int PeliculaNombre)
        {
            return _FuncionQuery.GetFuncionPelicula(PeliculaNombre) ?? throw new ElementNotFoundException("No hay funciones para la película seleccionada"); ;
        }

        public List<Funcion> GetFuncionPeliculaYDia(int PeliculaNombre, DateTime fecha)
        {
            return _FuncionQuery.GetFuncionPeliculaYDia(PeliculaNombre, fecha) ?? throw new ElementNotFoundException("No hay funciones para la película y día seleccionados"); ;
        }
    }
}
