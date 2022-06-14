using Helpdesk.RepositoryEf.Contexts;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.RepositoryEf.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private AppDbContext _appDbContext;

        public ProjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> AddAsync(ProjectEntity entity)
        {
            _appDbContext.Project.Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id, int userId)
        {
            ProjectEntity entity;

            entity = await _appDbContext.Project.Where(x=> x.Id == id).FirstAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectEntity>> GetAsync()
        {
            return await _appDbContext.Project.Where(x=> x.IsActive).ToListAsync();
        }

        public async Task<ProjectEntity> GetAsync(int id)
        {
            return await _appDbContext.Project.Where(x=> x.Id == id).FirstAsync();
        }

        public async Task UpdateAsync(ProjectEntity entity)
        {
            _appDbContext.Project.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

    }//edn class
}