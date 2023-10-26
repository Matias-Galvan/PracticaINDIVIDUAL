using Aplication.ErrorHandler;
using Aplication.Interfaces;
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
        private readonly IPeliculaService _peliculaService;

        public PeliculaController(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
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
                var result = await _peliculaService.GetPeliculaById(id);
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
            //var result = await _peliculaService.GetPeliculaById(id);
            //return new JsonResult(result);
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
            var peliculaEditar = new PeliculaDTO
            {
                Titulo = request.Titulo,
                Poster = request.Poster,
                Trailer = request.Trailer,
                Sinopsis = request.Sinopsis,
                generoId = request.generoId
            };
            try
            {
                var result = await _peliculaService.actualizarPelicula(id, peliculaEditar);
                return new JsonResult(result);
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

            //var result = await _peliculaService.actualizarPelicula(id, peliculaEditar);
            //return new JsonResult(result);
        }

    }
}