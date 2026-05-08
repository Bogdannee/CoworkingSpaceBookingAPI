using AutoMapper;
using CoworkingSpaceBookingAPI.Domain.DTOs;
using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class WorkspaceService : IWorkspaceService
    {
        private readonly IWorkspaceRepository _workspaceRepository;
        private readonly IMapper _mapper;

        public WorkspaceService(IWorkspaceRepository workspaceRepository, IMapper mapper)
        {
            _workspaceRepository = workspaceRepository;
            _mapper = mapper;
        }

        public async Task<WorkspaceDto> AddAsync(WorkspaceDto workspaceDto)
        {
            var workspaceEntity = _mapper.Map<Workspace>(workspaceDto);

            var returnedEntity = await _workspaceRepository.AddAsync(workspaceEntity);

            return _mapper.Map<WorkspaceDto>(returnedEntity);
        }

        public async Task DeleteAsync(int id)
        {
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

            await _workspaceRepository.UpdateAsync(id, workspaceEntity);
        }
    }
}
