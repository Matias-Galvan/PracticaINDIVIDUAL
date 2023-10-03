//using Aplication.ErrorHandler;
//using Aplication.Services;
//using Aplication.UseCase.Services;
//using Data.Persistence;
//using Domain.Entities;


//namespace PracticaINDIVIDUAL.Controller
//{
//    public class UserConsole
//    {
//        public static void CrearModelo(CineDBContext context)
//        {
//            Console.Clear();
//            var ServiceFuncion = new FuncionService(context);
//            List<Pelicula> PeliculaFuncion = new PeliculaService(context).GetAllPelicula();
//            var SalaFuncion = new SalaService(context).GetAll();
//            var DiaFuncion = ValidarFecha();
//            var HoraFuncion = ValidarHora();
//            Funcion funcion = new()
//            {
//                PeliculaId = CrearSolicitudPelicula(PeliculaFuncion).PeliculaId,
//                SalaId = CrearSolicitudSala(SalaFuncion).SalaId,
//                Fecha = DiaFuncion,
//                Horario = HoraFuncion
//            };
//            try
//            {
//                ServiceFuncion.CrearFuncion(funcion);
//                Console.WriteLine("La función fue creada correctamente");
//                Console.WriteLine($"Resumen de función " +
//                    $"Título: {new PeliculaService(context).getPelicula(funcion.PeliculaId).Titulo}" +
//                    $"Sala: {new SalaService(context).getSala(funcion.SalaId).Nombre}" +
//                    $"Fecha: {funcion.Fecha}" +
//                    $"Hora: {funcion.Horario}");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }


//        }
//        public static Funcion CrearSolicitudPelicula(List<Pelicula> listaPeliculas)
//        {
//            var funcion = new Funcion();
//            Console.Clear();
//            Console.WriteLine("*********************************************************");
//            Console.WriteLine("*              Películas disponibles:                   *");
//            Console.WriteLine("*********************************************************");
//            foreach (var pelicula in listaPeliculas)
//            {
//                Console.WriteLine($"Código: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
//            }
//            while (true)
//            {
//                try
//                {
//                    Console.WriteLine("Seleccione el código de la película");
//                    if (int.TryParse(Console.ReadLine(), out int peliculaId))
//                    {
//                        if (listaPeliculas.Any(peli => peli.PeliculaId == peliculaId))
//                        {
//                            Console.WriteLine("Película seleccionada correctamente");
//                            funcion.PeliculaId = peliculaId;
//                            Console.WriteLine("Presione una tecla para continuar...");
//                            Console.ReadKey();
//                            return funcion;
//                        }
//                        else
//                        {
//                            throw new ElementNotFoundException("Película no encontrada, intente nuevamente");
//                        }
//                    }

//                }
//                catch
//                {
//                    throw new ParseFailedException("Código inválido, intente nuevamente");
//                }

//            }

//        }
//        public static Funcion CrearSolicitudSala(List<Sala> salas)
//        {
//            var funcion = new Funcion();
//            Console.Clear();
//            Console.WriteLine("*********************************************************");
//            Console.WriteLine("*                Salas disponibles:                     *");
//            Console.WriteLine("*********************************************************");
//            foreach (var sala in salas)
//            {
//                Console.WriteLine($"Código: {sala.SalaId}, Nombre de sala: {sala.Nombre}, Capacidad: {sala.Capacidad}");
//            }
//            while (true)
//            {
//                try
//                {
//                    Console.WriteLine("Seleccione el código de la sala");
//                    if (int.TryParse(Console.ReadLine(), out int salaId))
//                    {
//                        if (salas.Any(sala => sala.SalaId == salaId))
//                        {
//                            Console.WriteLine("Sala seleccionada correctamente");
//                            funcion.SalaId = salaId;
//                            Console.WriteLine("Presione una tecla para continuar...");
//                            Console.ReadKey();
//                            return funcion;
//                        }
//                        else
//                        {
//                            throw new ElementNotFoundException("Sala no encontrada, intente nuevamente");
//                        }
//                    }

//                }
//                catch
//                {
//                    throw new ParseFailedException("Código inválido, intente nuevamente");
//                }

//            }

//        }
//        public static DateTime ValidarFecha()
//        {
//            DateTime fecha;

//            while (true)
//            {
//                Console.WriteLine("Ingrese la fecha en formato YYYY-mm-dd:");
//                try
//                {
//                    if (DateTime.TryParse(Console.ReadLine(), out fecha))
//                        break;
//                    else
//                        throw new Exception("Fecha no válida. Ingrese una fecha en el formato YYYY-MM-DD.");
//                }
//                catch
//                {
//                    throw new InvalidDateFormatException("Fecha inválida, intente nuevamente");
//                }
//            }

//            return fecha;
//        }
//        public static DateTime ValidarHora()
//        {
//            DateTime hora;

//            while (true)
//            {
//                Console.WriteLine("Ingrese la hora en formato HH-MM-SS:");
//                try
//                {
//                    if (DateTime.TryParse(Console.ReadLine(), out hora))
//                        break;
//                    else
//                        throw new Exception("Hora no válida. Ingrese una fecha en el formato HH-MM-SS.");
//                }
//                catch
//                {
//                    throw new InvalidDateFormatException("Hora inválida, intente nuevamente");
//                }
//            }

//            return hora;
//        }
//        public static void BuscarFuncionPelicula(CineDBContext context)
//        {
//            var BuscarFuncion = new FuncionService(context);
//            var funcion = new Funcion();
//            var ListaPeliculas = new PeliculaService(context).GetAllPelicula();
//            var ListaSalas = new SalaService(context).GetAll();
//            Console.Clear();
//            Console.WriteLine("*********************************************************");
//            Console.WriteLine("*              Películas disponibles:                   *");
//            Console.WriteLine("*********************************************************");
//            foreach (var pelicula in ListaPeliculas)
//            {
//                Console.WriteLine($"Código: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
//                Console.WriteLine($"Sinopsis: {pelicula.Sinopsis}");
//            }
//            try
//            {
//                Console.WriteLine("Seleccione el código de la película");
//                if (int.TryParse(Console.ReadLine(), out int peliculaId))
//                {
//                    if (ListaPeliculas.Any(peli => peli.PeliculaId == peliculaId))
//                    {
//                        Console.WriteLine("Película seleccionada correctamente");
//                        funcion.PeliculaId = peliculaId;
//                        List<Funcion> ListadoFunciones = BuscarFuncion.GetFuncionPelicula(funcion.PeliculaId);
//                        foreach (var func in ListadoFunciones)
//                        {
//                            Console.WriteLine($"Película: {ListaPeliculas[peliculaId].Titulo}");
//                            Console.WriteLine($"Código: {func.FuncionId}, Sala: {ListaSalas[func.SalaId].Nombre}, Fecha: {func.Fecha:yyyy/MM/dd} , Hora: {func.Horario:HH:mm:ss}");
//                        }
//                        Console.WriteLine("Presione una tecla para continuar...");
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


//        }
//        public static void BuscarFuncionDia(CineDBContext context)
//        {
//            var BuscarFuncion = new FuncionService(context);
//            var ListadoPeliculas = new PeliculaService(context).GetAllPelicula();
//            var ListadoSalas = new SalaService(context).GetAll();
//            Console.WriteLine("Ingrese la fecha a buscar en formato (YYYY/MM/DD)");
//            string FechaBuscar = Console.ReadLine();
//            DateTime FechaFiltro;
//            if (!string.IsNullOrEmpty(FechaBuscar) && DateTime.TryParse(FechaBuscar, out DateTime FechaSeleccionada))
//            {
//                FechaFiltro = FechaSeleccionada;
//                List<Funcion> ListadoFunciones = BuscarFuncion.GetFuncionDia(FechaFiltro);
//                foreach (var func in ListadoFunciones)
//                {
//                    Console.WriteLine($"Fecha: {func.Fecha:yyyy/MM/dd}, Hora: {func.Horario:HH:mm:ss}");
//                    Console.WriteLine($"Código: {func.FuncionId}, Sala: {ListadoSalas[func.SalaId].Nombre}, Película: {ListadoPeliculas[func.PeliculaId].Titulo}");
//                }
//                Console.WriteLine("Presione una tecla para continuar...");
//                Console.ReadKey();
//            }
//            else
//            {
//                throw new InvalidDateFormatException("Fecha inválida");
//            }
//        }
//        public static void BuscarFuncionDiaPelicula(CineDBContext context)
//        {
//            var BuscarFuncion = new FuncionService(context);
//            var funcion = new Funcion();
//            var ListaPeliculas = new PeliculaService(context).GetAllPelicula();
//            var ListaSalas = new SalaService(context).GetAll();
//            Console.Clear();
//            Console.WriteLine("*********************************************************");
//            Console.WriteLine("*              Películas disponibles:                   *");
//            Console.WriteLine("*********************************************************");
//            foreach (var pelicula in ListaPeliculas)
//            {
//                Console.WriteLine($"Código: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
//                Console.WriteLine($"Sinopsis: {pelicula.Sinopsis}");
//            }
//            try
//            {
//                Console.WriteLine("Seleccione el código de la película");
//                if (int.TryParse(Console.ReadLine(), out int peliculaId))
//                {
//                    if (ListaPeliculas.Any(peli => peli.PeliculaId == peliculaId))
//                    {
//                        Console.WriteLine("Película seleccionada correctamente");
//                        funcion.PeliculaId = peliculaId;
//                        Console.WriteLine("Ingrese la fecha a buscar en formato (YYYY/MM/DD)");
//                        string fechaBuscar = Console.ReadLine();
//                        DateTime fechaFiltro;
//                        if (!string.IsNullOrEmpty(fechaBuscar) && DateTime.TryParse(fechaBuscar, out DateTime fechaSeleccionada))
//                        {
//                            fechaFiltro = fechaSeleccionada;
//                            List<Funcion> listadoFunciones = BuscarFuncion.GetFuncionPeliculaYDia(peliculaId, fechaFiltro);
//                            foreach (var func in listadoFunciones)
//                            {
//                                Console.WriteLine($"Película: {ListaPeliculas[func.PeliculaId].Titulo}, Fecha: {func.Fecha:yyyy/MM/dd}, Hora: {func.Horario:HH:mm:ss}");
//                                Console.WriteLine($"Código: {func.FuncionId}, Sala: {ListaSalas[func.SalaId].Nombre}");
//                            }
//                        }
//                        else
//                        {
//                            throw new InvalidDateFormatException("Fecha inválida");
//                        }
//                        Console.WriteLine("Presione una tecla para continuar...");
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

//        }
//    }
//}
