using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Infrastructure.Repositories;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieShop.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        protected readonly MovieShopDbContext _dbContext;

        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            //var topRatedMovie = await _dbContext.Reviews.Include(r => r.Movie)
            //                                        .GroupBy(r => new
            //                                        {
            //                                            Id = r.MovieId,
            //                                            r.Movie.PosterUrl,
            //                                            r.Movie.Title,
            //                                            r.Movie.ReleaseDate
            //                                        })
            //                                        .OrderByDescending(g => g.Average(m => m.Rating))
            //                                        .Select(m => new Movie
            //                                        {
            //                                            Id = m.Key.Id,
            //                                            PosterUrl = m.Key.PosterUrl,
            //                                            Title = m.Key.Title,
            //                                            ReleaseDate = m.Key.ReleaseDate,
            //                                            Rating = m.Average(x => x.Rating)
            //                                        })
            //                                        .Take(50)
            //                                        .ToListAsync();
            var topRatedMovie=await  _dbContext.Reviews.Include(r => r.Movie)
                .GroupBy(r => new {
                    r.MovieId,
                    r.Movie.PosterUrl,
                    r.Movie.Title,
                    r.Movie.ReleaseDate
                })
                .OrderByDescending(g => g.Average(m=>m.Rating))
                .Select(m => new Movie { 
                    Id=m.Key.MovieId,
                    PosterUrl=m.Key.PosterUrl,
                    Title=m.Key.Title,
                    ReleaseDate=m.Key.ReleaseDate,
                    Rating=m.Average(x=>x.Rating)
                })
                .Take(50)
                .ToListAsync();
            return topRatedMovie;

        }
        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            var movies = await _dbContext.MovieGenres.Where(g => g.GenreId == genreId).Include(mg => mg.Movie)
                                         .Select(m => m.Movie)
                                         .ToListAsync();
            return movies;
        }
        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(50).ToListAsync();

            return movies;
            //skip and top
            //offset 10 and fetch 50 next rows
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies
                                        .Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.MovieGenres)
                                        .ThenInclude(m => m.Genre)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return null;
            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
                                              .AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0) movie.Rating = movieRating;

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetHighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(50).ToListAsync();

            return movies;
        }
    }
}
