using AutoMapper;
using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;
using Serilog.Core;

namespace CoworkingSpaceBookingAPI.Services
{
    public class WorkspaceTypeService : IWorkspaceTypeService
    {
        private readonly IWorkspaceTypeRepository _workspaceTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkspaceTypeService> _logger;

        public WorkspaceTypeService(IWorkspaceTypeRepository workspaceTypeRepository, IMapper mapper, ILogger<WorkspaceTypeService> logger)
        {
            _workspaceTypeRepository = workspaceTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<WorkspaceTypeDto> AddAsync(WorkspaceTypeDto workspaceTypeDto)
        {
            var workspaceTypeEntity = _mapper.Map<WorkspaceType>(workspaceTypeDto);

            var createdEntity = await _workspaceTypeRepository.AddAsync(workspaceTypeEntity);

            _logger.LogInformation("Создан новый WorkspaceType Type: {RoomId}, ID: {Id}", createdEntity.Type, createdEntity.Id);

            return _mapper.Map<WorkspaceTypeDto>(createdEntity);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation("Удаление WorkspaceType с ID: {Id}", id);

            await _workspaceTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<WorkspaceTypeDto>> GetAllAsync()
        {
            var returnedEntities = await _workspaceTypeRepository.GetAllAsync();
            var workspaceTypeDtoList = _mapper.Map<List<WorkspaceTypeDto>>(returnedEntities);

            return workspaceTypeDtoList;
        }

        public async Task<WorkspaceTypeDto?> GetByIdAsync(int id)
        {
            var returnedEntity = await _workspaceTypeRepository.GetByIdAsync(id);

            if (returnedEntity == null)
            {
                throw new KeyNotFoundException($"WorkspaceType c id={id} не найден.");
            }

            var workspaceTypeDto = _mapper.Map<WorkspaceTypeDto>(returnedEntity);

            return workspaceTypeDto;
        }

        public async Task UpdateAsync(int id, WorkspaceTypeDto workspaceTypeDto)
        {
            var workspaceType = _mapper.Map<WorkspaceType>(workspaceTypeDto);
            _logger.LogInformation("Обновление данных WorkspaceType ID: {Id}", id);

            await _workspaceTypeRepository.UpdateAsync(id, workspaceType);
        }
    }
}
