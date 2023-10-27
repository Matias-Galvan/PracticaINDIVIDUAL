using Application.DTO;
using Application.ErrorHandler;
using Application.Filters;
using Application.Interfaces.Funciones;
using Application.Interfaces.Generos;
using Application.Interfaces.Peliculas;
using Application.Interfaces.Salas;
using Domain.Entities;

namespace Application.Services
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionCommand _FuncionCommand;
        private readonly IFuncionQuery _FuncionQuery;
        private readonly IErrorHandler _ErrorHandler;
        private readonly IPeliculaQuery _PeliculaQuery;
        private readonly ISalaQuery _SalaQuery;
        private readonly IGeneroQuery _GeneroQuery;

        public FuncionService(IFuncionCommand funcionCommand, IFuncionQuery funcionQuery, IErrorHandler errorHandler, IPeliculaQuery peliculaQuery, ISalaQuery salaQuery, IGeneroQuery generoQuery)
        {
            _FuncionCommand = funcionCommand;
            _FuncionQuery = funcionQuery;
            _ErrorHandler = errorHandler;
            _PeliculaQuery = peliculaQuery;
            _SalaQuery = salaQuery;
            _GeneroQuery = generoQuery;
        }

        public Task<FuncionDTOResponse> actualizarFuncion(int funcionId)
        {
            throw new NotImplementedException();
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

        public async Task<FuncionDTOResponse> crearFuncion(Funcion request)
        {
            var funciones = _FuncionQuery.GetAllFunciones() ?? throw new ElementNotFoundException("No hay funciones disponibles en cartelera");
            var funcion = new Funcion();
            funcion.Fecha = request.Fecha;
            var peliculaId = request.PeliculaId;
            var pelicula =  _PeliculaQuery.GetPeliculaById(peliculaId) ?? throw new ElementNotFoundException("Película no encontrada");
            funcion.SalaId = request.SalaId;
            var sala = _SalaQuery.GetSala(funcion.SalaId) ?? throw new ElementNotFoundException("Sala no encontrada");
            funcion.Tickets = new List<Ticket>(sala.Capacidad);
            funcion.Horario = request.Horario;
            var horarioProximo = request.Horario.Add(new TimeSpan(2, 30, 0));
            var horarioAnterior = request.Horario.Add(new TimeSpan(-2, 30, 0));
            var genero = _GeneroQuery.GetById(pelicula.Result.genero.GeneroId) ?? throw new ElementNotFoundException("Género no encontrado");
            if (funciones.Any(f => f.Fecha.ToString("yyyy-MM-dd") == funcion.Fecha.ToString("yyyy-MM-dd") && f.Horario == funcion.Horario && f.SalaId == funcion.SalaId))
            {
                throw new ElementAlreadyExistException("Ya existe una función para ese día y horario en esa sala");
            }
            if (funciones.Any(f => f.Horario <= horarioProximo && f.Horario >= horarioAnterior && f.SalaId == funcion.SalaId && f.Fecha.ToString("yyyy-MM-dd") == funcion.Fecha.ToString("yyyy-MM-dd")))
            {
                throw new ElementAlreadyExistException("No se puede crear una función para ese día y horario en esa sala, hay superposición horaria. Intente nuevamente");
            }
            var response = await _FuncionCommand.CrearFnc(funcion);
            response.FuncionId = funcion.FuncionId;
            response.Pelicula = new PeliculaDTOResponse
            {
                PeliculaId = pelicula.Result.PeliculaId,
                Titulo = pelicula.Result.Titulo,
                Poster = pelicula.Result.Poster,
                Genero = new GeneroDTOResponse
                {
                    GeneroId = genero.Result.GeneroId,
                    Nombre = genero.Result.Nombre
                },
            };
            response.Sala = new SalaDTOResponse
            {
                SalaId = sala.SalaId,
                Nombre = sala.Nombre,
                Capacidad = sala.Capacidad
            };
            response.Fecha = funcion.Fecha;
            response.Horario = funcion.Horario.ToString();
            return response;
            
        }

        public Task<TicketDTOResponseTickets> crearTicketFuncion(int id, TicketDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionDTOResponseDetail> eliminarFuncion(int funcionId)
        {
            throw new NotImplementedException();
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

        public Task<List<FuncionDTOResponse>> listarFunciones(FuncionFilters filters)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionDTOResponse> obtenerFuncionPorId(int funcionId)
        {
            throw new NotImplementedException();
        }

        public Task<TicketsDTOResponse> obtenerTicketsFuncionPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
