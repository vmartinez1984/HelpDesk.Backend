using Helpdesk.RepositoryEf.Contexts;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.RepositoryEf.Repositories
{
    public class AgencyTypeRepository : IAgencyTypeRepository
    {
        private AppDbContext _appDbContext;

        public AgencyTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(AgencyTypeEntity entity)
        {
            await _appDbContext.AgencyType.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id, int userId)
        {
            AgencyTypeEntity entity;

            entity = await _appDbContext.AgencyType.Where(x => x.Id == id).FirstAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<AgencyTypeEntity>> GetAsync()
        {
             return await _appDbContext.AgencyType.Where(x => x.IsActive == true).ToListAsync();
        }

        public Task<AgencyTypeEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(AgencyTypeEntity entity)
        {
            _appDbContext.AgencyType.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}