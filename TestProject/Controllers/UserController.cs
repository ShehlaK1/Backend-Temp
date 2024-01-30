using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using RESTCore.Services;

namespace RESTCore.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public IActionResult GetAll()
        {
            List<UserDTO> userDTOs = _userService.GetAll();
            return Ok(userDTOs);
        }

        [HttpGet("users/{id}")]
        public IActionResult GetById(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            UserDTO userDTO = _userService.GetById(id);
            return Ok(userDTO);
        }

        [HttpPost("users")]
        public IActionResult CreateUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }
            _userService.Create(userDTO);
            return Ok("Added");
        }

        [HttpDelete("users/{id}")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var result = _userService.Delete(id);
            if (result == true)
            {
                return Ok("Deleted successfully!");
            }
            return NotFound();
        }
    }
}
