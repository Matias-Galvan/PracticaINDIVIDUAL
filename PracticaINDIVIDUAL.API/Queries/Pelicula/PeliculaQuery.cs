using Aplication.ErrorHandler;
using Application.DTO;
using Application.Interfaces.Queries;
using Infraestructure;

namespace PracticaINDIVIDUAL.API.Queries.Pelicula
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly CineDBContext _cineDBContext;

        public PeliculaQuery(CineDBContext cineDBContext)
        {
            _cineDBContext = cineDBContext;
        }

        public Task<PeliculaDTOResponseDetail> GetPeliculaById(int peliculaId)
        {
            var pelicula = _cineDBContext.Peliculas.FirstOrDefault(p => p.PeliculaId == peliculaId);            
            if (pelicula == null)
            {
                   throw new ElementNotFoundException("Película no encontrada");
            }
            var genero = _cineDBContext.Generos.FirstOrDefault(g => g.GeneroId == pelicula.GeneroId);
            List<Domain.Entities.Funcion> funcions = _cineDBContext.Funciones.Where(f => f.PeliculaId == peliculaId).ToList();
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
            return Task.FromResult(new PeliculaDTOResponseDetail
            {
                PeliculaId = pelicula.PeliculaId,
                Titulo = pelicula.Titulo,
                Poster = pelicula.Poster,
                Trailer = pelicula.Trailer,
                Sinopsis = pelicula.Sinopsis,
                genero = new GeneroDTOResponse
                {
                    GeneroId = genero.GeneroId,
                    Nombre = genero.Nombre
                },
                funciones = funciones
            });
            

        }

        public Task<List<PeliculaDTOResponse>> GetPeliculas()
        {
            throw new NotImplementedException();
        }
    }
}
