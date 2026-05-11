using Coworking.Application.DTOs;

namespace Coworking.Application.Interfaces.ServiceInterfeces
{
    public interface IUserService
    {
        Task<UserReadDto?> GetByIdAsync(int id);
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto> AddAsync(UserCreateDto entity);
        Task UpdateAsync(int id, UserCreateDto entity);
        Task DeleteAsync(int id);
        Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);
    }
}
