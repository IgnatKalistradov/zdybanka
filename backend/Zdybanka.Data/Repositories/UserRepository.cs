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

    public async Task<User> AddUserAsync(User user)
    {
        EntityEntry<User> entry = await _context.Users.AddAsync(user);

        return entry.Entity;
    }

    public void RemoveUser(User user)
    {
        _context.Users.Remove(user);
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}