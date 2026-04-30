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

        public async Task AddAsync(Workspace entity)
        {
            await _workspaceRepository.AddAsync(entity);
        }

        public void Delete(Workspace entity)
        {
            _workspaceRepository.Delete(entity);
        }

        public async Task<IEnumerable<Workspace>> GetAllAsync()
        {
            return await _workspaceRepository.GetAllAsync();
        }

        public async Task<Workspace?> GetByIdAsync(int id)
        {
            return await _workspaceRepository.GetByIdAsync(id);
        }

        public void Update(Workspace entity)
        {
            _workspaceRepository.Update(entity);
        }
    }
}
