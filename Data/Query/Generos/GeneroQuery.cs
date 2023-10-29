using Application.DTO;
using Application.Interfaces.Generos;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                GeneroId = g.GeneroId,
                Nombre = g.Nombre
            }).ToListAsync();
        }

        public Task<GeneroDTOResponse> GetById(int id)
        {
            var genero = _dbContext.Generos.Where(g => g.GeneroId == id).FirstOrDefault();

            return new Task<GeneroDTOResponse>(() =>
            {
                return new GeneroDTOResponse
                {
                    GeneroId = genero.GeneroId,
                    Nombre = genero.Nombre
                };
            });
        }
        public Genero GetGenero(int id)
        {
            return _dbContext.Generos.Where(g => g.GeneroId == id).FirstOrDefault();
        }

    }
}
