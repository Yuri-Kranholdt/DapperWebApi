using DapperWebApi.Dto;
using DapperWebApi.Models;
using DapperWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface _userInterface;
        public UserController(UserInterface userInterface) 
        {
            _userInterface = userInterface;
        }

        [HttpGet]

        public async Task<IActionResult> GetUsers() 
        { 
            var users = await _userInterface.GetUsers();
            if (users.status == false)
            {
                return NotFound(users);
            }
            return Ok(users);
        }

        [HttpGet("FindUser/{id}")]
        public async Task<IActionResult> FindUser(int id)
        {
            var user = await _userInterface.FindUser(id);
            if (user.status == false)
            {
                return NotFound(user);
            }
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserCreateDto userCreateDto)
        {
            var users = await _userInterface.CreateUser(userCreateDto);
            if (users.status == false)
            {
                return BadRequest(users);
            }
            return Ok(users);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var users = await _userInterface.UpdateUser(userUpdateDto);
            if (users.status == false) 
            { 
                return BadRequest(users);
            }
            return Ok(users);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var users = await _userInterface.DeleteUser(id);
            if (users.status == false)
            {
                return BadRequest(users);
            }
            return Ok(users);
        }
    }
}
