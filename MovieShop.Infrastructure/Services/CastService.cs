using System.Threading.Tasks;
using MovieShop.Core.Models;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);

            var ReturnedCast = new CastDetailsResponseModel { 
                Id=cast.Id,
                Name=cast.Name,
                Gender=cast.Gender,
                TmdbUrl=cast.TmdbUrl,
                ProfilePath=cast.ProfilePath
            };
            return ReturnedCast;
        }


    }
}
