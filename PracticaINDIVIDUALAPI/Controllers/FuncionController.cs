using Application.DTO;
using Application.ErrorHandler;
using Application.Filters;
using Application.Interfaces.Funciones;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaINDIVIDUAL.API.Controllers
{
    [Route("api/v1/Funcion")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IFuncionService _funcionService;

        public FuncionController(IFuncionService funcionService)
        {
            _funcionService = funcionService;
        }

        //GET: api/<ValuesController> query parameters optionally
        [HttpGet]
        [ProducesResponseType(typeof(FuncionDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 400)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 500)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 404)]
        public async Task<IActionResult> GetAll(string? fecha, string? titulo, int? generoId)
        {
            var filtros = new FuncionFilters
            {
                Titulo = titulo,
                Fecha = fecha,
                Genero = generoId
            };
            try
            {
                var result = await _funcionService.ListarFunciones(filtros);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHttp
                {
                    message = e.Message,

                });
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FuncionDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 400)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 500)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 404)]
        public async Task<IActionResult> GetByFuncion(int id)
        {
            try
            {
                var result = await _funcionService.ObtenerFuncionPorId(id);
                return new JsonResult(result) { StatusCode = 200};
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHttp
                {
                    message = e.Message,

                });
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
        }

        //POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(typeof(FuncionDTO), 201)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 400)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 500)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 409)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 404)]
        public async Task<IActionResult> CrearFuncion(FuncionDTO request)
        {
            var funcion = new Funcion
            {
                PeliculaId = request.Pelicula,
                SalaId = request.Sala,
                Fecha = request.Fecha,
                
            };
            if (TimeSpan.TryParse(request.Horario, out var horario))
            {
                funcion.Horario = horario;
            }
            else
            {
                return BadRequest(new ErrorMessageHttp
                {
                    message = "El formato de la hora es incorrecto",
                });
            }
            try
            {
                var result = await _funcionService.CrearFuncion(funcion);
                return new JsonResult(result) {StatusCode = 201};
            }
            catch (InvalidDateFormatException e)
            {
                return BadRequest(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
            catch (InvalidTimeFormatException e)
            {
                return BadRequest(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
            catch (Exception e)
            {
                return Conflict(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
            
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FuncionDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 400)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 500)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 409)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 404)]
        public async Task<IActionResult> EliminarFuncion(int id)
        {
            try
            {
                var result = await _funcionService.EliminarFuncion(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
            catch (InvalidOperationException e)
            {
                return Conflict(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
            catch (System.IO.InvalidDataException e)
            {
                return BadRequest(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
            catch (Exception e)
            {
                return Conflict(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }

        }
        //GET api/<ValuesController>/5/tickets
        [HttpGet("{id}/tickets")]
        [ProducesResponseType(typeof(TicketDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 400)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 500)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 404)]
        public async Task<IActionResult> GetTicketsByFuncion(int id)
        {
            try
            {
                var result = await _funcionService.ObtenerTicketsFuncionPorId(id);
                return new JsonResult(result);
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHttp
                {
                    message = e.Message,

                });
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }

        }
        //POST api/<ValuesController>/5/tickets
        [HttpPost("{id}/tickets")]
        [ProducesResponseType(typeof(TicketDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 400)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 500)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 409)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 404)]
        public async Task<IActionResult> PostTicketsByFuncion(int id, TicketDTO request)
        {
            try
            {
                var result = await _funcionService.CrearTicketFuncion(id, request);
                return new JsonResult(result);
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
            catch (InvalidOperationException e)
            {
                return Conflict(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }
            catch (Exception e)
            {
                return Conflict(new ErrorMessageHttp
                {
                    message = e.Message,
                });
            }

        }
    }
}