using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zdybanka.Core;

namespace Zdybanka.Data.Repositories;

public interface IUserRepository
{
    ValueTask<EntityEntry<User>> AddUserAsync(User user);
    EntityEntry<User> RemoveUser(User user);
    Task<User> GetUserByIdAsync(Guid id);
    Task<List<User>> GetUsersAsync();
    EntityEntry<User> UpdateUser(User user);
    Task<int> SaveChangesAsync();
}
