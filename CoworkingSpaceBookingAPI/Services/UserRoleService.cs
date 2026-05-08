using AutoMapper;
using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public async Task<UserRoleDto> AddAsync(UserRoleDto userRoleDto)
        {
            var userRoleEntity = _mapper.Map<UserRole>(userRoleDto);

            var createdEntity = await _userRoleRepository.AddAsync(userRoleEntity);

            return _mapper.Map<UserRoleDto>(createdEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRoleRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserRoleDto>> GetAllAsync()
        {
            var returnedEntities = await _userRoleRepository.GetAllAsync();
            var userRoleDtoList = _mapper.Map<List<UserRoleDto>>(returnedEntities);

            return userRoleDtoList;
        }

        public async Task<UserRoleDto?> GetByIdAsync(int id)
        {
            var returnedEntity = await _userRoleRepository.GetByIdAsync(id);

            if (returnedEntity == null)
            {
                throw new KeyNotFoundException($"UserRole c id={id} не найден."); 
            }

            var userRoleDto = _mapper.Map<UserRoleDto>(returnedEntity);

            return userRoleDto;
        }

        public async Task UpdateAsync(int id, UserRoleDto userRoleDto)
        {
            var userRoleEntity = _mapper.Map<UserRole>(userRoleDto);

            await _userRoleRepository.UpdateAsync(id, userRoleEntity);
        }
    }
}
