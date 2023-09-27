//using Aplication.ErrorHandler;
//using Aplication.UseCase.Services;
//using Domain.Entities;
//using Infraestructure;

//namespace Aplication.UseCase.Controller
//{
    //public class userConsole
    //{
    //    public void crearModelo(CineDBContext context)
    //    {
    //        Console.Clear();
    //        var serviceFuncion = new FuncionService(context);
    //        var peliculaFuncion = new PeliculaService(context).getAllPelicula();
    //        var salaFuncion = new SalaService(context).getAll();
    //        var diaFuncion = validarFecha();
    //        var horaFuncion = validarHora();
    //        var funcion = new Funcion
    //        {
    //            PeliculaId = crearSolicitudPelicula(peliculaFuncion).PeliculaId,
    //            SalaId = crearSolicitudSala(salaFuncion).SalaId,
    //            Fecha = diaFuncion,
    //            Horario = horaFuncion
    //        };
    //        try 
    //        {
    //            serviceFuncion.crearFuncion(funcion);
    //            Console.WriteLine("La función fue creada correctamente");
    //            Console.WriteLine($"Resumen de función " +
    //                $"Título: {new PeliculaService(context).getPelicula(funcion.PeliculaId).Titulo}" +
    //                $"Sala: {new SalaService(context).getSala(funcion.SalaId).Nombre}" +
    //                $"Fecha: {funcion.Fecha}" +
    //                $"Hora: {funcion.Horario}");
    //        }
    //        catch(Exception ex) 
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
            
            
    //    }
    //    public Funcion crearSolicitudPelicula(List<Pelicula> listaPeliculas)
    //    {   
    //        var funcion = new Funcion();
    //        Console.Clear();
    //        Console.WriteLine("*********************************************************");
    //        Console.WriteLine("*              Películas disponibles:                   *");
    //        Console.WriteLine("*********************************************************");
    //        foreach (var pelicula in listaPeliculas)
    //        {
    //            Console.WriteLine($"Código: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
    //        }
    //        while (true)
    //        {
    //            try 
    //            {                    
    //                Console.WriteLine("Seleccione el código de la película");
    //                if(int.TryParse(Console.ReadLine(), out int peliculaId))
    //                {
    //                    if (listaPeliculas.Any(peli => peli.PeliculaId == peliculaId))
    //                    {
    //                        Console.WriteLine("Película seleccionada correctamente");
    //                        funcion.PeliculaId = peliculaId;
    //                        Console.WriteLine("Presione una tecla para continuar...");
    //                        Console.ReadKey();
    //                        return (funcion);
    //                    }
    //                    else
    //                    {
    //                        throw new ElementNotFoundException("Película no encontrada, intente nuevamente");
    //                    }
    //                }

    //            }
    //            catch
    //            { 
    //                throw new ParseFailedException("Código inválido, intente nuevamente");
    //            }
                
    //        }
            
    //    }
    //    public Funcion crearSolicitudSala(List<Sala> salas)
    //    {
    //        var funcion = new Funcion();
    //        Console.Clear();
    //        Console.WriteLine("*********************************************************");
    //        Console.WriteLine("*                Salas disponibles:                     *");
    //        Console.WriteLine("*********************************************************");
    //        foreach (var sala in salas)
    //        {
    //            Console.WriteLine($"Código: {sala.SalaId}, Nombre de sala: {sala.Nombre}, Capacidad: { sala.Capacidad}");
    //        }
    //        while (true)
    //        {
    //            try
    //            {
    //                Console.WriteLine("Seleccione el código de la sala");
    //                if (int.TryParse(Console.ReadLine(), out int salaId))
    //                {
    //                    if (salas.Any(sala => sala.SalaId == salaId))
    //                    {
    //                        Console.WriteLine("Sala seleccionada correctamente");
    //                        funcion.SalaId = salaId;
    //                        Console.WriteLine("Presione una tecla para continuar...");
    //                        Console.ReadKey();
    //                        return funcion;
    //                    }
    //                    else
    //                    {
    //                        throw new ElementNotFoundException("Sala no encontrada, intente nuevamente");
    //                    }
    //                }

    //            }
    //            catch
    //            {
    //                throw new ParseFailedException("Código inválido, intente nuevamente");
    //            }

    //        }
            
    //    }
    //    public static DateTime validarFecha()
    //    {
    //        DateTime fecha;

    //        while (true)
    //        {
    //            Console.WriteLine("Ingrese la fecha en formato YYYY-mm-dd:");
    //            try
    //            {
    //                if (DateTime.TryParse(Console.ReadLine(), out fecha))
    //                    break;
    //                else
    //                    throw new Exception("Fecha no válida. Ingrese una fecha en el formato YYYY-MM-DD.");
    //            }
    //            catch
    //            {
    //                throw new InvalidDateFormatException("Fecha inválida, intente nuevamente");
    //            }
    //        }

    //        return fecha;
    //    }
    //    public static TimeSpan validarHora()
    //    {
    //        TimeSpan hora;

    //        while (true)
    //        {
    //            Console.WriteLine("Ingrese la hora en formato HH-MM-SS:");
    //            try
    //            {
    //                if (TimeSpan.TryParse(Console.ReadLine(), out hora))
    //                    break;
    //                else
    //                    throw new Exception("Hora no válida. Ingrese una fecha en el formato HH-MM-SS.");
    //            }
    //            catch
    //            {
    //                throw new InvalidDateFormatException("Hora inválida, intente nuevamente");
    //            }
    //        }

    //        return hora;
    //    }
    //    public void buscarFuncionPelicula(CineDBContext context)
    //    {
    //        var buscarFuncion = new FuncionService(context);
    //        var funcion = new Funcion();
    //        var listaPeliculas = new PeliculaService(context).getAllPelicula();
    //        var listaSalas = new SalaService(context).getAll();
    //        Console.Clear();
    //        Console.WriteLine("*********************************************************");
    //        Console.WriteLine("*              Películas disponibles:                   *");
    //        Console.WriteLine("*********************************************************");
    //        foreach (var pelicula in listaPeliculas)
    //        {
    //            Console.WriteLine($"Código: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
    //            Console.WriteLine($"Sinopsis: {pelicula.Sinopsis}");
    //        }
    //            try
    //            {
    //                Console.WriteLine("Seleccione el código de la película");
    //                if (int.TryParse(Console.ReadLine(), out int peliculaId))
    //                {
    //                    if (listaPeliculas.Any(peli => peli.PeliculaId == peliculaId))
    //                    {
    //                        Console.WriteLine("Película seleccionada correctamente");
    //                        funcion.PeliculaId = peliculaId;
    //                        List<Funcion> listadoFunciones = buscarFuncion.GetFuncionPelicula(funcion.PeliculaId);
    //                        foreach (var func in listadoFunciones)
    //                        {
    //                        Console.WriteLine($"Película: {listaPeliculas[peliculaId].Titulo}");
    //                        Console.WriteLine($"Código: {func.FuncionId}, Sala: {listaSalas[func.SalaId].Nombre}, Fecha: {func.Fecha:yyyy/MM/dd} , Hora: {func.Horario:HH:mm:ss}");
    //                        }
    //                    Console.WriteLine("Presione una tecla para continuar...");
    //                        Console.ReadKey();
                            
    //                    }
    //                    else
    //                    {
    //                        throw new ElementNotFoundException("Película no encontrada, intente nuevamente");
    //                    }
    //                }

    //            }
    //            catch
    //            {
    //                throw new ParseFailedException("Código inválido, intente nuevamente");
    //            }

                        
    //    }
    //    public void buscarFuncionDia(CineDBContext context)
    //    {
    //        var buscarFuncion = new FuncionService(context);
    //        var funcion = new Funcion();
    //        var listadoPeliculas = new PeliculaService(context).getAllPelicula();
    //        var listadoSalas = new SalaService(context).getAll();
    //        Console.WriteLine("Ingrese la fecha a buscar en formato (YYYY/MM/DD)");
    //        string fechaBuscar = Console.ReadLine();
    //        DateTime fechaFiltro;
    //        if (!string.IsNullOrEmpty(fechaBuscar) && DateTime.TryParse(fechaBuscar, out DateTime fechaSeleccionada))
    //        {
    //            fechaFiltro = fechaSeleccionada;
    //            List<Funcion> listadoFunciones = buscarFuncion.GetFuncionDia(fechaFiltro);
    //            foreach (var func in listadoFunciones)
    //            {
    //                Console.WriteLine($"Fecha: {func.Fecha:yyyy/MM/dd}, Hora: {func.Horario:HH:mm:ss}");
    //                Console.WriteLine($"Código: {func.FuncionId}, Sala: {listadoSalas[func.SalaId].Nombre}, Película: {listadoPeliculas[func.PeliculaId].Titulo}");
    //            }
    //            Console.WriteLine("Presione una tecla para continuar...");
    //            Console.ReadKey();
    //        }
    //        else
    //        {
    //            throw new InvalidDateFormatException("Fecha inválida");
    //        }
    //    }
    //    public void buscarFuncionDiaPelicula(CineDBContext context)
    //    {
    //        var buscarFuncion = new FuncionService(context);
    //        var funcion = new Funcion();
    //        var listaPeliculas = new PeliculaService(context).getAllPelicula();
    //        var listaSalas = new SalaService(context).getAll();
    //        Console.Clear();
    //        Console.WriteLine("*********************************************************");
    //        Console.WriteLine("*              Películas disponibles:                   *");
    //        Console.WriteLine("*********************************************************");
    //        foreach (var pelicula in listaPeliculas)
    //        {
    //            Console.WriteLine($"Código: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
    //            Console.WriteLine($"Sinopsis: {pelicula.Sinopsis}");
    //        }
    //        try
    //        {
    //            Console.WriteLine("Seleccione el código de la película");
    //            if (int.TryParse(Console.ReadLine(), out int peliculaId))
    //            {
    //                if (listaPeliculas.Any(peli => peli.PeliculaId == peliculaId))
    //                {
    //                    Console.WriteLine("Película seleccionada correctamente");
    //                    funcion.PeliculaId = peliculaId;
    //                    Console.WriteLine("Ingrese la fecha a buscar en formato (YYYY/MM/DD)");
    //                    string fechaBuscar = Console.ReadLine();
    //                    DateTime fechaFiltro;
    //                    if (!string.IsNullOrEmpty(fechaBuscar) && DateTime.TryParse(fechaBuscar, out DateTime fechaSeleccionada))
    //                    {
    //                        fechaFiltro = fechaSeleccionada;
    //                        List<Funcion> listadoFunciones = buscarFuncion.GetFuncionPeliculaYDia(peliculaId,fechaFiltro);
    //                        foreach (var func in listadoFunciones)
    //                        {
    //                            Console.WriteLine($"Película: {listaPeliculas[func.PeliculaId].Titulo}, Fecha: {func.Fecha:yyyy/MM/dd}, Hora: {func.Horario:HH:mm:ss}");
    //                            Console.WriteLine($"Código: {func.FuncionId}, Sala: {listaSalas[func.SalaId].Nombre}");
    //                        }
    //                    }
    //                    else
    //                    {
    //                        throw new InvalidDateFormatException("Fecha inválida");
    //                    }
    //                    Console.WriteLine("Presione una tecla para continuar...");
    //                    Console.ReadKey();

    //                }
    //                else
    //                {
    //                    throw new ElementNotFoundException("Película no encontrada, intente nuevamente");
    //                }
    //            }

    //        }
    //        catch
    //        {
    //            throw new ParseFailedException("Código inválido, intente nuevamente");
    //        }

    //    }
    //}
//}
