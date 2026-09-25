using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zdybanka.Core;

namespace Zdybanka.Data.Repositories;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user);
    void RemoveUser(User user);
    Task<User> GetUserByIdAsync(Guid id);
    Task<List<User>> GetUsersAsync();
    void UpdateUser(User user);
    Task<int> SaveChangesAsync();
}
