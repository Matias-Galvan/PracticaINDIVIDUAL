using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Salas
{
    public interface ISalaService
    {
        List<Sala> GetAll();
        Sala getSala(int id);
    }
}
