using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zdybanka.Core;

namespace Zdybanka.Data.Repositories;

public interface ITagRepository
{
    ValueTask<EntityEntry<Tag>> AddTagAsync(Tag tag);
    Task<Tag> GetTagByIdAsync(Guid id);
    Task<List<Tag>> GetTags();
    EntityEntry<Tag> RemoveTag(Tag tag);
    Task<int> SaveChangesAsync();
    EntityEntry<Tag> UpdateTag(Tag tag);
}
