namespace PracticaINDIVIDUAL.Funciones
{
    public class HoraFuncion
    {
        public static TimeSpan ObtenerHora()
        {
            while (true)
            {
                Console.WriteLine("Ingrese la hora de la función (hh:mm)");
                if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan hora))
                {
                    return hora;
                }
                else
                {
                    Console.WriteLine("Hora inválida, intente nuevamente");
                }
            }
        }
    }
}
