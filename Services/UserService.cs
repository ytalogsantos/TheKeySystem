using Microsoft.EntityFrameworkCore;
using TheKeySystem.Models;
using TheKeySystem.Repositories.Interfaces;
using TheKeySystem.Repositories;
namespace TheKeySystem.Services;

public class UserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository repository)
    {
        userRepository = repository;
    }

    public async Task<User> CreateUser(User user)
    {
        var newUser = await userRepository.Create(user);
        return newUser;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await userRepository.GetAll();
        return users;
    }

    public async Task<User> GetUser(long id)
    {
        try
        {

            var userFound = await userRepository.GetById(id);
            return userFound != null ? userFound : null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<User> Update(long id)
    {
        try
        {
            var userToUpdate = await GetUser(id);
            if (userToUpdate != null)
            {
                var updatedUser = await userRepository.Update(userToUpdate);
                return updatedUser;
            }
            return null;
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
            userRepository.Delete(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}