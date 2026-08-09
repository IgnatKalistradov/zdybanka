using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zdybanka.Core;

namespace Zdybanka.Data.Repositories;

public class UserRepository : IUserRepository
{
    private ZdybankaContext _context;

    public UserRepository(ZdybankaContext context)
    {
        _context = context;
    }

    public Task<User> GetUserByIdAsync(Guid id)
    {
        return _context.Users.FirstAsync(u => u.Id == id);
    }

    public Task<List<User>> GetUsersAsync()
    {
        return _context.Users.ToListAsync();
    }

    public ValueTask<EntityEntry<User>> AddUserAsync(User user)
    {
        return _context.Users.AddAsync(user);
    }

    public EntityEntry<User> RemoveUser(User user)
    {
        return _context.Users.Remove(user);
    }

    public EntityEntry<User> UpdateUser(User user)
    {
        return _context.Users.Update(user);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}