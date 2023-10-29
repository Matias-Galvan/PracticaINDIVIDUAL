using Application.DTO;
using Application.ErrorHandler;
using Application.Filters;
using Application.Interfaces.Funciones;
using Application.Interfaces.Generos;
using Application.Interfaces.Peliculas;
using Application.Interfaces.Salas;
using Domain.Entities;
using LinqKit;

namespace Application.Services
{
    public class FuncionService : IFuncionService
    {
        private readonly IFuncionCommand _FuncionCommand;
        private readonly IFuncionQuery _FuncionQuery;
        private readonly IPeliculaQuery _PeliculaQuery;
        private readonly ISalaQuery _SalaQuery;
        private readonly IGeneroQuery _GeneroQuery;

        public FuncionService(IFuncionCommand funcionCommand, IFuncionQuery funcionQuery, IPeliculaQuery peliculaQuery, ISalaQuery salaQuery, IGeneroQuery generoQuery)
        {
            _FuncionCommand = funcionCommand;
            _FuncionQuery = funcionQuery;
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

        public async Task<FuncionDTOResponse> CrearFuncion(Funcion request)
        {
            var funciones = _FuncionQuery.GetAllFunciones() ?? throw new ElementNotFoundException("No hay funciones disponibles en cartelera");
            var funcion = new Funcion();
            if(DateTime.TryParse(request.Fecha.ToString(), out DateTime fecha) == false)
            {
                throw new InvalidDateFormatException("Formato de fecha inválido");
            }else if(TimeSpan.TryParse(request.Horario.ToString(), out TimeSpan hora) == false)
            {
                throw new InvalidTimeFormatException("Formato de hora inválido");
            }
            funcion.Fecha = request.Fecha;
            var peliculaId = request.PeliculaId;
            funcion.PeliculaId = peliculaId;
            var pelicula =  _PeliculaQuery.GetPeliculaById(peliculaId) ?? throw new ElementNotFoundException("Película no encontrada");
            funcion.SalaId = request.SalaId;
            var sala = _SalaQuery.GetSala(funcion.SalaId) ?? throw new ElementNotFoundException("Sala no encontrada");
            funcion.Tickets = new List<Ticket>(sala.Capacidad);
            funcion.Horario = request.Horario;
            var horarioProximo = request.Horario.Add(new TimeSpan(2, 30, 0));
            var horarioAnterior = request.Horario.Add(new TimeSpan(-2, 30, 0));
            var genero = _GeneroQuery.GetGenero(pelicula.Result.genero.id) ?? throw new ElementNotFoundException("Género no encontrado");
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
                    id = genero.GeneroId,
                    Nombre = genero.Nombre
                },
            };
            response.Sala = new SalaDTOResponse
            {
                id = sala.SalaId,
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

        //public Task<List<FuncionDTOResponse>> ListarFunciones(FuncionFilters filters)
        //{
        //    var predicate = PredicateBuilder.New<Funcion>(true);
        //    if (filters.Genero != null)
        //    {
        //        var generos = _GeneroQuery.GetGeneros();
        //        if (!generos.Any(p => p.GeneroId == filters.Genero))
        //        {
        //            throw new ElementNotFoundException("No hay funciones para el género ingresado");
        //        }
        //        var genero = _GeneroQuery.GetGenero((int)filters.Genero);
        //        predicate = predicate.And(x => x.Peliculas.Genero == filters.Genero);
        //    }else if (!string.IsNullOrEmpty(filters.Titulo))
        //    {
        //        var peliculas = _PeliculaQuery.GetAllPeliculas();
        //        if (!peliculas.Any(p => p.Titulo.Contains(filters.Titulo)))
        //        {
        //            throw new ElementNotFoundException("No hay funciones para el título ingresado");
        //        }
        //        predicate = predicate.And(x => x.Peliculas.Titulo == filters.Titulo);
        //    }else if (!string.IsNullOrEmpty(filters.Fecha))
        //    {
        //        var funciones = _FuncionQuery.GetAllFunciones();
        //        if (!funciones.Any(f => f.Fecha.ToString("yyyy-MM-dd") == filters.Fecha))
        //        {
        //            throw new ElementNotFoundException("No hay funciones para la fecha ingresada");
        //        }
        //        predicate = predicate.And(x => x.Fecha.ToString("yyyy-MM-dd") == filters.Fecha);
        //    }
        //    var funcionesPredicate = _FuncionQuery.GetAllFunciones().AsQueryable().Where(predicate);
        //    return Task.FromResult(funcionesPredicate.Select(x => new FuncionDTOResponse
        //    {
        //        FuncionId = x.FuncionId,
        //        Pelicula = new PeliculaDTOResponse
        //        {
        //            PeliculaId = x.PeliculaId,
        //            Titulo = _PeliculaQuery.GetPeliculaById(x.PeliculaId).Result.Titulo,
        //            Poster = _PeliculaQuery.GetPeliculaById(x.PeliculaId).Result.Poster,
        //            Genero = new GeneroDTOResponse
        //            {
        //                id = _GeneroQuery.GetById(x.Peliculas.Genero).Result.id,
        //                Nombre = _GeneroQuery.GetById(x.Peliculas.Genero).Result.Nombre
        //            }
        //        },
        //        Sala = new SalaDTOResponse
        //        {
        //            id = x.SalaId,
        //            Nombre = _SalaQuery.GetSala(x.SalaId).Nombre,
        //            Capacidad = _SalaQuery.GetSala(x.SalaId).Capacidad
        //        },
        //        Fecha = new DateTime(x.Fecha.Year, x.Fecha.Month, x.Fecha.Day).Date,
        //        Horario = x.Horario.ToString(),
        //    }).ToList());
        //}
        public Task<List<FuncionDTOResponse>> ListarFunciones(FuncionFilters filters)
        {
            var funciones = _FuncionQuery.GetAllFunciones();
            if (filters.Genero != null)
            {
                var generos = _GeneroQuery.GetGeneros();
                if (!generos.Any(p => p.GeneroId == filters.Genero))
                {
                    throw new ElementNotFoundException("No hay funciones para el género ingresado");
                }
                var genero = _GeneroQuery.GetGenero((int)filters.Genero);
                var peliculas = _PeliculaQuery.GetAllPeliculas();
                var peliculasFiltradas = peliculas.Where(p => p.Genero == filters.Genero).ToList();
                if (!peliculasFiltradas.Any(p => p.Genero == filters.Genero))
                {
                    throw new ElementNotFoundException("No hay funciones para el género ingresado");
                }
                var peliculasIds = peliculasFiltradas.Select(p => p.PeliculaId).ToList();
                funciones = funciones.Where(x => peliculasIds.Contains(x.PeliculaId)).ToList();
            }
            if (!string.IsNullOrEmpty(filters.Titulo))
            {
                var peliculas = _PeliculaQuery.GetAllPeliculas();
                if (!peliculas.Any(p => p.Titulo.Contains(filters.Titulo)))
                {
                    throw new ElementNotFoundException("No hay funciones para el título ingresado");
                }
                funciones = funciones.Where(x => x.Peliculas.Titulo == filters.Titulo).ToList();
            }
            if (!string.IsNullOrEmpty(filters.Fecha))
            {
                var funcionesFiltradas = _FuncionQuery.GetAllFunciones();
                if (!funcionesFiltradas.Any(f => f.Fecha.ToString("yyyy-MM-dd") == filters.Fecha))
                {
                    throw new ElementNotFoundException("No hay funciones para la fecha ingresada");
                }
                funciones = funciones.Where(x => x.Fecha.ToString("yyyy-MM-dd") == filters.Fecha).ToList();
            }
            return Task.FromResult(funciones.Select(x => new FuncionDTOResponse
            {
                FuncionId = x.FuncionId,
                Pelicula = new PeliculaDTOResponse
                {
                    PeliculaId = x.PeliculaId,
                    Titulo = _PeliculaQuery.GetPeliculaById(x.PeliculaId).Result.Titulo,
                    Poster = _PeliculaQuery.GetPeliculaById(x.PeliculaId).Result.Poster,
                    Genero = new GeneroDTOResponse
                    {
                        id = _GeneroQuery.GetById(x.Peliculas.Genero).Result.id,
                        Nombre = _GeneroQuery.GetById(x.Peliculas.Genero).Result.Nombre
                    }
                },
                Sala = new SalaDTOResponse
                {
                    id = x.SalaId,
                    Nombre = _SalaQuery.GetSala(x.SalaId).Nombre,
                    Capacidad = _SalaQuery.GetSala(x.SalaId).Capacidad
                },
                Fecha = new DateTime(x.Fecha.Year, x.Fecha.Month, x.Fecha.Day).Date,
                Horario = x.Horario.ToString(),
            }).ToList());
        }
        public Task<FuncionDTOResponse> ObtenerFuncionPorId(int funcionId)
        {
            var funcion = _FuncionQuery.ObtenerFuncionPorId(funcionId) ?? throw new ElementNotFoundException("Función no encontrada");
            return funcion;
        }

        public Task<TicketsDTOResponse> obtenerTicketsFuncionPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
