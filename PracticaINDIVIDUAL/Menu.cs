namespace Application.Services
{
    public class Menu
    {
        /*Atributos*/
        public Menu() { }

        /*Métodos*/
        public static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("*************************************************");
            Console.WriteLine("  Bienvenido al cine The Kerry Filming Affinity  ");
            Console.WriteLine("*************************************************");
            Console.WriteLine("                                                 ");
            Console.WriteLine("              Menú de opciones                   ");
            Console.WriteLine("                                                 ");
            Console.WriteLine("         1-Buscar funciones disponibles");
            Console.WriteLine("         2-Cargar una función nueva");
            Console.WriteLine("         3-Salir");
            Console.Write("Opcion: ");

        }
        public static void MenuBusquedaFuncion()
        {
            Console.Clear();
            Console.WriteLine("*************************************************");
            Console.WriteLine("             Búsqueda de funciones               ");
            Console.WriteLine("*************************************************");
            Console.WriteLine("                                                 ");
            Console.WriteLine("        Seleccione el método de búsqueda         ");
            Console.WriteLine("                                                 ");
            Console.WriteLine("1-Buscar funciones disponibles por título de película");
            Console.WriteLine("2-Buscar funciones disponibles por día");
            Console.WriteLine("3-Buscar funciones disponibles por título y día");
            Console.WriteLine("4-Volver al menú principal");
            Console.Write("Opcion: ");

        }
        public static void MenuCargaFuncion()
        {
            Console.Clear();
            Console.WriteLine("*************************************************");
            Console.WriteLine("             Carga de función                    ");
            Console.WriteLine("*************************************************");
            Console.WriteLine("En esta sección usted podrá cargar una función de " +
                                "una película en un día y sala determinados");
            Console.WriteLine("1-Comenzar");
            Console.WriteLine("2-Volver al menú principal");
            Console.Write("Opcion: ");

        }

        public static void ResumenFuncion()
        {
            Console.WriteLine("La función fue creada correctamente");
            Console.WriteLine($"Resumen de función " +
                $"Título: " +
                $"Sala: " +
                $"Fecha: " +
                $"Hora: ");
        }

        //public static void ListaPeliculas()
        //{
        //    Console.WriteLine("*********************************************************");
        //    Console.WriteLine("*              Películas disponibles:                   *");
        //    Console.WriteLine("*********************************************************");
        //    foreach (var pelicula in listaPeliculas)
        //    {
        //        Console.WriteLine($"Código: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
        //    }
        //}


    }
}
