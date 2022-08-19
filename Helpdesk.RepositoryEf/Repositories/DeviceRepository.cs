using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.RepositoryEf.Contexts;
using Helpdesk.RepositoryEf.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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

        public async Task<List<DeviceEntity>> GetAsync(PagerEntity search)
        {
            List<DeviceEntity> entities;
            IQueryable<DeviceEntity> queryable;

            
            queryable = _appDbContext.Device.Include(x=> x.DeviceState);
            queryable = queryable.Where(x => x.IsActive);
            search.TotalRecords = queryable.Count();
            if (string.IsNullOrEmpty(search.Search) == false)
            {
                queryable = queryable.Where(
                    x => string.Concat(x.Name, x.SerialNumber, x.DateStart, x.DateEnd, x.DeviceState.Name).Contains(search.Search)
                );
            }
            if (string.IsNullOrEmpty(search.SortColumn) == false && string.IsNullOrEmpty(search.SortColumnDir) == false)
            {
                //search.SortColumn = search.SortColumn == "fullName" ? "Person.Name" : search.SortColumn;
                queryable = queryable.OrderBy(search.SortColumn.GetSortColumn() + " " + search.SortColumnDir);
            }
            entities = await queryable
              .Skip((search.PageCurrent - 1) * search.RecordsPerPage)
              .Take(search.RecordsPerPage)
              .ToListAsync();
            search.TotalRecordsFiltered = await queryable.CountAsync();

            return entities;
        }

        public async Task UpdateAsync(DeviceEntity entity)
        {
            _appDbContext.Device.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
        
    }//end class
}