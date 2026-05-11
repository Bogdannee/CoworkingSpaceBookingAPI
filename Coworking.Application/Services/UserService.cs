using AutoMapper;
using Coworking.Application.DTOs;
using Coworking.Application.Interfaces.ServiceInterfeces;
using Coworking.Application.Interfaces.RepositoryInterfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Coworking.Domain.Entities;

namespace Coworking.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration config, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
            _logger = logger;
        }

        public async Task<UserReadDto> AddAsync(UserCreateDto userDto)
        {
            var existUser = await _userRepository.GetByEmailAsync(userDto.Email);

            if (existUser != null)
            {
                _logger.LogWarning("Попытка регистрации на уже существующий Email: {Email}", userDto.Email);
                throw new InvalidOperationException($"Пользователь с Email {userDto.Email} уже зарегистрирован.");
            }

            var userEntity = _mapper.Map<User>(userDto);
            userEntity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            var createdUser = await _userRepository.AddAsync(userEntity);

            _logger.LogInformation("Создан новый пользователь: {Email}, ID: {UserId}", createdUser.Email, createdUser.Id);

            return _mapper.Map<UserReadDto>(createdUser);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Удаление пользователя с ID: {UserId}", id);
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

            _logger.LogInformation("Обновление данных пользователя ID: {UserId}", id);

            await _userRepository.UpdateAsync(id, user);
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null)
            {
                _logger.LogWarning("Неудачная попытка входа: пользователь с Email {Email} не найден.", loginDto.Email);
                throw new KeyNotFoundException($"User c Email={loginDto.Email} не найден.");

            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                _logger.LogWarning("Неверный пароль для пользователя: {Email}", loginDto.Email);
                return null;
            }

            _logger.LogInformation("Пользователь {Email} (ID: {UserId}) успешно вошел в систему.", user.Email, user.Id);
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
