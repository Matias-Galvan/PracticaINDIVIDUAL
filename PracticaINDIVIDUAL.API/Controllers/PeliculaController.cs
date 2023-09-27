using Aplication.Interfaces;
using Application.DTO;
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
        public async Task<IActionResult> GetPeliculaById(int id)
        {
            var result = await _peliculaService.GetPeliculaById(id);
            return new JsonResult(result);
        }


        // PUT api/<PeliculaController>/5
        [HttpPut("{id}")]
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
            var result = await _peliculaService.actualizarPelicula(id, peliculaEditar);
            return new JsonResult(result);
        }

    }
}
