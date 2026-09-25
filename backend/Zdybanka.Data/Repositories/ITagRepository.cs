using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zdybanka.Core;

namespace Zdybanka.Data.Repositories;

public interface ITagRepository
{
    Task<Tag> AddTagAsync(Tag tag);
    Task<Tag> GetTagByIdAsync(Guid id);
    Task<List<Tag>> GetTagsAsync();
    void RemoveTag(Tag tag);
    Task<int> SaveChangesAsync();
    Tag UpdateTag(Tag tag);
}
