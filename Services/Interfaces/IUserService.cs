using TheKeySystem.Models;

namespace TheKeySystem.Services.Interfaces;

public interface IUserService
{
    public Task<User> CreateUser(User user);
    public Task<List<User>> GetUsers();
    public Task<User> GetUser(long id);
    public Task<User> UpdateUser(long id, User user);
    public void DeleteUser(long id);
}