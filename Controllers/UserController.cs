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

    [HttpGet("{id}")]
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

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(long id)
    {
        try
        {
            var updatedUser = await service.Update(id);
            if (updatedUser != null)
            {
                return Ok();
            }
            return NotFound();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}