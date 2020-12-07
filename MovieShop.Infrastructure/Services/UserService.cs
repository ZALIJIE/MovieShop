using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MovieShop.Core.Entities;
using MovieShop.Core.Helpers;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;

        public UserService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
        }
        public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel)
        {
            //step1: check whether this user already exists in the db
            var dbuser =await _userRepository.GetUserByEmail(requestModel.Email);
            if (dbuser != null)
            {
                //we already have this user(email) in our db
                throw new Exception("User already registered, Please try to login");
            }

            //step 2: create a random unique salt, always use industry hashing algorithm
            var salt = _cryptoService.CreateSalt();


            //step 3: We hash the password with the salt created by the above step
            var hashedPassword = _cryptoService.HashPassword(requestModel.Password,salt);

            //step 4: create user object so that we can save it to User Table
            var user = new User
            {
                Email = requestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
            };
            //Step 5 : Save it to db
            var createdUser = await _userRepository.AddAsync(user);

            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
            return response;
        }

        public async Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultSet<User>> GetAllUsersByPagination(int pageSize = 20, int page = 0, string lastName = "")
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var model = new UserRegisterResponseModel {
                Id = user.Id,
                Email=user.Email,
                FirstName=user.FirstName,
                LastName=user.LastName
                
            };
            return model;
        }

        public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null) return null;
            var hashedpassword = _cryptoService.HashPassword(password, user.Salt);
            var isSuccess = hashedpassword == user.HashedPassword;
            var returnedModel = new UserLoginResponseModel
            {
                Id = user.Id,
                Email=user.Email,
                FirstName=user.FirstName,
                LastName=user.LastName,
                DateOfBirth=user.DateOfBirth,                
            };
            return isSuccess ? returnedModel : null;
        }

    }
}
