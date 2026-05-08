using AutoMapper;
using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class WorkspaceTypeService : IWorkspaceTypeService
    {
        private readonly IWorkspaceTypeRepository _workspaceTypeRepository;
        private readonly IMapper _mapper;

        public WorkspaceTypeService(IWorkspaceTypeRepository workspaceTypeRepository, IMapper mapper)
        {
            _workspaceTypeRepository = workspaceTypeRepository;
            _mapper = mapper;
        }

        public async Task<WorkspaceTypeDto> AddAsync(WorkspaceTypeDto workspaceTypeDto)
        {
            var workspaceTypeEntity = _mapper.Map<WorkspaceType>(workspaceTypeDto);

            var createdEntity = await _workspaceTypeRepository.AddAsync(workspaceTypeEntity);

            return _mapper.Map<WorkspaceTypeDto>(createdEntity);
        }

        public async Task DeleteAsync(int id)
        {
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

            await _workspaceTypeRepository.UpdateAsync(id, workspaceType);
        }
    }
}
