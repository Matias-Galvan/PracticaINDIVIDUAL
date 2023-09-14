using Aplication.ErrorHandler;
using Aplication.Interfaces;
using Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Aplication.UseCase.Services
{
    public class FuncionService : IFuncionService
    {
        private readonly CineDBContext _context;
        public FuncionService(CineDBContext context)
        {
            _context = context;
        }

        public void crearFuncion(Funcion funcion)
        {
            var totalFunciones = _context.Funciones.ToList().Count;
            int nextId;
            if (totalFunciones != 0)
            {
                nextId = totalFunciones + 1;
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

        public List<Funcion> GetFuncionPelicula(int peliculaNombre)
        {
            var listaFuncionesPelicula = new List<Funcion>();
            var listaFunciones = GetAllFunciones();
            listaFuncionesPelicula = listaFunciones.Where(funcion => funcion.Pelicula.PeliculaId==(peliculaNombre)).ToList();
            if (!listaFuncionesPelicula.Any())
            {
                throw new ElementNotFoundException("No hay funciones para la película seleccionada");
            }
            return listaFuncionesPelicula;
        }
        public List<Funcion> GetFuncionDia(DateTime dia)
        {
            var listaFuncionesPelicula = new List<Funcion>();
            var listaFunciones = GetAllFunciones();
            listaFuncionesPelicula = listaFunciones.Where(funcion => funcion.Fecha.Date == dia.Date).ToList();
            if (!listaFuncionesPelicula.Any())
            {
                throw new ElementNotFoundException("No hay funciones para la fecha seleccionada");
            }
            return listaFuncionesPelicula;
        }
        public List<Funcion> GetFuncionPeliculaYDia(int peliculaNombre, DateTime fecha)
        {
            var listaFuncionesPelicula = new List<Funcion>();
            var listaFunciones = GetAllFunciones();
            listaFuncionesPelicula = listaFunciones.Where(funcion => funcion.Pelicula.PeliculaId == (peliculaNombre) && funcion.Fecha.Date == fecha.Date).ToList();
            if (!listaFuncionesPelicula.Any())
            {
                throw new ElementNotFoundException("No hay funciones para la película y fecha seleccionada");
            }
            return listaFuncionesPelicula;
        }

    }
}
