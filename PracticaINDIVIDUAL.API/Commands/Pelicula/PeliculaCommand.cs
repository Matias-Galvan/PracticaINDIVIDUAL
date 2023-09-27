using Application.DTO;
using Application.Interfaces.Command;
using Infraestructure;

namespace PracticaINDIVIDUAL.API.Commands.Pelicula
{
    public class PeliculaCommand : IPeliculaCommand
    {
        private readonly CineDBContext _cineDBContext;

        public PeliculaCommand(CineDBContext cineDBContext)
        {
            _cineDBContext = cineDBContext;
        }

        public Task<PeliculaDTOResponse> actualizarPelicula(int funcionId)
        {
            throw new NotImplementedException();
        }
    }
}
