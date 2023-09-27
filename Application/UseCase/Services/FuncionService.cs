using Aplication.ErrorHandler;
using Aplication.Interfaces;
using Application.DTO;
using Application.Filters;
using Application.Interfaces.Command;
using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure;

namespace Aplication.UseCase.Services
{
    public class FuncionService : IFuncionService
    {
        private readonly CineDBContext _context;
        private readonly IFuncionCommand _funcionCommand;
        private readonly IFuncionQuery _funcionQuery;

        public FuncionService(CineDBContext context, IFuncionCommand funcionCommand, IFuncionQuery funcionQuery)
        {
            _context = context;
            _funcionCommand = funcionCommand;
            _funcionQuery = funcionQuery;
        }

        public Task<FuncionDTOResponse> crearFuncion(Funcion funcion)
        {
            return _funcionCommand.crearFuncion(funcion);
        }

        public List<Funcion> GetAllFunciones()
        {
            if (_context.Funciones.ToList().Count == 0)
            {
                throw new ListEmptyException("La lista de funciones se encuentra vacía");
            }
            return _context.Funciones.ToList();
        }

        public List<Funcion> GetFuncionPelicula(int peliculaNombre)
        {
            var listaFuncionesPelicula = new List<Funcion>();
            var listaFunciones = GetAllFunciones();
            listaFuncionesPelicula = listaFunciones.Where(funcion => funcion.Pelicula.PeliculaId==(peliculaNombre)).ToList();
            if (!listaFuncionesPelicula.Any())
            {
                throw new ElementNotFoundException("No hay funciones para la película seleccionada");
            }
            return listaFuncionesPelicula;
        }
        public List<Funcion> GetFuncionDia(DateTime dia)
        {
            var listaFuncionesPelicula = new List<Funcion>();
            var listaFunciones = GetAllFunciones();
            listaFuncionesPelicula = listaFunciones.Where(funcion => funcion.Fecha.Date == dia.Date).ToList();
            if (!listaFuncionesPelicula.Any())
            {
                throw new ElementNotFoundException("No hay funciones para la fecha seleccionada");
            }
            return listaFuncionesPelicula;
        }
        public List<Funcion> GetFuncionPeliculaYDia(int peliculaNombre, DateTime fecha)
        {
            var listaFuncionesPelicula = new List<Funcion>();
            var listaFunciones = GetAllFunciones();
            listaFuncionesPelicula = listaFunciones.Where(funcion => funcion.Pelicula.PeliculaId == (peliculaNombre) && funcion.Fecha.Date == fecha.Date).ToList();
            if (!listaFuncionesPelicula.Any())
            {
                throw new ElementNotFoundException("No hay funciones para la película y fecha seleccionada");
            }
            return listaFuncionesPelicula;
        }

        public Task<FuncionDTOResponse> actualizarFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionDTOResponse> eliminarFuncion(int funcionId)
        {
            return _funcionCommand.eliminarFuncion(funcionId);
        }

        public Task<List<FuncionDTOResponse>> listarFunciones(FuncionFilters filters)
        {
            return _funcionQuery.listarFunciones(filters);
        }

        public Task<FuncionDTOResponse> obtenerFuncionPorId(int funcionId)
        {
            FuncionDTOResponse funcion = _funcionQuery.obtenerFuncionPorId(funcionId).Result;
            return Task.FromResult(funcion);
        }

        public Task<TicketsDTOResponse> obtenerTicketsFuncionPorId(int id)
        {
            return _funcionQuery.obtenerTicketsFuncionPorId(id);
        }

        public Task<TicketDTOResponseTickets> crearTicketFuncion(int id, TicketDTO request)
        {
            return _funcionCommand.crearTicketFuncion(id, request);
        }
    }
}
