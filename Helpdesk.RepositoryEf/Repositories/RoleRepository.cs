using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.RepositoryEf.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.RepositoryEf.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private AppDbContext _appDbContext;

        public RoleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<RoleEntity>> GetAsync()
        {
            List<RoleEntity> entities;

            entities = await _appDbContext.Role.Where(x=> x.IsActive).ToListAsync();

            return entities;
        }
    }
}