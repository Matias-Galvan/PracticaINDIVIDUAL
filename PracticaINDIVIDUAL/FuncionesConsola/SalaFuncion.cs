using Application.ErrorHandler;
using Domain.Entities;

namespace PracticaINDIVIDUAL.Funciones
{
    public class SalaFuncion
    {
        public static int ObtenerSalaId(List<Sala> salas)
        {
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*              Salas disponibles:                       *");
            Console.WriteLine("*********************************************************");
            foreach (var sala in salas)
            {
                Console.WriteLine($"Código: {sala.SalaId}, Nombre: {sala.Nombre}");
            }
            while (true)
            {
                Console.WriteLine("Seleccione el código de la sala");
                if (int.TryParse(Console.ReadLine(), out int SalaId))
                {
                    if (salas.Any(sala => sala.SalaId == SalaId))
                    {
                        Console.WriteLine("Sala seleccionada correctamente");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        return SalaId;
                    }
                    else
                    {
                        throw new ElementNotFoundException("Sala no encontrada, intente nuevamente");
                    }
                }
            }
        }
    }
}
