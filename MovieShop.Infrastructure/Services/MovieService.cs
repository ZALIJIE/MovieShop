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
using AutoMapper;

namespace MovieShop.Infrastructure.Services
{

    public class MovieService :IMovieService
    {

        private readonly IMovieRepository _movieRepository;
        private readonly IAsyncRepository<MovieGenre> _movieGenresRepository;
        private readonly IPurchaseRepository _purchaseRepository;

        //constructor injection
        public MovieService(IMovieRepository MovieRepository, IAsyncRepository<MovieGenre> MovieGenresRepository, IPurchaseRepository purchaseRepository)
        {
            //repository = new MovieRepository(new MovieShopDbContext(null));
            _movieRepository = MovieRepository;
            _movieGenresRepository = MovieGenresRepository;
            _purchaseRepository = purchaseRepository;
        }

        public Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }


        public async Task<int> GetMoviesCount(string title = "")
        {
            if (string.IsNullOrEmpty(title)) return await _movieRepository.GetCountAsync();
            return await _movieRepository.GetCountAsync(m => m.Title.Contains(title));
        }


        public async Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies()
        { 
            var movies = await _movieRepository.GetHighestGrossingMovies();
            // Map our Movie Entity to MovieResponseModel
            var movieResponseModel = new List<MovieResponseModel>();
            foreach (var movie in movies) 
            {
                movieResponseModel.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    //ReleaseDate = movie.ReleaseDate.Value,
                    Title = movie.Title
                });
            }
            return movieResponseModel;
        }

        public async Task<PagedResultSet<MovieResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 0, string title = "")
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0)
        {
            //var totalPurchases = await _purchaseRepository.GetCountAsync();
            //var purchases = await _purchaseRepository.GetAllPurchases(pageSize, page);

            //var data = _mapper.Map<List<MovieResponseModel>>(purchases);
            //var purchasedMovies = new PagedResultSet<MovieResponseModel>(data, page, pageSize, totalPurchases);
            //return purchasedMovies;
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

        public async Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest)
        {
            var movie = new Movie { 
                Id=movieCreateRequest.Id,
                Title= movieCreateRequest.Title,
                Overview= movieCreateRequest.Overview,
                Tagline= movieCreateRequest.Tagline,
                Revenue= movieCreateRequest.Revenue,
                Budget= movieCreateRequest.Budget,
                ImdbUrl= movieCreateRequest.ImdbUrl,
                TmdbUrl= movieCreateRequest.TmdbUrl,
                PosterUrl= movieCreateRequest.PosterUrl,
                BackdropUrl= movieCreateRequest.BackdropUrl,
                OriginalLanguage= movieCreateRequest.OriginalLanguage,
                ReleaseDate= movieCreateRequest.ReleaseDate,
                RunTime= movieCreateRequest.RunTime,
                Price= movieCreateRequest.Price,
                
            };
            
            var CreatedMovie = await _movieRepository.AddAsync(movie);
            foreach (var genre in movieCreateRequest.Genres)
            {
                var MovieGenre = new MovieGenre {MovieId=CreatedMovie.Id,GenreId=genre.Id };
                await _movieGenresRepository.AddAsync(MovieGenre);
            }
            var ReturnedModel = new MovieDetailsResponseModel {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Revenue = movie.Revenue,
                Budget = movie.Budget,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,
            };
            return ReturnedModel;
        }

        public async Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest)
        {
            var movie = new Movie
            {
                Id = movieCreateRequest.Id,
                Title = movieCreateRequest.Title,
                Overview = movieCreateRequest.Overview,
                Tagline = movieCreateRequest.Tagline,
                Revenue = movieCreateRequest.Revenue,
                Budget = movieCreateRequest.Budget,
                ImdbUrl = movieCreateRequest.ImdbUrl,
                TmdbUrl = movieCreateRequest.TmdbUrl,
                PosterUrl = movieCreateRequest.PosterUrl,
                BackdropUrl = movieCreateRequest.BackdropUrl,
                OriginalLanguage = movieCreateRequest.OriginalLanguage,
                ReleaseDate = movieCreateRequest.ReleaseDate,
                RunTime = movieCreateRequest.RunTime,
                Price = movieCreateRequest.Price,

            }; var UpdatedMovie =await _movieRepository.UpdateAsync(movie);
            foreach(var genre in movieCreateRequest.Genres)
            {
                var MovieGenre = new MovieGenre { MovieId = UpdatedMovie.Id, GenreId = genre.Id };
                await _movieGenresRepository.UpdateAsync(MovieGenre);
            }
            var ReturnedModel = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Revenue = movie.Revenue,
                Budget = movie.Budget,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,
            };
            return ReturnedModel;
        }
    }


}
