using Application.DTO;
using Application.ErrorHandler;
using Application.Interfaces.Peliculas;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaINDIVIDUAL.API.Controllers
{
    [Route("api/v1/Pelicula")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _PeliculaService;

        public PeliculaController(IPeliculaService PeliculaService)
        {
            _PeliculaService = PeliculaService;
        }

        // GET api/<PeliculaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PeliculaDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 404)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 400)]
        public async Task<IActionResult> GetPeliculaById(int id)
        {
            try
            {
                var result = await _PeliculaService.GetPeliculaById(id);
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


        // PUT api/<PeliculaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PeliculaDTO), 200)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 404)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 400)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 500)]
        [ProducesResponseType(typeof(ErrorMessageHttp), 409)]
        public async Task<IActionResult> UpdatePelicula(int id, PeliculaDTO request)
        {
            var PeliculaEditar = new PeliculaDTO
            {
                Titulo = request.Titulo,
                Poster = request.Poster,
                Trailer = request.Trailer,
                Sinopsis = request.Sinopsis,
                genero = request.genero
            };
            try
            {
                var result = await _PeliculaService.ActualizarPelicula(id, PeliculaEditar);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ElementNotFoundException e)
            {
                return NotFound(new ErrorMessageHttp
                {
                    message = e.Message,

                });
            }
            catch (ElementAlreadyExistException e)
            {
                return Conflict(new ErrorMessageHttp
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

    }
}