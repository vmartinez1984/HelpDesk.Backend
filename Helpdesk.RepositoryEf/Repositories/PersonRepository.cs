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
            return await _appDbContext.Person.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PersonPagerEntity> SearchAsync(PersonSearchEntity search)
        {
            List<PersonEntity> list;
            IQueryable<PersonEntity> queryable;
            PersonPagerEntity personPagerEntity;

            queryable = _appDbContext.Person.Include(x => x.Agency);
            queryable = queryable.Where(x => x.IsActive);
            if (search.ProjectId is not null)
            {
                queryable = queryable.Where(x => x.Agency.ProjectId == search.ProjectId);
            }
            if (search.AgencyId is not null)
            {
                queryable = queryable.Where(x => x.AgencyId == search.AgencyId);
            }
            if (!string.IsNullOrEmpty(search.PersonName))
            {
                queryable = queryable.Where(x => x.Name.ToUpper().Contains(search.PersonName.ToUpper()));
            }
            list = await queryable
            .OrderByDescending(x => x.Id)
            .Skip((search.PageCurrent - 1) * search.RecordsPerPage)
            .Take(search.RecordsPerPage)
            .ToListAsync();
            search.TotalRecords = await queryable.CountAsync();
            personPagerEntity = new PersonPagerEntity
            {
                ListPersons = list,
                PersonSearch = search
            };

            return personPagerEntity;
        }

        public async Task UpdateAsync(PersonEntity entity)
        {
            _appDbContext.Person.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}