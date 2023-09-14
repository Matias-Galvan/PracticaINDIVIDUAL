
using Aplication.Interfaces;
using Aplication.UseCase.Controller;
using Aplication.UseCase.Services;
using Data;
using Domain.Entities;
using System.Diagnostics;

using (CineDBContext context = new CineDBContext())
{
    var _context = context;
    var serviceFuncion = new FuncionService(context);
    Menu menu = new Menu();
    userConsole userConsole = new userConsole();
    int opcion = 0;
    int opcionBusqueda = 0;
    int opcionBusquedaFuncion = 0;
    int opcionCargaFuncion = 0;
    bool continuarMenuPrincipal = true;
    bool continuarMenuFuncion = true;
    bool continuarMenuCarga = true;
    bool volverAlMenuPrincipal;


    while (continuarMenuPrincipal)
    {
        try
        {
            menu.menuPrincipal();
            if (Int32.TryParse(Console.ReadLine(), out opcionBusqueda))
            {
                switch(opcionBusqueda) 
                {                  
                        case 1:
                        //Busqueda de funciones
                        continuarMenuFuncion = true;
                        while (continuarMenuFuncion)
                        {
                            menu.menuBusquedaFuncion();
                            if (Int32.TryParse(Console.ReadLine(), out opcionBusquedaFuncion))
                            {
                                switch (opcionBusquedaFuncion)
                                {
                                    case 1:
                                        //Busqueda funcion por dia
                                        userConsole.buscarFuncionPelicula(_context);
                                        break;
                                    case 2:
                                        //Busqueda funcion por pelicula
                                        userConsole.buscarFuncionDia(_context);
                                        break;
                                    case 3:
                                        //Busqueda funcion por peli y dia
                                        userConsole.buscarFuncionDiaPelicula(context);
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
                            menu.menuCargaFuncion();
                            if (Int32.TryParse(Console.ReadLine(), out opcionCargaFuncion))
                            {
                                switch (opcionCargaFuncion)
                                {
                                    case 1:
                                        userConsole.crearModelo(context);
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




