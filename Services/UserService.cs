using Microsoft.EntityFrameworkCore;
using TheKeySystem.Models;
namespace TheKeySystem.Services;

public class UserService
{
    private readonly TksDbContext Context;

    public UserService(TksDbContext context)
    {
        Context = context;
    }

    public async Task<List<User>> GetAll()
    {
        var users = await Context.Users.ToListAsync();
        return users;
    }
}