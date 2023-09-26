using Aplication.UseCase.Controller;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public class Menu
    {
        public Menu() { }

        /*Métodos*/
        public void menuPrincipal()
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
        public void menuBusquedaFuncion()
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
        public void menuCargaFuncion()
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


    }
}
