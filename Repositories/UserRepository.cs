using TheKeySystem.Models;
using TheKeySystem.Repositories.Interfaces;
using TheKeySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace TheKeySystem.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TksDbContext context;

    public UserRepository(TksDbContext context)
    {
        this.context = context;
    }
    public async Task<User> Create(User user)
    {
        try
        {
            if (user != null)
            {
                var newUser = await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return newUser.Entity;
            }
            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<User>> GetAll()
    {
        try
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<User> GetById(long id)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(e => e.Id == id);
            return user;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<User> Update(User user)
    {
        try
        {
            var updatedUser = await context.Users.FirstOrDefaultAsync(e => e.Id == user.Id);
            if (user == null)
            {
                return null;
            }

            updatedUser.Username = user.Username;
            updatedUser.Password = user.Password;
            await context.SaveChangesAsync();

            return updatedUser;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async void Delete(long id)
    {
        try
        {
            var userToDelete = await context.Users.FirstOrDefaultAsync(e => e.Id == id);

            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}