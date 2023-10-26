using Application.DTO;
using Application.Interfaces.Funciones;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command.Funciones
{
    public class FuncionCommand : IFuncionCommand
    {
        private readonly CineDBContext _context;
        public FuncionCommand(CineDBContext context)
        {
            _context = context;
        }

        public Task<FuncionDTOResponse> actualizarFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }

        public void CrearFuncion(Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            _context.SaveChanges();

        }

        public Task<FuncionDTOResponse> crearFuncion(Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            _context.SaveChangesAsync();
            return new FuncionDTOResponse
            {
                FuncionId = funcion.FuncionId,
                Pelicula = new PeliculaDTOResponse
                {
                    PeliculaId = funcion.PeliculaId,
                    Titulo = funcion.Peliculas.Titulo,
                    Poster = funcion.Peliculas.Poster,
                    Genero = new GeneroDTOResponse
                    {
                        GeneroId = funcion.Peliculas.Genero,
                        Nombre = funcion.Peliculas.Generos.Nombre
                    },
                },
                Sala = new SalaDTOResponse
                {
                    SalaId = funcion.SalaId,
                    Nombre = funcion.Salas.Nombre,
                    Capacidad = funcion.Salas.
                },
                Fecha = funcion.Fecha,
                Horario = funcion.Horario.ToString()
            };
        }

        public Task<TicketDTOResponseTickets> crearTicketFuncion(int id, TicketDTO request)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionDTOResponseDetail> eliminarFuncion(int funcionId)
        {
            throw new NotImplementedException();
        }
    }
}
