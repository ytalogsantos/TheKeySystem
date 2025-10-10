using Microsoft.EntityFrameworkCore;
using TheKeySystem.Models;
using TheKeySystem.Repositories.Interfaces;
using TheKeySystem.Repositories;
using TheKeySystem.Services.Interfaces;
namespace TheKeySystem.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository repository)
    {
        userRepository = repository;
    }

    public async Task<User> CreateUser(User user) // TODO: implement more validations
    {
        var newUser = await userRepository.Create(user);
        return newUser;
    }

    public async Task<List<User>> GetUsers() // TODO: more validations here too
    {
        var users = await userRepository.GetAll();
        return users;
    }

    public async Task<User> GetUser(long id) // and here...
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

    public async Task<User> UpdateUser(long id, User user)
    {
        try
        {
            var userToUpdate = await GetUser(id);
            if (userToUpdate != null)
            {
                userToUpdate.Username = user.Username;
                userToUpdate.Password = user.Password;
    
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


    public async void DeleteUser(long id)
    {
        try
        {
            var userToDelete = await userRepository.GetById(id);

            if (userToDelete != null)
            {
                userRepository.Delete(userToDelete);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}