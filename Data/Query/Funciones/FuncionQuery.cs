using Application.DTO;
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
