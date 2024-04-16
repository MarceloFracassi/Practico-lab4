using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tp_lab4.Data;
using Tp_lab4.Entities;
using Tp_lab4.Service;

namespace Tp_lab4.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class ControllerUser : ControllerBase
        {
            private readonly UserService _userService;

            public ControllerUser(UserService userService)
            {
                _userService = userService;
            }

            [HttpGet("all")]
            public IActionResult GetUserById(int Id)
            {
                {
                    User UserId = _userService.GetUserById(Id);
                    return Ok(UserId);
                }
                return Forbid();
            }

        [HttpPost("NewUser")]
        public IActionResult CreateUser([FromBody] UserPostDto dto)
        {

            var user = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                Address = dto.Address,
            };
            int id = _userService.CreateUser(user);
            return Ok(id);
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int UserId)
        {

                User userToDelete = _userService.GetUserById(UserId);

                if (userToDelete != null)
                {
                _userService.DeleteUser(userToDelete);
                }
                else
                {
                    return NotFound("Usuario no encontrado");
                }
            
            return NoContent();
        }
    }
}