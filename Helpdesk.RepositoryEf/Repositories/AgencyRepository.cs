using Helpdesk.RepositoryEf.Contexts;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.RepositoryEf.Repositories
{
    public class AgencyRepository : IAgencyRepository
    {
        private AppDbContext _appDbContext;

        public AgencyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(AgencyEntity entity)
        {
            await _appDbContext.Agency.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id, int userId)
        {
            AgencyEntity entity;

            entity = await _appDbContext.Agency.Where(x => x.Id == id).FirstAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<AgencyEntity>> GetListAsync(int projectId)
        {
            return await _appDbContext.Agency.Where(x=> x.IsActive && x.ProjectId == projectId).ToListAsync();
        }

        public async Task<AgencyEntity> GetAsync(int id)
        {
            return await _appDbContext.Agency.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task UpdateAsync(AgencyEntity entity)
        {
            _appDbContext.Agency.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}