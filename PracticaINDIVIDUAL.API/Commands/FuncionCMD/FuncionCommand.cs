using Aplication.ErrorHandler;
using Aplication.UseCase.Services;
using Application.DTO;
using Application.Interfaces.Command;
using Domain.Entities;
using Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaINDIVIDUAL.API.Commands.FuncionCMD
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

        public async Task<FuncionDTOResponse> crearFuncion(Funcion request)
        {
            var funciones = await _context.Funciones.ToListAsync() ?? throw new ElementNotFoundException("No hay funciones disponibles en cartelera");
            var funcion = new Funcion();
            funcion.Fecha = request.Fecha;
            var peliculaId = request.PeliculaId;
            var pelicula = _context.Peliculas.Find(peliculaId) ?? throw new ElementNotFoundException("Película no encontrada");
            funcion.Pelicula = pelicula;
            funcion.SalaId = request.SalaId;
            var sala = _context.Salas.Find(request.SalaId) ?? throw new ElementNotFoundException("Sala no encontrada");
            funcion.Sala = sala;
            funcion.Tickets = new List<Ticket>(sala.Capacidad);
            funcion.Horario = request.Horario;
            var horarioProximo = request.Horario.Add(new TimeSpan(2, 30, 0));
            var horarioAnterior = request.Horario.Add(new TimeSpan(-2, 30, 0));
            var genero = _context.Generos.Find(pelicula.GeneroId) ?? throw new ElementNotFoundException("Género no encontrado");
 
                if (funciones.Any(f => f.Fecha.ToString("yyyy-MM-dd") == funcion.Fecha.ToString("yyyy-MM-dd") && f.Horario == funcion.Horario && f.SalaId == funcion.SalaId))
                {
                    throw new ElementAlreadyExistException("Ya existe una función para ese día y horario en esa sala");
                }
                if(funciones.Any(f => f.Horario <= horarioProximo && f.Horario >= horarioAnterior && f.SalaId == funcion.SalaId && f.Fecha.ToString("yyyy-MM-dd") == funcion.Fecha.ToString("yyyy-MM-dd")))
                {
                    throw new ElementAlreadyExistException("No se puede crear una función para ese día y horario en esa sala, hay superposición horaria. Intente nuevamente");
                }
                _context.Funciones.Add(funcion);
                await _context.SaveChangesAsync();
                return new FuncionDTOResponse
                {
                    FuncionId = funcion.FuncionId,
                    Pelicula = new PeliculaDTOResponse
                    {
                        PeliculaId = funcion.Pelicula.PeliculaId,
                        Titulo = pelicula.Titulo,
                        Poster = pelicula.Poster,
                        Genero = new GeneroDTOResponse
                        {
                            GeneroId = pelicula.GeneroId,
                            Nombre = genero.Nombre
                        },
                    },
                    Sala = new SalaDTOResponse
                    {
                        SalaId = funcion.SalaId,
                        Nombre = funcion.Sala.Nombre,
                        Capacidad = funcion.Sala.Capacidad
                    },
                    Fecha = funcion.Fecha,
                    Horario = funcion.Horario.ToString()
                };
            }

        public async Task<TicketDTOResponseTickets> crearTicketFuncion(int id, TicketDTO request)
        {
            List<TicketDTOResponseIDTicket> ticketsVendidos = new List<TicketDTOResponseIDTicket>();
            var funcion = _context.Funciones.Find(id) ?? throw new ElementNotFoundException("No existe la función");
            var pelicula = _context.Peliculas.Find(funcion.PeliculaId) ?? throw new ElementNotFoundException("No existe la película");
            var genero = _context.Generos.Find(pelicula.GeneroId) ?? throw new ElementNotFoundException("No existe el género");
            var sala = _context.Salas.Find(funcion.SalaId) ?? throw new ElementNotFoundException("No existe la sala");
            if (request.Cantidad > sala.Capacidad && sala.Capacidad != 0)
            {
                throw new InvalidOperationException("No es posible realizar la operación, se supera la cantidad máxima de tickets disponibles. Intente nuevamente");
            }
            for (int i = 0; i < request.Cantidad; i++)
            {

                if (sala.Capacidad == 0)
                {
                    throw new Exception("Tickets agotados para esta función");
                }
                var ticket = new Ticket();
                ticket.TicketId = new Guid();
                ticket.FuncionId = id;
                ticket.Funcion = funcion;
                ticket.Usuario = request.Usuario;
                sala.Capacidad--;
                ticketsVendidos.Add(new TicketDTOResponseIDTicket { ticketId = ticket.TicketId });
                _context.Add(ticket);
            }
            await _context.SaveChangesAsync();
            return new TicketDTOResponseTickets
            {
                Tickets = ticketsVendidos,
                Usuario = request.Usuario,
                Funcion = new FuncionDTOResponse
                {
                    Fecha = funcion.Fecha,
                    Horario = funcion.Horario.ToString(),
                    FuncionId = funcion.FuncionId,
                    Pelicula = new PeliculaDTOResponse
                    {
                        PeliculaId = pelicula.PeliculaId,
                        Titulo = pelicula.Titulo,
                        Poster = pelicula.Poster,
                        Genero = new GeneroDTOResponse
                        {
                            GeneroId = pelicula.GeneroId,
                            Nombre = genero.Nombre
                        }
                    },
                    Sala = new SalaDTOResponse
                    {
                        SalaId = sala.SalaId,
                        Nombre = sala.Nombre,
                        Capacidad = sala.Capacidad
                    }
                }

            };

        }

        public async Task<FuncionDTOResponseDetail> eliminarFuncion(int funcionId)
        {
            List<Funcion> funciones = await _context.Funciones.ToListAsync();
            if (funciones == null)
            {
                throw new ElementNotFoundException("No hay funciones");
            }
            var funcion = await _context.Funciones.FindAsync(funcionId);
            if (funcion == null)
            {
                throw new ElementNotFoundException("No existe la funcion");
            }
            var tickets = await _context.Tickets.Where(t => t.FuncionId == funcionId).ToListAsync();
            if (tickets.Count > 0)
            {
                throw new InvalidOperationException("No se puede eliminar la función porque hay tickets vendidos");
            }
            _context.Funciones.Remove(funcion);
            await _context.SaveChangesAsync();
            return new FuncionDTOResponseDetail
            {
                Fecha = funcion.Fecha,
                Horario = funcion.Horario.ToString(),
                FuncionId = funcion.FuncionId,
            }; 
        }
    }



    
}
