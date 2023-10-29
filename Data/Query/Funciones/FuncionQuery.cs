using Application.DTO;
using Application.ErrorHandler;
using Application.Filters;
using Application.Interfaces.Funciones;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Query.Funciones
{
    public class FuncionQuery : IFuncionQuery
    {
        private readonly CineDBContext _dbContext;
        public FuncionQuery(CineDBContext context)
        {
            _dbContext = context;
        }
        public List<Funcion> GetAllFunciones()
        {
            return _dbContext.Funciones.ToList();
        }

        public List<Funcion> GetFuncionDia(DateTime dia)
        {
            return _dbContext.Funciones.Where(x => x.Fecha == dia).ToList();
        }

        public List<Funcion> GetFuncionPelicula(int PeliculaNombre)
        {
            return _dbContext.Funciones.Where(x => x.PeliculaId == PeliculaNombre).ToList();
        }

        public List<Funcion> GetFuncionPeliculaYDia(int PeliculaNombre, DateTime fecha)
        {
            return _dbContext.Funciones.Where(x => x.PeliculaId == PeliculaNombre && x.Fecha == fecha).ToList();
        }

        public Task<List<FuncionDTOResponse>> ListarFunciones(FuncionFilters filters)
        {
            return Task.FromResult(_dbContext.Funciones.Select(x => new FuncionDTOResponse
            {
                FuncionId = x.FuncionId,
                Pelicula = new PeliculaDTOResponse
                {
                    PeliculaId = x.PeliculaId,
                    Titulo = _dbContext.Peliculas.Where(y => y.PeliculaId == x.PeliculaId).FirstOrDefault().Titulo,
                    Poster = _dbContext.Peliculas.Where(y => y.PeliculaId == x.PeliculaId).FirstOrDefault().Poster,
                    Genero = new GeneroDTOResponse
                    {
                        id = _dbContext.Peliculas.Where(y => y.PeliculaId == x.PeliculaId).FirstOrDefault().Genero,
                        Nombre = _dbContext.Generos.Where(y => y.GeneroId == _dbContext.Peliculas.Where(y => y.PeliculaId == x.PeliculaId).FirstOrDefault().Genero).FirstOrDefault().Nombre
                    }
                },
                Sala = new SalaDTOResponse
                {
                    id = x.SalaId,
                    Nombre = _dbContext.Salas.Where(y => y.SalaId == x.SalaId).FirstOrDefault().Nombre,
                    Capacidad = _dbContext.Salas.Where(y => y.SalaId == x.SalaId).FirstOrDefault().Capacidad
                },
                Fecha = new DateTime(x.Fecha.Year, x.Fecha.Month, x.Fecha.Day).Date,
                Horario = x.Horario.ToString()
            }).ToList());
        }

        public Task<FuncionDTOResponse> ObtenerFuncionPorId(int funcionId)
        {
            var funciones = _dbContext.Funciones.Where(x => x.FuncionId == funcionId).FirstOrDefault() ?? throw new ElementNotFoundException("No se encontro la funcion");
            var pelicula = _dbContext.Peliculas.Where(x => x.PeliculaId == funciones.PeliculaId).FirstOrDefault();
            var sala = _dbContext.Salas.Where(x => x.SalaId == funciones.SalaId).FirstOrDefault();
            return Task.FromResult(new FuncionDTOResponse
            {
               FuncionId = funciones.FuncionId,
               Pelicula = new PeliculaDTOResponse
               {
                   PeliculaId = pelicula.PeliculaId,
                   Titulo = pelicula.Titulo,
                   Poster = pelicula.Poster,
                   Genero = new GeneroDTOResponse
                   {
                       id = pelicula.Genero,
                       Nombre = _dbContext.Generos.Where(x => x.GeneroId == pelicula.Genero).FirstOrDefault().Nombre
                   }
               },
               Sala = new SalaDTOResponse
               {
                     id = sala.SalaId,
                     Nombre = sala.Nombre,
                     Capacidad = sala.Capacidad
                },
               Fecha = new DateTime(funciones.Fecha.Year, funciones.Fecha.Month, funciones.Fecha.Day).Date,
               Horario = funciones.Horario.ToString()
            });
        }

        public Task<TicketsDTOResponse> obtenerTicketsFuncionPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
