using Application.ErrorHandler;
using Domain.Entities;

namespace PracticaINDIVIDUAL.Funciones
{
    public class PeliculaFuncion
    {
        public static int ObtenerPeliculaId(List<Pelicula> peliculas)
        {
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*              Películas disponibles:                   *");
            Console.WriteLine("*********************************************************");
            foreach (var pelicula in peliculas)
            {
                Console.WriteLine($"Código: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
            }
            while (true)
            {
                Console.WriteLine("Seleccione el código de la película");
                if (int.TryParse(Console.ReadLine(), out int PeliculaId))
                {
                    if (peliculas.Any(peli => peli.PeliculaId == PeliculaId))
                    {
                        Console.WriteLine("Película seleccionada correctamente");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        return PeliculaId;
                        
                    }
                    else
                    {
                        throw new ElementNotFoundException("Película no encontrada, intente nuevamente");
                    }
                }
            }
        }
    }
}
