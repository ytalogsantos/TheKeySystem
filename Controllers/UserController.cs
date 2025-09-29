using Microsoft.AspNetCore.Mvc;
using TheKeySystem.Models;
using TheKeySystem.Services;

[Route("users")]
[ApiController]
public class UserController
{
    UserService Service;

    public UserController(UserService service)
    {
        Service = service;
    }

    [HttpGet]
    public async Task<List<User>> GetAll()
    {
        return await Service.GetAll();
    }
}