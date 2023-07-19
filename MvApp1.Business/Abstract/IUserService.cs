using MovieApplication.Entities;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationBusiness.Abstract
{
 public interface IUserService
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        User CreateUser(User user);
        User Authenticate(string username, string password);
        User UpdateUser(int id, User user);
        List<Movie> GetWatchedMovies(int userId);
        void MovieAsWatched(int userId, int movieId);

    }
}
