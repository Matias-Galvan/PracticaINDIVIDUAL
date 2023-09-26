using Aplication.Interfaces;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaINDIVIDUAL.API.Controllers
{
    [Route("api/Funciones")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IFuncionService _funcionService;

        public FuncionController(IFuncionService funcionService)
        {
            _funcionService = funcionService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> crearFuncion(FuncionDTO funcion)
        {
            var result = await _funcionService.agregarFuncion(funcion);
            return new JsonResult(result);
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
