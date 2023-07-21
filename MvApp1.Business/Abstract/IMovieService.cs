using MovieApplication.Entities;
using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvApp1.Business.Abstract
{
  public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);

        Movie CreateMovie(MovieCreateDTO movieCreateDTO);

        Movie UpdateMovie(int id, MovieCreateDTO updatedMovie);

        
        void UpdateIsWatched(int movieId, bool isWatched);
        void DeleteMovie(int id);
    }
}
