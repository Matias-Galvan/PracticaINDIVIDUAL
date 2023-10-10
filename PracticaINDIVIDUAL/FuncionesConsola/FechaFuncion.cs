using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaINDIVIDUAL.Funciones
{
    public class FechaFuncion
    {
        public static DateTime ObtenerFecha()
        {
            while (true)
            {
                Console.WriteLine("Ingrese la fecha de la función (dd/mm/yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                {
                    return fecha;
                }
                else
                {
                    Console.WriteLine("Fecha inválida, intente nuevamente");
                }
            }
        }   
    }
}
