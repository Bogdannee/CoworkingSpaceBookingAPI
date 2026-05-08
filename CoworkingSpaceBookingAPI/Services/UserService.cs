using AutoMapper;
using BCrypt.Net;
using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.FileIO;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime;
using System.Security.Claims;
using System.Text;

namespace CoworkingSpaceBookingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration config)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
        }

        public async Task<UserReadDto> AddAsync(UserCreateDto userDto)
        {
            var existUser = await _userRepository.GetByEmailAsync(userDto.Email);

            if (existUser != null)
            {
                return null;
            }

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

            if (returnedEntity == null)
            {
                throw new KeyNotFoundException($"User c id={id} не найден.");
            }

            var userReadDto = _mapper.Map<UserReadDto>(returnedEntity);

            return userReadDto;
        }

        public async Task UpdateAsync(int id, UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);

            await _userRepository.UpdateAsync(id, user);
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null) throw new KeyNotFoundException($"User c Email={loginDto.Email} не найден.");

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                return null;

            var token = GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Token = token,
                User = _mapper.Map<UserReadDto>(user)
            };
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
