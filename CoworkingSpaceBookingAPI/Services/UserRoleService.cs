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

        public async Task<UserRole> AddAsync(UserRole entity)
        {
            var returnedEntity = await _userRoleRepository.AddAsync(entity);

            return returnedEntity;
        }

        public async Task DeleteAsync(int id)
        {
            await _userRoleRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _userRoleRepository.GetAllAsync();
        }

        public async Task<UserRole?> GetByIdAsync(int id)
        {
            return await _userRoleRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, UserRole entity)
        {
            await _userRoleRepository.UpdateAsync(id, entity);
        }
    }
}
