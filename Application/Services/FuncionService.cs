using Aplication.ErrorHandler;
using Aplication.Interfaces;
using Data.Persistence;
using Domain.Entities;

namespace Aplication.UseCase.Services
{
    public class FuncionService : IFuncionService
    {
        private readonly CineDBContext _context;
        public FuncionService(CineDBContext context)
        {
            _context = context;
        }

        public void CrearFuncion(Funcion funcion)
        {
            var TotalFunciones = _context.Funciones.ToList().Count;
            int nextId;
            if (TotalFunciones != 0)
            {
                nextId = TotalFunciones + 1;
            }
            else
            {
                nextId = 1;
            }
            funcion.FuncionId = nextId;
            
            _context.Funciones.Add(funcion);
            _context.SaveChanges();            
        }

        public List<Funcion> GetAllFunciones()
        {
            if (_context.Funciones.ToList().Count == 0)
            {
                throw new ListEmptyException("La lista de funciones se encuentra vacía");
            }
            return _context.Funciones.ToList();
        }

        public List<Funcion> GetFuncionPelicula(int PeliculaNombre)
        {
            var ListaFuncionesPelicula = new List<Funcion>();
            var ListaFunciones = GetAllFunciones();
            ListaFuncionesPelicula = ListaFunciones.Where(funcion => funcion.Pelicula.PeliculaId==(PeliculaNombre)).ToList();
            if (!ListaFuncionesPelicula.Any())
            {
                throw new ElementNotFoundException("No hay funciones para la película seleccionada");
            }
            return ListaFuncionesPelicula;
        }
        public List<Funcion> GetFuncionDia(DateTime Dia)
        {
            var ListaFuncionesPelicula = new List<Funcion>();
            var ListaFunciones = GetAllFunciones();
            ListaFuncionesPelicula = ListaFunciones.Where(funcion => funcion.Fecha.Date == Dia.Date).ToList();
            if (!ListaFuncionesPelicula.Any())
            {
                throw new ElementNotFoundException("No hay funciones para la fecha seleccionada");
            }
            return ListaFuncionesPelicula;
        }
        public List<Funcion> GetFuncionPeliculaYDia(int peliculaNombre, DateTime fecha)
        {
            var ListaFuncionesPelicula = new List<Funcion>();
            var ListaFunciones = GetAllFunciones();
            ListaFuncionesPelicula = ListaFunciones.Where(funcion => funcion.Pelicula.PeliculaId == (peliculaNombre) && funcion.Fecha.Date == fecha.Date).ToList();
            if (!ListaFuncionesPelicula.Any())
            {
                throw new ElementNotFoundException("No hay funciones para la película y fecha seleccionada");
            }
            return ListaFuncionesPelicula;
        }

    }
}
