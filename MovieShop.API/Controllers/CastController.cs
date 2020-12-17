using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCastDetails(int id)
        {
            var cast = await _castService.GetCastDetailsWithMovies(id);
            return Ok(cast);
        }

        //[HttpGet]
        //[Route("movies/{id:int}")]
        //public async Task<IActionResult> GetCastsByMovieId(int id)
        //{
        //    var casts = await _castService.GetCastByMovieId(id);
        //    return Ok(casts);
        //}

    }
}
