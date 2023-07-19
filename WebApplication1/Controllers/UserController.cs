﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.Entities;
using MovieApplicationBusiness.Abstract;
using MvApp1.Entities;

namespace MovieApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> Get()

        { return _userService.GetAllUsers(); }

        [HttpGet("{id}")]

        public User Get(int id)

        { return _userService.GetUserById(id); }


        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _userService.CreateUser(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                var updatedUser = _userService.UpdateUser(id, user);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}/watched")]
        public IActionResult GetWatchedMovies(int id)
        {
            try
            {
                var watchedMovies = _userService.GetWatchedMovies(id);
                return Ok(watchedMovies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{userId}/watched/{movieId}")]
        public IActionResult MovieAsWatched(int userId, int movieId)
        {
            try
            {
                _userService.MovieAsWatched(userId, movieId);
                return Ok("Movie marked as watched.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
