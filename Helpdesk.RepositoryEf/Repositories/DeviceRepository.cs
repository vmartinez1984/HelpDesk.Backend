using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.RepositoryEf.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.RepositoryEf.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private AppDbContext _appDbContext;

        public DeviceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(DeviceEntity entity)
        {
            await _appDbContext.Device.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<DeviceEntity> GetAsync(int id)
        {
            DeviceEntity entity;

            entity = await _appDbContext.Device.Where(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<List<DeviceEntity>> GetAsync(DeviceSearchEntity search)
        {
            List<DeviceEntity> entities;
            IQueryable<DeviceEntity> queryable;

            queryable = _appDbContext.Device;
            queryable = queryable.Where(x => x.IsActive);
            // if (search.ProjectId is not null)
            // {
            //     queryable = queryable.Where(x => x.ProjectId == search.ProjectId);
            // }
            // if (search.AgencyId is not null)
            // {
            //     queryable = queryable.Where(x => x. == search.ProjectId);
            // }
            if (!string.IsNullOrEmpty(search.Name))
            {
                queryable = queryable.Where(x => x.Name.ToUpper().Contains(search.Name.ToUpper()));
            }
            if (!string.IsNullOrEmpty(search.SerialNumber))
            {
                queryable = queryable.Where(x => x.SerialNumber.ToUpper().Contains(search.SerialNumber.ToUpper()));
            }
            entities = await queryable
            .OrderByDescending(x => x.Id)
            .Skip((search.PageCurrent - 1) * search.RecordsPerPage)
            .Take(search.RecordsPerPage)
            .ToListAsync();
            search.TotalRecords = await queryable.CountAsync();

            return entities;
        }

        public async Task UpdateAsync(DeviceEntity entity)
        {
            _appDbContext.Device.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
        
    }//end class
}