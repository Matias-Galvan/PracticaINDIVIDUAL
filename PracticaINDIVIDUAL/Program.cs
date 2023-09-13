
using Aplication.Interfaces;
using Aplication.UseCase.Controller;
using Aplication.UseCase.Services;
using Data;
using Domain.Entities;

using (CineDBContext context = new CineDBContext())
{
    var _context = context;
    var serviceFuncion = new FuncionService(context);
    Menu menu = new Menu();
    userConsole userConsole = new userConsole();
    int opcion = 0;
    int opcionBusquedaFuncion = 0;
    int opcionMenuConsulta = 0;
    bool continuarMenuPrincipal = true;
    bool continuarMenuAdmin = true;
    bool continuarMenuConsulta = true;
    bool volverAlMenuPrincipal;


    while (continuarMenuPrincipal)
    {
        try
        {
            menu.menuPrincipal();
            if (Int32.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        menu.menuBusquedaFuncion();
                        if (Int32.TryParse(Console.ReadLine(), out opcionBusquedaFuncion))
                        {
                            switch (opcionBusquedaFuncion)
                            {
                                case 1:
                                    try
                                    {
                                        //DateTime dia;
                                        
                                        //List<Funcion> funcionesDia = serviceFuncion.GetFuncionDia(dia);
                                    }
                                    catch (Exception ex)
                                    {

                                    }

                                    break;
                                case 2:

                                    break;
                                case 3:

                                    break;
                                case 4:

                                    break;
                            }
                        }
                        break;
                    case 2:
                        userConsole.crearModelo(context);
                        Console.ReadKey();
                        break;
                }
            }
        }
        catch (Exception ex)
        {

        }


    }

    var funciones = serviceFuncion.GetAllFunciones();
    Console.WriteLine(funciones);
}




