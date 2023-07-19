using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvApp1.Entities;
using MvApp1.Business.Abstract;
using MvApp1.Business.Concrete;
using System.Text.Json.Serialization;
using MovieApplication.DataAccess.Abstract;
using MovieApplication.Entities;

namespace MvApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private IMovieService _movieService;
        private ICategoryRepository _categoryRepository;
        public MovieController(IMovieService movieService , ICategoryRepository categoryRepository)
        {
            _movieService = movieService;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public List<Movie> Get()

        { return _movieService.GetAllMovies(); }

        [HttpGet("{id}")]
        public Movie Get(int id)

        { return _movieService.GetMovieById(id); }

        
        [HttpPost]

        public  IActionResult CreateMovie([FromBody] MovieCreateDTO movieCreateDTO) 
        {
            try
        {
                _movieService.CreateMovie(movieCreateDTO);
                return Ok("Film added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public Movie Put([FromBody]Movie movie)
        {

            return _movieService.UpdateMovie(movie);
        }

        [HttpDelete("{id}")]

        public void Delete(int id) 
        {

            _movieService.DeleteMovie(id);
        }

        [HttpPut("{id}/iswatched")]
        public IActionResult UpdateIsWatched(int id, bool isWatched)
        {
            try
            {
                _movieService.UpdateIsWatched(id, isWatched);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpPost("{categoryId}")]
        //public IActionResult Post(int categoryId, [FromBody] Movie movie)
        //{
            //try
          //  {
                
              //  var category = _categoryRepository.GetCategoryById(categoryId);

                //var createdMovie = _movieService.CreateMovie(movie);

                //if (category != null && createdMovie != null)
                //{
                  //  _movieService.AddMovieToCategory(createdMovie.Id, categoryId);
                //}

               // return Ok(createdMovie);
            //}
            //catch (Exception ex)
            //{
              //  Console.WriteLine(ex.InnerException);
                //return BadRequest(ex.Message);
            //}
        //}

    }
}
