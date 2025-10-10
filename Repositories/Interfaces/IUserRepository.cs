using TheKeySystem.Models;

namespace TheKeySystem.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<List<User>> GetAll();
    Task<User> GetById(long id);
    Task<User> Update(User user);
    void Delete(User user);

}