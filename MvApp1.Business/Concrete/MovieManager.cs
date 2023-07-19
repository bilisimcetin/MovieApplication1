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

        public Movie UpdateMovie(Movie movie)
        {
            return _movieRepository.UpdateMovie(movie);
        }


        public void UpdateIsWatched(int movieId, bool isWatched)
        {
            Movie movie = _movieRepository.GetMovieById(movieId);
            if (movie != null)
            {
                movie.IsWatched = isWatched;
                _movieRepository.UpdateMovie(movie);
            }
            else
            {
                throw new Exception("Movie not found.");
            }
        }

        public Movie AddMovieToCategory(int movieId, int categoryId)
        {
            Movie movie = _movieRepository.GetMovieById(movieId);
            Category category = _categoryRepository.GetCategoryById(categoryId);

            if (movie != null && category != null)
            {
                movie.Categories.Add(category);
                _movieRepository.UpdateMovie(movie);
            }
            else
            {
                throw new Exception("Movie or category not found.");
            }

            return movie;
        }



    }
}
