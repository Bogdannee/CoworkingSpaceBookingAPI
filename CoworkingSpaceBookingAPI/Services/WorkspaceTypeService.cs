using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class WorkspaceTypeService : IWorkspaceTypeService
    {
        private readonly IWorkspaceTypeRepository _workspaceTypeRepository;

        public WorkspaceTypeService(IWorkspaceTypeRepository workspaceTypeRepository)
        {
            _workspaceTypeRepository = workspaceTypeRepository;
        }

        public async Task<WorkspaceType> AddAsync(WorkspaceType entity)
        {
            var returnedEntity = await _workspaceTypeRepository.AddAsync(entity);

            return returnedEntity;
        }

        public async Task DeleteAsync(WorkspaceType entity)
        {
            await _workspaceTypeRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<WorkspaceType>> GetAllAsync()
        {
            return await _workspaceTypeRepository.GetAllAsync();
        }

        public async Task<WorkspaceType?> GetByIdAsync(int id)
        {
            return await _workspaceTypeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(WorkspaceType entity)
        {
            await _workspaceTypeRepository.UpdateAsync(entity);
        }
    }
}
