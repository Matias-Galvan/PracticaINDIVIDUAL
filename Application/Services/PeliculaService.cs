using Aplication.ErrorHandler;
using Application.Interfaces.Peliculas;
using Data.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly CineDBContext _context;
        public PeliculaService(CineDBContext context)
        {
            _context = context;
        }

        public void crearPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }

        public List<Pelicula> GetAllPelicula()
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

    }
}
