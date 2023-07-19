using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvApp1.DataAccess.Abstract
{
    public interface IMovieRepository
    {

        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);

        Movie CreateMovie(Movie movie );

        Movie UpdateMovie(Movie movie);

        Movie AddMovieToCategory(int movieId, int categoryId);
        void UpdateIsWatched(int movieId, bool isWatched);
        void DeleteMovie(int id);
       
    }
}
