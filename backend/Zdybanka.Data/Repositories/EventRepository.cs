using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Zdybanka.Core;
using Zdybanka.Data.DTO;

namespace Zdybanka.Data.Repositories;

public class EventRepository : IEventRepository
{
    private ZdybankaContext _context;
    public EventRepository(ZdybankaContext context)
    {
        _context = context;
    }

    public ValueTask<EntityEntry<Event>> AddEventAsync(Event @event)
    {
        return _context.Events.AddAsync(@event);
    }

    public Task<Event> GetEventByIdAsync(Guid id)
    {
        return _context.Events.FirstAsync(e => e.Id == id);
    }

    public Task<List<Event>> GetEventsAsync()
    {
        return _context.Events.ToListAsync();
    }

    public List<Event> GetEventsByCreator(Guid creatorId)
    {
        return _context.Events.Where(e => e.CreatorId == creatorId).ToList();
    }

    public IQueryable<EventDistance> GetEventsByDistanceAsync(float latitude, float longtitude)
    {
        return _context.GetEventsByDistance(latitude, longtitude);
    }

    public IQueryable<EventInBorder> GetEventsInBordersAsync(float minLatitude, float minLongtitude, float maxLatitude, float maxLongtitude)
    {
        return _context.GetEventsInBorders(minLatitude, minLongtitude, maxLatitude, maxLongtitude);
    }

    public EntityEntry<Event> RemoveEvent(Event @event)
    {
        return _context.Events.Remove(@event);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public EntityEntry<Event> UpdateEventAsync(Event @event)
    {
        return _context.Events.Update(@event);
    }
}