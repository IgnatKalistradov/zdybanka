using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zdybanka.Core;

namespace Zdybanka.Data.Repositories;

public class TagRepository(ZdybankaContext context) : ITagRepository
{
    private ZdybankaContext _context = context;

    public Task<List<Tag>> GetTags()
    {
        return _context.Tags.ToListAsync();
    }

    public Task<Tag> GetTagByIdAsync(Guid id)
    {
        return _context.Tags.FirstAsync(t => t.Id == id);
    }

    public ValueTask<EntityEntry<Tag>> AddTagAsync(Tag tag)
    {
        return _context.Tags.AddAsync(tag);
    }

    public EntityEntry<Tag> RemoveTag(Tag tag)
    {
        return _context.Tags.Remove(tag);
    }

    public EntityEntry<Tag> UpdateTag(Tag tag)
    {
        return _context.Tags.Update(tag);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

}