using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers([FromBody] User currentUser)
        {
            try
            {
                if (currentUser == null || currentUser.Role != "Administrateur")
                {
                    return Forbid("You must be an administrator to do this.");
                }

                var users = await _userService.GetUsersAsync();
                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "Error while fetching users.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            try
            {
                await _userService.AddUserAsync(user);
                return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
            }
            catch
            {
                return StatusCode(500, "Error adding user");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
