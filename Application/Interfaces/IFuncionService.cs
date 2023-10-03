using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IFuncionService
    {
        void CrearFuncion(Funcion funcion);
        List<Funcion>GetAllFunciones();
        List<Funcion> GetFuncionPelicula(int PeliculaNombre);
        List<Funcion> GetFuncionDia(DateTime dia);
        List<Funcion> GetFuncionPeliculaYDia(int PeliculaNombre, DateTime fecha);
    }
}
