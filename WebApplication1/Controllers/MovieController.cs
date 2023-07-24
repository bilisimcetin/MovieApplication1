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

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] MovieCreateDTO updatedMovie)
        {
            try
            {
                _movieService.UpdateMovie(id, updatedMovie);
                return Ok("Movie updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public void Delete(int id) 
        {

            _movieService.DeleteMovie(id);
        }

        [HttpPut("{id}/watched")]
        public IActionResult MarkAsWatched(int id)
        {
            try
            {
                _movieService.MarkAsWatched(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Diğer olası hatalar için burada uygun işlemler yapılabilir.
                return StatusCode(500, "An error occurred.");
            }
        }



    }
}
