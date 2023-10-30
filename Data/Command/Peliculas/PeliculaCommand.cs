using Application.DTO;
using Application.Interfaces.Peliculas;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command.Peliculas
{
    public class PeliculaCommand : IPeliculaCommand
    {
        private readonly CineDBContext _context;

        public PeliculaCommand(CineDBContext context)
        {
            _context = context;
        }

        public Task<PeliculaDTOResponseDetail> UpdatePelicula(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            _context.SaveChanges();
            return Task.FromResult(new PeliculaDTOResponseDetail
            {
            });
        }

        public void CrearPelicula(Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
