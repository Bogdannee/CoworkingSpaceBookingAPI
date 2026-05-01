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

        public async Task DeleteAsync(int id)
        {
            await _workspaceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Workspace>> GetAllAsync()
        {
            return await _workspaceRepository.GetAllAsync();
        }

        public async Task<Workspace?> GetByIdAsync(int id)
        {
            return await _workspaceRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Workspace entity)
        {
            await _workspaceRepository.UpdateAsync(id, entity);
        }
    }
}
