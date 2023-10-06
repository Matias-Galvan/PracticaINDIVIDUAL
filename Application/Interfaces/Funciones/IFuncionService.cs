using Domain.Entities;

namespace Application.Interfaces.Funciones
{
    public interface IFuncionService
    {
        void CrearFuncion(Funcion funcion);
        List<Funcion> GetAllFunciones();
        List<Funcion> GetFuncionPelicula(int PeliculaNombre);
        List<Funcion> GetFuncionDia(DateTime dia);
        List<Funcion> GetFuncionPeliculaYDia(int PeliculaNombre, DateTime fecha);
    }
}
