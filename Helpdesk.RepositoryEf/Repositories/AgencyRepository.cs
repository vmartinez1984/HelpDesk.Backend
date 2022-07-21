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

        public async Task<AgencySearchEntityOut> GetAsync(AgencySearchEntity search)
        {
            List<AgencyEntity> list;
            IQueryable<AgencyEntity> queryable;
            AgencySearchEntityOut agencySearchEntityOut;
            
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
            if (!string.IsNullOrEmpty(search.Code))
            {
                queryable = queryable.Where(x => x.Code.ToUpper().Contains(search.Code.ToUpper()));
            }
            list = await queryable
            .OrderByDescending(x => x.Id)
            .Skip((search.PageCurrent - 1) * search.RecordsPerPage)
            .Take(search.RecordsPerPage)
            .ToListAsync();
            search.TotalRecords = await queryable.CountAsync();
            agencySearchEntityOut = new AgencySearchEntityOut
            {

                Code = search.Code,
                Name = search.Name,
                ProjectId = search.ProjectId,
                PageCurrent = search.PageCurrent,
                RecordsPerPage = search.RecordsPerPage,
                TotalRecords = search.TotalRecords,
                ListAgencies = list
            };

            return agencySearchEntityOut;
        }

        public async Task<AgencyEntity> GetAsync(int id)
        {
            return await _appDbContext.Agency.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AgencyEntity>> GetByProjectIdAsync(int projectId)
        {
            List<AgencyEntity> entities;

            entities = await _appDbContext.Agency.Where(x=> x.ProjectId == projectId && x.IsActive == true).ToListAsync();
            
            return entities;
        }

        public async Task UpdateAsync(AgencyEntity entity)
        {
            _appDbContext.Agency.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}