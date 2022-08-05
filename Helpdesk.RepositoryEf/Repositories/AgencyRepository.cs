using Helpdesk.RepositoryEf.Contexts;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Helpdesk.RepositoryEf.Utilities;
using System.Linq.Dynamic.Core;

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

        public async Task<List<AgencyEntity>> GetAsync(PagerEntity search)
        {
            List<AgencyEntity> list;
            IQueryable<AgencyEntity> queryable;

            queryable = _appDbContext.Agency;
            queryable = queryable.Where(x => x.IsActive);
            search.TotalRecords = queryable.Count();
            if (string.IsNullOrEmpty(search.Search) == false)
                queryable = queryable.Where(
                    x => string.Concat(x.Name, x.Project.Name, x.DateRegistration).Contains(search.Search)
                );
            if (string.IsNullOrEmpty(search.SortColumn) == false && string.IsNullOrEmpty(search.SortColumnDir) == false)
            {
                queryable = queryable.OrderBy(search.SortColumn.GetSortColumn() + " " + search.SortColumnDir);
            }
            list = await queryable
            .OrderByDescending(x => x.Id)
            .Skip((search.PageCurrent - 1) * search.RecordsPerPage)
            .Take(search.RecordsPerPage)
            .ToListAsync();
            search.TotalRecords = await queryable.CountAsync();
            list = await queryable.ToListAsync();
            search.TotalRecordsFiltered = await queryable.CountAsync();
            
            return list;
        }

        public async Task<AgencyEntity> GetAsync(int id)
        {
            AgencyEntity entity;

            entity = await _appDbContext.Agency.FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public async Task<List<AgencyEntity>> GetByProjectIdAsync(int projectId)
        {
            List<AgencyEntity> entities;

            entities = await _appDbContext.Agency.Where(x => x.ProjectId == projectId && x.IsActive == true).ToListAsync();

            return entities;
        }

        public async Task UpdateAsync(AgencyEntity entity)
        {
            _appDbContext.Agency.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}