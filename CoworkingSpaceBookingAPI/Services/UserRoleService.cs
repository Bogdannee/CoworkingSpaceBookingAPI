using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task AddAsync(UserRole entity)
        {
            await _userRoleRepository.AddAsync(entity);
        }

        public void Delete(UserRole entity)
        {
            _userRoleRepository.Delete(entity);
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _userRoleRepository.GetAllAsync();
        }

        public async Task<UserRole?> GetByIdAsync(int id)
        {
            return await _userRoleRepository.GetByIdAsync(id);
        }

        public void Update(UserRole entity)
        {
            _userRoleRepository.Update(entity);
        }
    }
}
