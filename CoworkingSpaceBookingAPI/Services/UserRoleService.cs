using AutoMapper;
using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;
using Serilog.Core;

namespace CoworkingSpaceBookingAPI.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRoleService> _logger;

        public UserRoleService(IUserRoleRepository userRoleRepository, IMapper mapper, ILogger<UserRoleService> logger)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserRoleDto> AddAsync(UserRoleDto userRoleDto)
        {
            var userRoleEntity = _mapper.Map<UserRole>(userRoleDto);

            var createdEntity = await _userRoleRepository.AddAsync(userRoleEntity);

            _logger.LogInformation("Создан новый userRole Role: {Role}, ID: {Id}", createdEntity.Role, createdEntity.Id);

            return _mapper.Map<UserRoleDto>(createdEntity);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Удаление UserRole с ID: {Id}", id);

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

            _logger.LogInformation("Обновление данных UserRole ID: {Id}", id);

            await _userRoleRepository.UpdateAsync(id, userRoleEntity);
        }
    }
}
