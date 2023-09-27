using Aplication.ErrorHandler;
using Aplication.UseCase.Services;
using Application.DTO;
using Application.Interfaces.Command;
using Infraestructure;
using Domain.Entities;

namespace PracticaINDIVIDUAL.API.Commands.Pelicula
{
    public class PeliculaCommand : IPeliculaCommand
    {
        private readonly CineDBContext _cineDBContext;

        public PeliculaCommand(CineDBContext cineDBContext)
        {
            _cineDBContext = cineDBContext;
        }

        public async Task<PeliculaDTOResponseDetail> actualizarPelicula(int funcionId, PeliculaDTO request)
        {
            var peliculas = _cineDBContext.Peliculas.ToList();
            var pelicula = _cineDBContext.Peliculas.FirstOrDefault(p => p.PeliculaId == funcionId);
            if (pelicula == null)
            {
                throw new ElementNotFoundException("Película no encontrada");
            }
            if(peliculas.Any(p => p.Titulo == request.Titulo))
            {
                throw new ElementAlreadyExistException("Ya existe una película con ese título");
            }
            
            pelicula.Titulo = request.Titulo;
            pelicula.Poster = request.Poster;
            pelicula.Trailer = request.Trailer;
            pelicula.Sinopsis = request.Sinopsis;
            pelicula.GeneroId = request.generoId;
            pelicula.Genero = new Genero
            {               
                Nombre = _cineDBContext.Generos.Find(request.generoId).Nombre
            };
            List<Funcion> funcions = _cineDBContext.Funciones.Where(f => f.PeliculaId == pelicula.PeliculaId).ToList();
            List<FuncionDTOResponseDetail> funciones = new List<FuncionDTOResponseDetail>();
            foreach (var funcion in funcions)
            {
                funciones.Add(new FuncionDTOResponseDetail
                {
                    FuncionId = funcion.FuncionId,
                    Fecha = funcion.Fecha,
                    Horario = funcion.Horario.ToString()
                });
            }

            _cineDBContext.Update(pelicula);
            await _cineDBContext.SaveChangesAsync();
            return new PeliculaDTOResponseDetail
            {
                PeliculaId = pelicula.PeliculaId,
                Titulo = pelicula.Titulo,
                Poster = pelicula.Poster,
                Trailer = pelicula.Trailer,
                Sinopsis = pelicula.Sinopsis,
                genero = new GeneroDTOResponse
                {
                    GeneroId = pelicula.GeneroId,
                    Nombre = _cineDBContext.Generos.Find(pelicula.GeneroId).Nombre
                },
                funciones = funciones
            };
        }
    }
}
