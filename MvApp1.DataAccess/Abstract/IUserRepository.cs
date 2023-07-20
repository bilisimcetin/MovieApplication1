using MovieApplication.Entities;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.DataAccess.Abstract
{
   public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        User CreateUser(User user);
        User Authenticate(string username, string password);
        User UpdateUser(User user);
        User GetUserByUsernameAndPassword(string username, string password);
        List<Movie> GetWatchedMovies(int userId);
        void MovieAsWatched(int userId, int movieId);
    }
}
