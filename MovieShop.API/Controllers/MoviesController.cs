using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    //attribute based routine
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;


        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        //api/movies/toprevenue
        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetHighestGrossingMovies();

            //Call our service and call the method
            //var Movie=_ MovieService.GetTopMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }

                return Ok(movies);

        }

        [HttpGet]
        [Route("{id:int}", Name ="GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMovies([FromQuery] int pageSize = 30, [FromQuery] int page = 1,
            string title = "")
        {
            var movies = await _movieService.GetMoviesByPagination(pageSize, page, title);
            return Ok(movies);
        }

        [HttpGet]
        [Route("genres/{genreid:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreid)
        {
            var movies =await  _movieService.GetMoviesByGenre(genreid);
            return Ok(movies);
        }

    }
}
