using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class WorkspaceTypeService
    {
        private readonly IWorkspaceTypeRepository _workspaceTypeRepository;

        public WorkspaceTypeService(IWorkspaceTypeRepository workspaceTypeRepository)
        {
            _workspaceTypeRepository = workspaceTypeRepository;
        }

        public async Task AddAsync(WorkspaceType entity)
        {
            await _workspaceTypeRepository.AddAsync(entity);
        }

        public void Delete(WorkspaceType entity)
        {
            _workspaceTypeRepository.Delete(entity);
        }

        public async Task<IEnumerable<WorkspaceType>> GetAllAsync()
        {
            return await _workspaceTypeRepository.GetAllAsync();
        }

        public async Task<WorkspaceType?> GetByIdAsync(int id)
        {
            return await _workspaceTypeRepository.GetByIdAsync(id);
        }

        public void Update(WorkspaceType entity)
        {
            _workspaceTypeRepository.Update(entity);
        }
    }
}
