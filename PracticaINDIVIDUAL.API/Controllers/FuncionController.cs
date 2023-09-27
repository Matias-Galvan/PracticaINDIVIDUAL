using Aplication.Interfaces;
using Application.DTO;
using Application.Filters;
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
        public async Task<IActionResult> GetAll(string? titulo, string? fecha, int? generoId)
        {
            var filtros = new FuncionFilters
            {
                Titulo = titulo,
                Fecha = fecha,
                Genero = generoId
            };
            var result = await _funcionService.listarFunciones(filtros);
            return new JsonResult(result);        
                       
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByFuncion(int id)
        {
            var result = await _funcionService.obtenerFuncionPorId(id);
            return new JsonResult(result);
        }

        //POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> crearFuncion(FuncionDTO request)
        {
            var funcion = new Funcion 
            { 
                Fecha = request.Fecha, 
                Horario = TimeSpan.Parse(request.Horario), 
                PeliculaId = request.PeliculaId, 
                SalaId = request.SalaId 
            };   
            var result = await _funcionService.crearFuncion(funcion);
            
            return new JsonResult(result);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> eliminarFuncion(int id)
        {
            var result = await _funcionService.eliminarFuncion(id);
            return new JsonResult(result);
        }
        //GET api/<ValuesController>/5/tickets
        [HttpGet("{id}/tickets")]
        public async Task<IActionResult> GetTicketsByFuncion(int id)
        {
            var result = await _funcionService.obtenerTicketsFuncionPorId(id);
            return new JsonResult(result);
        }
        //POST api/<ValuesController>/5/tickets
        [HttpPost("{id}/tickets")]
        public async Task<IActionResult> PostTicketsByFuncion(int id, TicketDTO request)
        {
            var result = await _funcionService.crearTicketFuncion(id, request);
            return new JsonResult(result);
        }
    }
}
