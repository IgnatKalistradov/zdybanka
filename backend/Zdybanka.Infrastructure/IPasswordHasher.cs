namespace Zdybanka.Infrastructure;

public interface IPasswordHasher
{
    string HashPassword(string password);
    string VerifyPassword(string passwordHash);
}