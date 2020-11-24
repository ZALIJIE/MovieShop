using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Infrastructure.Repositories;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            return await _dbContext.Set<Movie>().ToListAsync();
            
        }
        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            throw new NotImplementedException();
        }
    }
}
