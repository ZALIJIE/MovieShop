using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Infrastructure.Repositories;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Data;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Helpers;
using MovieShop.Core.Models.Response;
using MovieShop.Core.Entities;
using MovieShop.Core.Models;

namespace MovieShop.Infrastructure.Services
{

    public class MovieService :IMovieService
    {

        private readonly IMovieRepository _repository;


        //constructor injection
        public MovieService(IMovieRepository repository)
        {
            //repository = new MovieRepository(new MovieShopDbContext(null));
            _repository = repository;


        }

        public Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }


        public async Task<int> GetMoviesCount(string title = "")
        {
            if (string.IsNullOrEmpty(title)) return await _repository.GetCountAsync();
            return await _repository.GetCountAsync(m => m.Title.Contains(title));
        }


        public async Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies()
        { 
            var movies = await _repository.GetHighestGrossingMovies();
            // Map our Movie Entity to MovieResponseModel
            var movieResponseModel = new List<MovieResponseModel>();
            foreach (var movie in movies) 
            {
                movieResponseModel.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.Value,
                    Title = movie.Title
                });
            }
            return movieResponseModel;
        }

        public Task<PagedResultSet<MovieResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 0, string title = "")
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<MovieResponseModel>> GetAllPurchasesByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }
    }


}
