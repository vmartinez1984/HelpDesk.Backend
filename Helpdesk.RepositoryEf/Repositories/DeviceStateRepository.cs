using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.RepositoryEf.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.RepositoryEf.Repositories
{
    public class DeviceStateRepository : IDeviceStateRepository
    {
        private AppDbContext _appDbContext;

        public DeviceStateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<DeviceStateEntity>> GetAsync()
        {
            List<DeviceStateEntity> entities;

            entities = await _appDbContext.DeviceState.Where(x=> x.IsActive == true).ToListAsync();

            return entities;
        }
    }
}