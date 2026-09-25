using Zdybanka.Core;
using Zdybanka.Data.Repositories;
using Zdybanka.Infrastructure;

namespace Zdybanka.Application.Services;

public class UserService
{
    private IUserRepository _repository;
    private IPasswordHasher _hasher;

    public UserService(IUserRepository repository, IPasswordHasher hasher)
    {
        _repository = repository;
        _hasher = hasher;
    }

    public async Task<UserDto> GetUserById(Guid id)
    {
        User user = await _repository.GetUserByIdAsync(id);

        return new UserDto()
        {
            Username = user.Username,
            Email = user.Email,
            AvatarUrl = user.AvatarUrl
        };
    }

    public void CreateUser(UserDto dto)
    {
        User user = new User()
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = _hasher.HashPassword(dto.Password),
            AvatarUrl = dto.AvatarUrl
        };

        _repository.AddUserAsync(user);

        _repository.SaveChangesAsync();
    }

    public async Task RemoveUser(Guid id)
    {
        User user = await _repository.GetUserByIdAsync(id);

        _repository.RemoveUser(user);

        await _repository.SaveChangesAsync();
    }

    public async Task UpdateUser(UserDto dto)
    {
        User user = await _repository.GetUserByIdAsync(dto.Id);

        user.Username = dto.Username;
        user.Email = dto.Email;
        user.AvatarUrl = dto.AvatarUrl;

        _repository.UpdateUser(user);
        await _repository.SaveChangesAsync();
    }
}
