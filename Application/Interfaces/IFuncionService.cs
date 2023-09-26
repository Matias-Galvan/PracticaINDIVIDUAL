using Application.DTO;
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
        Task crearFuncion(Funcion funcion);
        Task<FuncionDTO> agregarFuncion(FuncionDTO funcion);
        List<Funcion>GetAllFunciones();
        List<Funcion> GetFuncionPelicula(int peliculaNombre);
        List<Funcion> GetFuncionDia(DateTime dia);
        List<Funcion> GetFuncionPeliculaYDia(int peliculaNombre, DateTime fecha);
    }
}
