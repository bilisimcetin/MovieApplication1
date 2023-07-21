using MvApp1.DataAccess.Abstract;
using MvApp1.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieApplication.DataAccess.Abstract;
using MovieApplication.DataAccess.Concrete;

namespace MvApp1.DataAccess.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieContext;
        private readonly ICategoryRepository _categoryRepository;


        public MovieRepository(MovieDbContext movieContext, ICategoryRepository categoryRepository)
        {
            _movieContext = movieContext;
            _categoryRepository = categoryRepository;

        }
        public Movie CreateMovie(Movie movie)
        {

            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return movie;

        }

        public void DeleteMovie(int id)
        {
            
                var deletedMovie = GetMovieById(id);
            _movieContext.Movies.Remove(deletedMovie);
            _movieContext.SaveChanges();
            
        }

        public List<Movie> GetAllMovies()
        {

            return _movieContext.Movies.Include(x => x.Categories).ToList();
            
        }

        public Movie GetMovieById(int id)
        {
            
                return _movieContext.Movies.Find(id);
            
        }

        public Movie UpdateMovie(Movie movie)
        {

            _movieContext.Entry(movie).State = EntityState.Modified;
            _movieContext.SaveChanges();
            return movie;
        }

        public void UpdateIsWatched(int movieId, bool isWatched)
        {
            var movie = _movieContext.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie != null)
            {
                if (isWatched)
                {
                    movie.IsWatched = true;
                }
                else
                {
                    movie.IsWatched = false;
                }

                _movieContext.SaveChanges();
            }
        }

        

    }
}
