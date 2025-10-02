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

    public async Task<User> CreateUser(User user)
    {
        var newUser = Context.Users.Add(user);
        await Context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<List<User>> GetAll()
    {
        var users = await Context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetUser(long id)
    {
        try
        {

            var userFound = await Context.Users.FindAsync(id);
            return userFound != null ? userFound : null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}