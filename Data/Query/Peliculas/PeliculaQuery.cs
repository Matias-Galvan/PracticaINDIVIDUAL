using Application.Interfaces.Peliculas;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Query.Peliculas
{
    public class PeliculaQuery : IPeliculaQuery
    {
        private readonly CineDBContext _dbContext;
        public PeliculaQuery(CineDBContext context) 
        {
           _dbContext = context;
        }
        public List<Pelicula> GetAllPeliculas()
        {
            return _dbContext.Peliculas.ToList();
        }
    }
}
