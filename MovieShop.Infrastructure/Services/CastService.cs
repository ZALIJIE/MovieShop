using System.Collections.Generic;
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

        public async Task<IEnumerable<CastResponseModel>> GetCastByMovieId(int id)
        {
            var casts = await _castRepository.GetCastsByMovieId(id);
            var responses = new List<CastResponseModel>();
            foreach(var cast in casts)
            {
                //response.Add(new CastResponseModel { 
                //    CastId=cast.Id,
                //    ProfileUrl=cast.ProfilePath,
                //    CastName=cast.Name,
                //    Character=
                //});
                var response = new CastResponseModel
                {
                    CastId = cast.Id,
                    ProfileUrl = cast.ProfilePath,
                    CastName = cast.Name,
                };
                responses.Add(response);
                
            }
            return responses;

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
