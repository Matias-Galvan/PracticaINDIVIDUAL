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
        void crearFuncion(Funcion funcion);
        List<Funcion>GetAllFunciones();
        List<Funcion> GetFuncionPelicula(string peliculaNombre);
        List<Funcion> GetFuncionDia(DateTime dia);
        List<Funcion> GetFuncionPeliculaYDia(string peliculaNombre, DateTime fecha);
    }
}
