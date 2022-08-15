using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeworkClass01.Services.Interfaces;
using HomeworkClass01.DTOs.UserViewDTOs;
using HomeworkClass01.ViewModels.UserViewModels;

namespace HomeworkClass01_HomeworkClass02_WebApi.Controllers
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
        public ActionResult<List<UserDetailsDTO>> GetAllUsers()
        {
            try
            {
                List<UserDetailsDTO> usersListDto = _userService.GetAllUsers();
                return Ok(usersListDto);
            }
            catch
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the administrator!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserDetailsDTO> GetUserById(int? id)
        {
            if(id == null)
            {
                return NotFound($"The user with {id} does not exist!");
            }
            try
            {
                UserDetailsDTO userDetailsDto = _userService.GetUserById(id.Value);
                return Ok(userDetailsDto);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred , please contact the administrator!");
            }
        }
        [HttpPost("addUser")]

        public IActionResult AddUser([FromBody] AddUserDto addUserDto)
        {
            try
            {
                _userService.CreateUser(addUserDto);
                return StatusCode(StatusCodes.Status201Created, "New user was created!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred , please contact the administrator!");
            }
        }
    }
}
