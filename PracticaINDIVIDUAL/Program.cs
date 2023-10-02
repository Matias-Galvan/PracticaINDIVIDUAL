
using Aplication.Interfaces;
using Aplication.UseCase.Services;
using Data.Persistence;
using Domain.Entities;
using PracticaINDIVIDUAL.Controller;
using System.Diagnostics;

using (CineDBContext context = new CineDBContext())
{
    var _context = context;
    var serviceFuncion = new FuncionService(context);
    Menu menu = new();
    UserConsole userConsole = new();
    int opcionBusqueda = 0;
    int opcionBusquedaFuncion = 0;
    int opcionCargaFuncion = 0;
    bool continuarMenuPrincipal = true;
    bool continuarMenuFuncion = true;
    bool continuarMenuCarga = true;


    while (continuarMenuPrincipal)
    {
        try
        {
            Menu.MenuPrincipal();
            if (Int32.TryParse(Console.ReadLine(), out opcionBusqueda))
            {
                switch(opcionBusqueda) 
                {                  
                        case 1:
                        //Busqueda de funciones
                        continuarMenuFuncion = true;
                        while (continuarMenuFuncion)
                        {
                            Menu.MenuBusquedaFuncion();
                            if (Int32.TryParse(Console.ReadLine(), out opcionBusquedaFuncion))
                            {
                                switch (opcionBusquedaFuncion)
                                {
                                    case 1:
                                        //Busqueda funcion por dia
                                        UserConsole.BuscarFuncionPelicula(_context);
                                        break;
                                    case 2:
                                        //Busqueda funcion por pelicula
                                        UserConsole.BuscarFuncionDia(_context);
                                        break;
                                    case 3:
                                        //Busqueda funcion por peli y dia
                                        UserConsole.BuscarFuncionDiaPelicula(context);
                                        break;
                                    case 4:
                                        //Salir
                                        continuarMenuFuncion = false;
                                        break;
                                    default: throw new Exception();
                                }
                            }
                             
                        }
                        break;
                        case 2:
                        //Carga de pelis
                        continuarMenuCarga = true;
                        while (continuarMenuCarga)
                        {
                            Menu.MenuCargaFuncion();
                            if (Int32.TryParse(Console.ReadLine(), out opcionCargaFuncion))
                            {
                                switch (opcionCargaFuncion)
                                {
                                    case 1:
                                        UserConsole.CrearModelo(context);
                                        Console.WriteLine("Presione una tecla para continuar...");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        continuarMenuCarga=false;
                                        break;
                                }
                            }

                        }
                        break;
                        case 3:
                        //Salir
                        continuarMenuPrincipal = false;
                        break;
                        default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }

}




