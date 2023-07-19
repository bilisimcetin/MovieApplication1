using Microsoft.EntityFrameworkCore;
using MovieApplication.DataAccess.Abstract;
using MovieApplication.Entities;
using MvApp1.DataAccess;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _movieContext;
        public UserRepository(MovieDbContext movieContext)
        {
            _movieContext = movieContext;
            

        }
        public User Authenticate(string username, string password)
        {
            return _movieContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User CreateUser(User user)
        {
           
            _movieContext.Users.Add(user);
            _movieContext.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _movieContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _movieContext.Users.FirstOrDefault(u => u.Id == id);
        }

            public List<Movie> GetWatchedMovies(int userId)
        {
            {
                var user = _movieContext.Users
                    .Include(u => u.WatchedMovies)
                    .ThenInclude(wm => wm.Movie)
                    .FirstOrDefault(u => u.Id == userId);

                return user?.WatchedMovies.Select(wm => wm.Movie).ToList();
            }
        }

        public void MovieAsWatched(int userId, int movieId)
        {
            var user = _movieContext.Users
            .Include(u => u.WatchedMovies)
            .FirstOrDefault(u => u.Id == userId);

            var movie = _movieContext.Movies.FirstOrDefault(m => m.Id == movieId);

            if (user != null && movie != null)
            {
                if (!user.WatchedMovies.Any(wm => wm.MovieId == movieId))
                {
                    var watchedMovie = new WatchedMovie
                    {
                        MovieId = movieId,
                        UserId = userId
                    };

                    user.WatchedMovies.Add(watchedMovie);
                    _movieContext.SaveChanges();
                }
            }
        }

        public User UpdateUser(User user)
        {
            // Kullanıcıyı güncelle
            _movieContext.Users.Update(user);
            _movieContext.SaveChanges();
            return user;
        }
    }
}
