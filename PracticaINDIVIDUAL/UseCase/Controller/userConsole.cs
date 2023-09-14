using Aplication.ErrorHandler;
using Aplication.UseCase.Services;
using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplication.UseCase.Controller
{
    public class userConsole
    {
        public void crearModelo(CineDBContext context)
        {
            Console.Clear();
            var serviceFuncion = new FuncionService(context);
            var peliculaFuncion = new PeliculaService(context).getAllPelicula();
            var salaFuncion = new SalaService(context).getAll();
            var diaFuncion = validarFecha();
            var horaFuncion = validarHora();
            var funcion = new Funcion
            {
                PeliculaId = crearSolicitudPelicula(peliculaFuncion).PeliculaId,
                SalaId = crearSolicitudSala(salaFuncion).SalaId,
                Fecha = diaFuncion,
                Horario = horaFuncion
            };
            try 
            {
                serviceFuncion.crearFuncion(funcion);
                Console.WriteLine("La función fue creada correctamente");
                Console.WriteLine($"Resumen de función " +
                    $"Título: {new PeliculaService(context).getPelicula(funcion.PeliculaId).Titulo}" +
                    $"Sala: {new SalaService(context).getSala(funcion.SalaId).Nombre}" +
                    $"Fecha: {funcion.Fecha}" +
                    $"Hora: {funcion.Horario}");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
        public Funcion crearSolicitudPelicula(List<Pelicula> listaPeliculas)
        {   
            var funcion = new Funcion();
            Console.Clear();
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*              Películas disponibles:                   *");
            Console.WriteLine("*********************************************************");
            foreach (var pelicula in listaPeliculas)
            {
                Console.WriteLine($"Código: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
            }
            while (true)
            {
                try 
                {                    
                    Console.WriteLine("Seleccione el código de la película");
                    if(int.TryParse(Console.ReadLine(), out int peliculaId))
                    {
                        if (listaPeliculas.Any(peli => peli.PeliculaId == peliculaId))
                        {
                            Console.WriteLine("Película seleccionada correctamente");
                            funcion.PeliculaId = peliculaId;
                            return (funcion);
                        }
                        else
                        {
                            throw new ElementNotFoundException("Película no encontrada, intente nuevamente");
                        }
                    }

                }
                catch
                { 
                    throw new ParseFailedException("Código inválido, intente nuevamente");
                }
                
            }
            
        }
        public Funcion crearSolicitudSala(List<Sala> salas)
        {
            var funcion = new Funcion();
            Console.Clear();
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*                Salas disponibles:                     *");
            Console.WriteLine("*********************************************************");
            foreach (var sala in salas)
            {
                Console.WriteLine($"Código: {sala.SalaId}, Nombre de sala: {sala.Nombre}, Capacidad: { sala.Capacidad}");
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Seleccione el código de la sala");
                    if (int.TryParse(Console.ReadLine(), out int salaId))
                    {
                        if (salas.Any(sala => sala.SalaId == salaId))
                        {
                            Console.WriteLine("Sala seleccionada correctamente");
                            funcion.SalaId = salaId;
                            return funcion;
                        }
                        else
                        {
                            throw new ElementNotFoundException("Sala no encontrada, intente nuevamente");
                        }
                    }

                }
                catch
                {
                    throw new ParseFailedException("Código inválido, intente nuevamente");
                }

            }
            
        }
        public static DateTime validarFecha()
        {
            DateTime fecha;

            while (true)
            {
                Console.WriteLine("Ingrese la fecha en formato YYYY-mm-dd:");
                try
                {
                    if (DateTime.TryParse(Console.ReadLine(), out fecha))
                        break;
                    else
                        throw new Exception("Fecha no válida. Ingrese una fecha en el formato YYYY-MM-DD.");
                }
                catch
                {
                    throw new InvalidDateFormatException("Fecha inválida, intente nuevamente");
                }
            }

            return fecha;
        }
        public static DateTime validarHora()
        {
            DateTime hora;

            while (true)
            {
                Console.WriteLine("Ingrese la hora en formato HH-MM-SS:");
                try
                {
                    if (DateTime.TryParse(Console.ReadLine(), out hora))
                        break;
                    else
                        throw new Exception("Hora no válida. Ingrese una fecha en el formato HH-MM-SS.");
                }
                catch
                {
                    throw new InvalidDateFormatException("Hora inválida, intente nuevamente");
                }
            }

            return hora;
        }
        public void buscarFuncionDia()
        {

        }
    }
}
