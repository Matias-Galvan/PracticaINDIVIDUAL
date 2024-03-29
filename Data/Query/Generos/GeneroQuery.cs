﻿using Application.DTO;
using Application.Interfaces.Generos;
using Domain.Entities;
using Infraestructure.Persistence;
using System.Data.Entity;

namespace Infraestructure.Query.Generos
{
    public class GeneroQuery : IGeneroQuery
    {
        private readonly CineDBContext _dbContext;

        public GeneroQuery(CineDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<GeneroDTOResponse>> GetAll()
        {
            return _dbContext.Generos.Select(g => new GeneroDTOResponse
            {
                id = g.GeneroId,
                Nombre = g.Nombre
            }).ToListAsync();
        }

        public Task<GeneroDTOResponse> GetById(int id)
        {
            var genero = _dbContext.Generos.Where(g => g.GeneroId == id).FirstOrDefault();

            return Task.FromResult(new GeneroDTOResponse
            {
                id = genero.GeneroId,
                Nombre = genero.Nombre
            });
        }
        public Genero GetGenero(int id)
        {
            var genero = _dbContext.Generos.Where(g => g.GeneroId == id).FirstOrDefault();
            return genero;
        }
        public List<Genero> GetGeneros()
        {
            return _dbContext.Generos.ToList();
        }

    }
}
