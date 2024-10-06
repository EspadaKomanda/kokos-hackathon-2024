using UserService.Database.Models;

namespace UserService.Repositories.UserRepository;

public interface IUserRepository
{
  Task<User> AddUser(User user);
  Task<User> UpdateUser(User user);
  Task<User?> GetUserById(int id);
  Task<User?> GetUserByEmail(string email);
  Task DeleteUser(User user);
  Task<List<User>> GetUsersList();
  IQueryable<User> GetUsers();
}
