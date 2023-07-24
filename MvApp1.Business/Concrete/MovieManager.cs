using Microsoft.EntityFrameworkCore;
using MovieApplication.DataAccess.Abstract;
using MovieApplication.DataAccess.Concrete;
using MovieApplication.Entities;
//using MvApp1.Entities;
using MvApp1.Business.Abstract;
using MvApp1.DataAccess.Abstract;
using MvApp1.Entities;

namespace MvApp1.Business.Concrete
{
    public class MovieManager : IMovieService
    {

        private readonly IMovieRepository _movieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public MovieManager(IMovieRepository movieRepository , ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
        }
        public Movie CreateMovie(MovieCreateDTO movieCreateDTO)
        {
            var movie = new Movie
            {
                Name = movieCreateDTO.Name,
                Description = movieCreateDTO.Description,
                IsWatched = movieCreateDTO.IsWatched
            };

            foreach (var categoryId in movieCreateDTO.CategoryIds)
            {
                var category = _categoryRepository.GetCategoryById(categoryId);
                if (category != null)
                {
                    movie.Categories.Add(category);
                }
            }

            _movieRepository.CreateMovie(movie);
            return movie;
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id)


        {

            if (id > 0)
            {

                return _movieRepository.GetMovieById(id);
            }

            throw new Exception("id can not be less than 1");
        }

        public Movie UpdateMovie(int id, MovieCreateDTO updatedMovie)
        {
            var existingMovie = _movieRepository.GetMovieById(id);
            if (existingMovie == null)
            {
                throw new Exception("Movie not found.");
            }

            existingMovie.Name = updatedMovie.Name;
            existingMovie.Description = updatedMovie.Description;
            existingMovie.IsWatched = updatedMovie.IsWatched;

            _movieRepository.UpdateMovie(existingMovie);
            return existingMovie;
        }


        public void MarkAsWatched(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                // Burada gerekli hata işlemleri yapılabilir, örneğin bir Exception fırlatılabilir.
                throw new ArgumentException("Movie not found.");
            }

            _movieRepository.UpdateIsWatched(id, true);
        }


    }
}
