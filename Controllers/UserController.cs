using Microsoft.AspNetCore.Mvc;
using TheKeySystem.Models;
using TheKeySystem.Services;

[Route("users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService service;

    public UserController(UserService service)
    {
        this.service = service;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        try
        {
            var newUser = await service.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, newUser);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        try
        {
            var users = await service.GetUsers();

            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet("{int:id}")]
    public async Task<ActionResult<User>> GetUser(long id)
    {
        try
        {
            var userFound = await service.GetUser(id);
            if (userFound != null)
            {
                return userFound;
            }
            return NotFound();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPut("{int:id}")]
    public async Task<ActionResult> UpdateUser(long id, User user)
    {
        try
        {
            if (id != user.Id)
            {
                return BadRequest("User Id mismatch.");
            }

            var updatedUser = await service.UpdateUser(id);
            if (updatedUser != null)
            {
                return Ok("User updated.");
            }
            return NotFound("User not found.");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpDelete("{int:id}")]
    public async Task<ActionResult> DeleteUser(long id)
    {
        try
        {
            var userToDelete = await GetUser(id);
            if (userToDelete != null)
            {
                return Ok("User deleted.");
            }
            return NotFound("User not found.");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data.");
        }
    }
}