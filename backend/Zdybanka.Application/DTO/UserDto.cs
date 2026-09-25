namespace Zdybanka.Application.Services;

public record UserDto
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? AvatarUrl { get; set; }
}