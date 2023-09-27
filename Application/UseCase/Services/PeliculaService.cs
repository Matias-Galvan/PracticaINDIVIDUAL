using Aplication.ErrorHandler;
using Aplication.Interfaces;
using Application.DTO;
using Application.Interfaces.Command;
using Application.Interfaces.Queries;
using Domain.Entities;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly CineDBContext _context;
        private readonly IPeliculaCommand _peliculaCommand;
        private readonly IPeliculaQuery _peliculaQuery;

        public CineDBContext DbContext { get; }

        public PeliculaService(CineDBContext context, IPeliculaCommand peliculaCommand, IPeliculaQuery peliculaQuery)
        {
            _context = context;
            _peliculaCommand = peliculaCommand;
            _peliculaQuery = peliculaQuery;
        }

        public PeliculaService(CineDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public void crearPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public List<Pelicula> getAllPelicula()
        {
            return _context.Peliculas.ToList();
        }

        public Pelicula getPelicula(int id)
        {
            var pelicula = _context.Peliculas.FirstOrDefault(p => p.PeliculaId == id);

            if (pelicula != null)
            {
                return pelicula;
            }
            else
            {                
                throw new ElementNotFoundException("Película no encontrada");
            }
        }

        public Task<PeliculaDTOResponseDetail> GetPeliculaById(int peliculaId)
        {
            return _peliculaQuery.GetPeliculaById(peliculaId);
        }

        public Task<List<PeliculaDTOResponse>> GetPeliculas()
        {
            throw new NotImplementedException();
        }

        public Task<PeliculaDTOResponseDetail> actualizarPelicula(int funcionId, PeliculaDTO request)
        {
            return _peliculaCommand.actualizarPelicula(funcionId, request);
        }
    }
}
