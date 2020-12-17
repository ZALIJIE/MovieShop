using Microsoft.Extensions.Caching.Memory;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class GenreService:IGenreService
    {
        private readonly IAsyncRepository<Genre> _genreRepository;
        private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromDays(30);
        private static readonly string _genresKey = "genres";
        private readonly IMemoryCache _cache;

        public GenreService(IAsyncRepository<Genre> genreRepository, IMemoryCache cache)
        {
            _genreRepository = genreRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = await _cache.GetOrCreateAsync(_genresKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _genreRepository.ListAllAsync();
            });
            return genres.OrderBy(g => g.Name);
        }
    }
}
