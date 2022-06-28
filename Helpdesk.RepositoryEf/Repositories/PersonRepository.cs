using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.RepositoryEf.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.RepositoryEf.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(PersonEntity entity)
        {
            await _appDbContext.Person.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id, int userId)
        {
            PersonEntity entity;

            entity = await _appDbContext.Person.Where(x => x.Id == id).FirstAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PersonEntity> GetAsync(int id)
        {
            return await _appDbContext.Person.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public Task<List<PersonEntity>> GetAsync(int? projectId, int? agencyId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(PersonEntity entity)
        {
             _appDbContext.Person.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}