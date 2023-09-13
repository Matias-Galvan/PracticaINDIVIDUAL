using Aplication.ErrorHandler;
using Aplication.Interfaces;
using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Funcion> GetFuncionPelicula(string peliculaNombre)
        {
            var listaFuncionesPelicula = new List<Funcion>();
            var listaFunciones = GetAllFunciones();
            listaFuncionesPelicula = listaFunciones.Where(funcion => funcion.Pelicula.Titulo.Contains(peliculaNombre, StringComparison.OrdinalIgnoreCase)).ToList();
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
            return listaFuncionesPelicula;
        }
        public List<Funcion> GetFuncionPeliculaYDia(string peliculaNombre, DateTime fecha)
        {
            var listaFuncionesPelicula = new List<Funcion>();
            var listaFunciones = GetAllFunciones();
            listaFuncionesPelicula = listaFunciones.Where(funcion => funcion.Pelicula.Titulo.Contains(peliculaNombre, StringComparison.OrdinalIgnoreCase)).ToList();
            return listaFuncionesPelicula;
        }
    }
}
