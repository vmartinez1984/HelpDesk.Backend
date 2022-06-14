using Helpdesk.Core.Entities;
using Helpdesk.RepositoryEf.Contexts;
using Helpdesk.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.RepositoryEf.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> AddAsync(UserEntity entity)
        {
            await _appDbContext.User.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id, int userId)
        {
            UserEntity entity;

            entity = await _appDbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<UserEntity>> GetAsync()
        {
            List<UserEntity> entities;

            entities =  await _appDbContext.User.Where(x => x.IsActive).ToListAsync();

            return entities;
        }

        public async Task<UserEntity> GetAsync(int id)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task UpdateAsync(UserEntity entity)
        {
            _appDbContext.User.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}