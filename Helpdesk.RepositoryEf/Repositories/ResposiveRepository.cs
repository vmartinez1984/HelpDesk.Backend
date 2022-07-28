using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.RepositoryEf.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.RepositoryEf.Repositories
{
    public class ResposiveRepository : IResponsiveRepository
    {
        private AppDbContext _appDbContext;

        public ResposiveRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(ResponsiveEntity entity)
        {
            await _appDbContext.Responsive.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsWithoutSendAsync()
        {
            bool exists;

            exists = await _appDbContext.Responsive.Where(x => x.DateSend == null).CountAsync() == 0 ? false : true;

            return exists;
        }

        public async Task<ResponsiveEntity> GetAsync(int id)
        {
            ResponsiveEntity entity;

            entity = await _appDbContext.Responsive.Where(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<ResponsiveEntity> GetAsync(string documentId)
        {
            ResponsiveEntity entity;

            entity = await _appDbContext.Responsive.Where(x => x.DocumentId == documentId).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<ResponsiveEntity> GetWithoutSendAsync()
        {
            ResponsiveEntity entity;

            entity = await _appDbContext.Responsive.Where(x => x.DateSend == null).FirstOrDefaultAsync();

            return entity;
        }

        public async Task UpdateAsync(ResponsiveEntity entity)
        {
             _appDbContext.Responsive.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}