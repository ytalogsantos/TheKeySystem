using Microsoft.AspNetCore.Mvc;
using TheKeySystem.Models;
using TheKeySystem.Services;

[Route("users")]
[ApiController]
public class UserController : ControllerBase
{
    UserService Service;

    public UserController(UserService service)
    {
        Service = service;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        try
        {
            var newUser = await Service.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id}, newUser);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet]
    public async Task<List<User>> GetAll()
    {
        return await Service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<User> GetUser(long id)
    {
        try
        {
            var userFound = await Service.GetUser(id);
            if (userFound != null)
            {
                return userFound;
            }
            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}