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

        public async Task<List<AgencyEntity>> GetListAsync(AgencySearchEntity search)
        {
            List<AgencyEntity> list;
            IQueryable<AgencyEntity> queryable;

            list = new List<AgencyEntity>();            
            queryable = _appDbContext.Agency;
            queryable = queryable.Where(x => x.IsActive);
            if (search.ProjectId is not null)
            {
                queryable = queryable.Where(x => x.ProjectId == search.ProjectId);
            }
            if (!string.IsNullOrEmpty(search.Name))
            {
                queryable = queryable.Where(x => x.Name.ToUpper().Contains(search.Name.ToUpper()));
            }
            list = await queryable            
            .OrderBy(x => x.Id)
            .Skip((search.PageCurrent - 1) * search.RecordsPerPage)
            .Take(search.RecordsPerPage)
            .ToListAsync();
            search.TotalRecords = await queryable.CountAsync();

            return list;
        }

        public async Task<AgencyEntity> GetAsync(int id)
        {
            return await _appDbContext.Agency.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(AgencyEntity entity)
        {
            _appDbContext.Agency.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}