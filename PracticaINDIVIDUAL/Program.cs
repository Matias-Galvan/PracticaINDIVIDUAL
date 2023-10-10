using Application.Services;
using Infraestructure.Command.Funciones;
using Infraestructure.Persistence;
using Infraestructure.Query.Funciones;
using Infraestructure.Query.Peliculas;
using Infraestructure.Query.Salas;
using PracticaINDIVIDUAL.Controller;
{


    bool ContinuarMenuPrincipal = true;
    bool ContinuarMenuFuncion;
    bool ContinuarMenuCarga;
    using var db = new CineDBContext();
    var FuncionCommandInicial = new FuncionCommand(db);
    var FuncionQueryInicial = new FuncionQuery(db);
    var PeliculaQueryInicial = new PeliculaQuery(db);
    var SalaQueryInicial = new SalaQuery(db);
    var FuncionServiceInicial = new FuncionService(FuncionCommandInicial, FuncionQueryInicial);
    var PeliculaServiceInicial = new PeliculaService(PeliculaQueryInicial);
    var SalaServiceInicial = new SalaService(SalaQueryInicial);
    FuncionController UserConsole = new(FuncionServiceInicial, PeliculaServiceInicial, SalaServiceInicial);
    while (ContinuarMenuPrincipal)
    {
        try
        {
            Menu.MenuPrincipal();
            if (int.TryParse(Console.ReadLine(), out int OpcionBusqueda))
            {
                switch (OpcionBusqueda)
                {
                    case 1:
                        //Busqueda de funciones
                        ContinuarMenuFuncion = true;
                        while (ContinuarMenuFuncion)
                        {
                            Menu.MenuBusquedaFuncion();
                            if (int.TryParse(Console.ReadLine(), out int OpcionBusquedaFuncion))
                            {
                                switch (OpcionBusquedaFuncion)
                                {
                                    case 1:
                                        //Busqueda funcion por dia
                                        UserConsole.BuscarFuncionPelicula();
                                        break;
                                    case 2:
                                        //Busqueda funcion por pelicula
                                        UserConsole.BuscarFuncionDia();
                                        break;
                                    case 3:
                                        //Busqueda funcion por peli y dia
                                        UserConsole.BuscarFuncionPeliculaDia();
                                        break;
                                    case 4:
                                        //Salir
                                        ContinuarMenuFuncion = false;
                                        break;
                                    default:
                                        Console.WriteLine("Opción inválida");
                                        break;
                                }
                            }

                        }
                        break;
                    case 2:
                        //Carga de pelis
                        ContinuarMenuCarga = true;
                        while (ContinuarMenuCarga)
                        {
                            Menu.MenuCargaFuncion();
                            if (int.TryParse(Console.ReadLine(), out int OpcionCargaFuncion))
                            {
                                switch (OpcionCargaFuncion)
                                {
                                    case 1:
                                        UserConsole.CrearFuncion();
                                        Console.WriteLine("Presione una tecla para continuar...");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        ContinuarMenuCarga = false;
                                        break;
                                    default:
                                        Console.WriteLine("Opción inválida");
                                        break;
                                }
                            }

                        }
                        break;
                    case 3:
                        //Salir
                        ContinuarMenuPrincipal = false;
                        Console.WriteLine("Saliendo...");
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




