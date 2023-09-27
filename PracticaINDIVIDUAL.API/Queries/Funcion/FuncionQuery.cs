﻿using Application.Interfaces.Queries;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Filters;
using System.Runtime.InteropServices;
using LinqKit;
using Aplication.UseCase.Services;
using Application.DTO;

namespace PracticaINDIVIDUAL.API.Queries.Funcion
{
    public class FuncionQuery : IFuncionQuery
    {
        private readonly CineDBContext _dbContext;

        public FuncionQuery(CineDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Domain.Entities.Funcion>> GetFuncionPeliculaYDia(int peliculaNombre, DateTime fecha)
        {
            Task<List<Domain.Entities.Funcion>> funciones = _dbContext.Funciones.Where(x => x.PeliculaId == peliculaNombre && x.Fecha == fecha).ToListAsync();
            return funciones;
        }
        

        public Task<List<FuncionDTOResponse>> listarFunciones(FuncionFilters filters)
        {
            var predicate = PredicateBuilder.New<Domain.Entities.Funcion>(true);
            if (!string.IsNullOrEmpty(filters.Titulo))
            {   
                var peliculas = new PeliculaService(_dbContext).getAllPelicula();
                var pelicula = peliculas.Where(p => p.Titulo.Contains(filters.Titulo)).FirstOrDefault();
                predicate = predicate.And(x => x.PeliculaId == pelicula.PeliculaId);
            }
            if (filters.Fecha != null)
            {
                predicate = predicate.And(x => x.Fecha == DateTime.Parse(filters.Fecha));
            }
            if (filters.Genero != null)
            {
                predicate = predicate.And(x => x.Pelicula.GeneroId == filters.Genero);
            }
            return _dbContext.Funciones.Where(predicate).Select(x => new FuncionDTOResponse
            {
                FuncionId = x.FuncionId,
                Fecha = x.Fecha,
                Horario = x.Horario.ToString(),
                Pelicula = new PeliculaDTOResponse
                {
                    PeliculaId = x.Pelicula.PeliculaId,
                    Titulo = x.Pelicula.Titulo,
                    Poster = x.Pelicula.Poster,
                    Genero = new GeneroDTOResponse
                    {
                        GeneroId = x.Pelicula.Genero.GeneroId,
                        Nombre = x.Pelicula.Genero.Nombre
                    }
                },
                Sala = new SalaDTOResponse
                {
                    SalaId = x.Sala.SalaId,
                    Nombre = x.Sala.Nombre,
                    Capacidad = x.Sala.Capacidad
                }
            }).ToListAsync();
        }

        public Task<FuncionDTOResponse> obtenerFuncionPorId(int funcionId)
        {
            var funcion = _dbContext.Funciones.Where(x => x.FuncionId == funcionId).FirstOrDefault();
            if (funcion == null)
            {
                throw new Exception("No existe la funcion");
            }
            var pelicula = _dbContext.Peliculas.Where(x => x.PeliculaId == funcion.PeliculaId).FirstOrDefault();
            var genero = _dbContext.Generos.Where(x => x.GeneroId == pelicula.GeneroId).FirstOrDefault();
            var sala = _dbContext.Salas.Where(x => x.SalaId == funcion.SalaId).FirstOrDefault();
            return Task.FromResult(new FuncionDTOResponse
            {
                FuncionId = funcion.FuncionId,
                Fecha = funcion.Fecha,
                Horario = funcion.Horario.ToString(),
                Pelicula = new PeliculaDTOResponse
                {
                    PeliculaId = pelicula.PeliculaId,
                    Titulo = pelicula.Titulo,
                    Poster = pelicula.Poster,
                    Genero = new GeneroDTOResponse
                    {
                        GeneroId = genero.GeneroId,
                        Nombre = genero.Nombre
                    }
                },
                Sala = new SalaDTOResponse
                {
                    SalaId = sala.SalaId,
                    Nombre = sala.Nombre,
                    Capacidad = sala.Capacidad
                }
            });
        }

        public Task<TicketsDTOResponse> obtenerTicketsFuncionPorId(int id)
        {
            var funcion = _dbContext.Funciones.Where(x => x.FuncionId == id).FirstOrDefault();
            if (funcion == null)
            {
                throw new Exception("No existe la funcion");
            }
            var sala = _dbContext.Salas.Where(x => x.SalaId == funcion.SalaId).FirstOrDefault();
            var tickets = _dbContext.Tickets.Where(x => x.FuncionId == funcion.FuncionId).ToList();
            var ticketsDisponibles = sala.Capacidad - tickets.Count();
            return Task.FromResult(new TicketsDTOResponse
            {

              Cantidad = sala.Capacidad
                
            });
        }
    }
}
