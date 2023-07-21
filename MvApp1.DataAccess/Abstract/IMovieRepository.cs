﻿using MvApp1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        
        void UpdateIsWatched(int movieId, bool isWatched);
        void DeleteMovie(int id);
       
    }
}
