using MovieApplication.DataAccess.Abstract;
using MovieApplication.DataAccess.Concrete;
using MovieApplication.Entities;
using MovieApplicationBusiness.Abstract;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationBusiness.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            return _userRepository.Authenticate(username, password);
        }

        public AddUserDto CreateUser(AddUserDto addUserDto)
        {
            var user = new User
            {
                Username = addUserDto.Username,
                Password= addUserDto.Password,
                FullName= addUserDto.FullName,
            };
            _userRepository.CreateUser(user);
            return new AddUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                FullName = user.FullName,




            };
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);

        }


        public List<Movie> GetWatchedMovies(int userId)
        {
            // İlgili kullanıcının izlediği filmleri getir
            return _userRepository.GetWatchedMovies(userId);
        }

        public void MovieAsWatched(int userId, int movieId)
        {
            _userRepository.MovieAsWatched(userId, movieId);
        }

        public User UpdateUser(int id, User user)
        {
            var existingUser = _userRepository.GetUserById(id);
            if (existingUser == null)
            {
           
                throw new Exception("Not found user.");
            }

            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.FullName = user.FullName;
           

            _userRepository.UpdateUser(existingUser);
            return user;
        }


    }
    


}
