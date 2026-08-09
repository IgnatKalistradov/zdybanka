using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zdybanka.Core;
using Zdybanka.Data.DTO;

namespace Zdybanka.Data.Repositories;

public interface IEventRepository
{
    Task<List<Event>> GetEventsAsync();
    IQueryable<EventDistance> GetEventsByDistanceAsync(float latitude, float longtitude);
    IQueryable<EventInBorder> GetEventsInBordersAsync(float minLatitude, float minLongtitude, float maxLatitude, float maxLongtitude);
    Task<Event> GetEventByIdAsync(Guid id);
    List<Event> GetEventsByCreator(Guid creatorId);
    ValueTask<EntityEntry<Event>> AddEventAsync(Event @event);
    EntityEntry<Event> RemoveEvent(Event @event);
    EntityEntry<Event> UpdateEventAsync(Event @event);
    Task<int> SaveChangesAsync();
}