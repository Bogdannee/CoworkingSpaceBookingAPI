using AutoMapper;
using BCrypt.Net;
using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;
using System.Collections;

namespace CoworkingSpaceBookingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> AddAsync(UserCreateDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            userEntity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            var createdUser = await _userRepository.AddAsync(userEntity);

            return _mapper.Map<UserReadDto>(createdUser);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var returnedEntities = await _userRepository.GetAllAsync();
            var userReadDto = _mapper.Map<List<UserReadDto>>(returnedEntities);

            return userReadDto;
        }

        public async Task<UserReadDto?> GetByIdAsync(int id)
        {
            var returnedEntity = await _userRepository.GetByIdAsync(id);
            var userReadDto = _mapper.Map<UserReadDto>(returnedEntity);

            return userReadDto;
        }

        public async Task UpdateAsync(int id, UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);

            await _userRepository.UpdateAsync(id, user);
        }
    }
}
