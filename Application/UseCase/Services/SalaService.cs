using Aplication.ErrorHandler;
using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase.Services
{
    public class SalaService : ISalaService
    {
        private readonly CineDBContext _context;
        public SalaService(CineDBContext context) 
        {
            _context = context;
        }
        public List<Sala> getAll()
        {
            return _context.Salas.ToList();
        }

        public Sala getSala(int id)
        {
            var sala = _context.Salas.FirstOrDefault(p => p.SalaId == id);

            if (sala != null)
            {
                return sala;
            }
            else
            {
                throw new ElementNotFoundException("Sala no encontrada");
            }
        }
    }
}
