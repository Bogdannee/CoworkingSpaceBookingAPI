using CoworkingSpaceBookingAPI.Domain.Entities;
using CoworkingSpaceBookingAPI.Repositories.Interfaces;
using CoworkingSpaceBookingAPI.Services.Interfaces;

namespace CoworkingSpaceBookingAPI.Services
{
    public class WorkspaceService : IWorkspaceService
    {
        private readonly IWorkspaceRepository _workspaceRepository;

        public WorkspaceService(IWorkspaceRepository workspaceRepository)
        {
            _workspaceRepository = workspaceRepository;
        }

        public async Task<Workspace> AddAsync(Workspace entity)
        {
            var returnedEntity = await _workspaceRepository.AddAsync(entity); 

            return returnedEntity;
        }

        public async Task DeleteAsync(Workspace entity)
        {
            await _workspaceRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Workspace>> GetAllAsync()
        {
            return await _workspaceRepository.GetAllAsync();
        }

        public async Task<Workspace?> GetByIdAsync(int id)
        {
            return await _workspaceRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Workspace entity)
        {
            await _workspaceRepository.UpdateAsync(entity);
        }
    }
}
