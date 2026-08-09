namespace Zdybanka.Data.DTO;

public class EventInBorder
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Latitude { get; set; }
    public float Longtitude { get; set; }
}