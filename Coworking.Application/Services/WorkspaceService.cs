using AutoMapper;
using Coworking.Application.DTOs;
using Coworking.Application.Interfaces.ServiceInterfeces;
using Coworking.Application.Interfaces.RepositoryInterfaces;
using Microsoft.Extensions.Logging;
using Coworking.Domain.Entities;

namespace Coworking.Application.Services
{
    public class WorkspaceService : IWorkspaceService
    {
        private readonly IWorkspaceRepository _workspaceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkspaceService> _logger;

        public WorkspaceService(IWorkspaceRepository workspaceRepository, IMapper mapper, ILogger<WorkspaceService> logger)
        {
            _workspaceRepository = workspaceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<WorkspaceDto> AddAsync(WorkspaceDto workspaceDto)
        {
            var workspaceEntity = _mapper.Map<Workspace>(workspaceDto);

            var createdEntity = await _workspaceRepository.AddAsync(workspaceEntity);

            _logger.LogInformation("Создан новый Workspace RoomId: {RoomId}, ID: {Id}", createdEntity.RoomId, createdEntity.Id);

            return _mapper.Map<WorkspaceDto>(createdEntity);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Удаление Workspace с ID: {Id}", id);

            await _workspaceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<WorkspaceDto>> GetAllAsync()
        {
            var returnedEntities = await _workspaceRepository.GetAllAsync();
            var workspaceDtoList = _mapper.Map<List<WorkspaceDto>>(returnedEntities);

            return workspaceDtoList;
        }

        public async Task<WorkspaceDto?> GetByIdAsync(int id)
        {
            var returnedEntity = await _workspaceRepository.GetByIdAsync(id);

            if (returnedEntity == null)
            {
                throw new KeyNotFoundException($"Workspace c id={id} не найден.");
            }

            var workspaceDto = _mapper.Map<WorkspaceDto>(returnedEntity);

            return workspaceDto;
        }

        public async Task UpdateAsync(int id, WorkspaceDto workspaceDto)
        {
            var workspaceEntity = _mapper.Map<Workspace>(workspaceDto);
            _logger.LogInformation("Обновление данных Workspace ID: {Id}", id);

            await _workspaceRepository.UpdateAsync(id, workspaceEntity);
        }
    }
}
