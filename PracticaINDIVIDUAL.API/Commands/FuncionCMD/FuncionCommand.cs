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
            var funcion = new Funcion();
            funcion.Fecha = request.Fecha;
            var peliculaId = request.PeliculaId;
            var pelicula = _context.Peliculas.Find(peliculaId);
            funcion.Pelicula = pelicula;
            funcion.SalaId = request.SalaId;
            var sala = _context.Salas.Find(request.SalaId);
            funcion.Sala = new Sala { Nombre = sala.Nombre, Capacidad = sala.Capacidad };
            funcion.Tickets = new List<Ticket>(sala.Capacidad);
            funcion.Horario = request.Horario;
            try
            {             
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
                            Nombre = _context.Generos.Find(pelicula.GeneroId).Nombre
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TicketDTOResponseTickets> crearTicketFuncion(int id, TicketDTO request)
        {
            List<TicketDTOResponseIDTicket> ticketsVendidos = new List<TicketDTOResponseIDTicket>();
            var funcion = _context.Funciones.Find(id);
            var pelicula = _context.Peliculas.Find(funcion.PeliculaId);
            var genero = _context.Generos.Find(pelicula.GeneroId);
            var sala = _context.Salas.Find(funcion.SalaId);
            if (funcion == null)
            {
                throw new Exception("No existe la funcion");
            }

            for (int i = 0; i< request.Cantidad; i++)
            {
                if (sala.Capacidad == 0)
                {
                    throw new Exception("No hay capacidad en la sala");
                }
                var ticket = new Ticket();
                ticket.TicketId = new Guid();
                ticket.FuncionId = id;
                ticket.Funcion = funcion;
                ticket.Usuario = request.Usuario;
                sala.Capacidad = sala.Capacidad - 1;
                ticketsVendidos.Add(new TicketDTOResponseIDTicket { IDTicket = ticket.TicketId});
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
                }

            };
            
            
           
            
            
            

        
        }

        public async Task<FuncionDTOResponse> eliminarFuncion(int funcionId)
        {
            List<Funcion> funciones = await _context.Funciones.ToListAsync();
            if (funciones == null)
            {
                throw new Exception("No hay funciones");
            }
            var funcion = await _context.Funciones.FindAsync(funcionId);
            if (funcion == null)
            {
                throw new Exception("No existe la funcion");
            }
            _context.Funciones.Remove(funcion);
            await _context.SaveChangesAsync();
            return new FuncionDTOResponse
            {
                Fecha = funcion.Fecha,
                Horario = funcion.Horario.ToString(),
                FuncionId = funcion.FuncionId,
            };
                  
        }

    }
}
