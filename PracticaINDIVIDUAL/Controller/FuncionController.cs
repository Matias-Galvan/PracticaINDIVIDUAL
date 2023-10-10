﻿using Application.ErrorHandler;
using Application.Interfaces.Funciones;
using Application.Interfaces.Peliculas;
using Application.Interfaces.Salas;
using Domain.Entities;
using PracticaINDIVIDUAL.Funciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaINDIVIDUAL.Controller
{
    public class FuncionController
    {
        private readonly IFuncionService _funcionService;
        private readonly IPeliculaService _peliculaService;
        private readonly ISalaService _salaService;

        public FuncionController(IFuncionService funcionService, IPeliculaService peliculaService, ISalaService salaService)
        {
            _funcionService = funcionService;
            _peliculaService = peliculaService;
            _salaService = salaService;
        }

        public void CrearFuncion()
        {
            var peliculas = _peliculaService.GetAllPelicula();
            var salas = _salaService.GetAll();
            var PeliculaId = PeliculaFuncion.ObtenerPeliculaId(peliculas);
            var SalaId = SalaFuncion.ObtenerSalaId(salas);
            var fecha = FechaFuncion.ObtenerFecha();
            var hora = HoraFuncion.ObtenerHora();

            _funcionService.CrearFuncion(PeliculaId, SalaId, fecha, hora);
            Console.WriteLine("La función fue creada correctamente");
        }

        public void BuscarFuncionPelicula()
        {
            var peliculas = _peliculaService.GetAllPelicula();
            var salas = _salaService.GetAll();
            var PeliculaId = PeliculaFuncion.ObtenerPeliculaId(peliculas);
            var funciones = _funcionService.GetFuncionPelicula(PeliculaId);
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*              Funciones disponibles:                   *");
            Console.WriteLine("*********************************************************");
            foreach (var funcion in funciones)
            {
               Console.WriteLine($"Película: {peliculas[PeliculaId].Titulo}");
               Console.WriteLine($"Código: {funcion.FuncionId}, Sala: {salas[funcion.SalaId].Nombre}, Fecha: {funcion.Fecha:yyyy/MM/dd} , Hora: {funcion.Horario:HH:mm:ss}");
            }
            
        }
        public void BuscarFuncionDia()
        {
            var peliculas = _peliculaService.GetAllPelicula();
            var salas = _salaService.GetAll();
            var fecha = FechaFuncion.ObtenerFecha();
            var funciones = _funcionService.GetFuncionDia(fecha);
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*              Funciones disponibles:                   *");
            Console.WriteLine("*********************************************************");
            foreach (var funcion in funciones)
            {
                Console.WriteLine($"Fecha: {funcion.Fecha:yyyy/MM/dd} , Hora: {funcion.Horario:HH:mm:ss}");
                Console.WriteLine($"Código: {funcion.FuncionId}, Sala: {salas[funcion.SalaId].Nombre}, Película: {peliculas[funcion.PeliculaId].Titulo}");
            }

        }
        public void BuscarFuncionPeliculaDia()
        {
            var peliculas = _peliculaService.GetAllPelicula();
            var salas = _salaService.GetAll();
            var PeliculaId = PeliculaFuncion.ObtenerPeliculaId(peliculas);
            var fecha = FechaFuncion.ObtenerFecha();
            var funciones = _funcionService.GetFuncionPeliculaYDia(PeliculaId, fecha);
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*              Funciones disponibles:                   *");
            Console.WriteLine("*********************************************************");
            foreach (var funcion in funciones)
            {
                Console.WriteLine($"Fecha: {funcion.Fecha:yyyy/MM/dd} , Hora: {funcion.Horario:HH:mm:ss}");
                Console.WriteLine($"Código: {funcion.FuncionId}, Sala: {salas[funcion.SalaId].Nombre}, Película: {peliculas[funcion.PeliculaId].Titulo}");
            }
        }
    }
}
