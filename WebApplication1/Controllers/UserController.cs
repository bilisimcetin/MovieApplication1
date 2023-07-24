using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.Entities;
using MovieApplicationBusiness.Abstract;
using MvApp1.Business.Abstract;
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
        public IActionResult Post([FromBody] AddUserDto addUserDto)
        {
            try
            {
                var createdUser = _userService.CreateUser(addUserDto);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] AddUserDto updatedUserDto)
        {
            try
            {
                _userService.UpdateUser(id, updatedUserDto);
                return Ok("User updated successfully.");
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = _userService.Authenticate(userLoginDto.Username, userLoginDto.Password);

            if (user == null)
            {
                return Unauthorized(); // 401 Unauthorized dönüş kodu
            }

            // Kullanıcı başarıyla oturum açtı, burada gerekli işlemleri yapabilirsiniz

            return Ok(user); // 200 OK dönüş kodu
        }



    }
}
