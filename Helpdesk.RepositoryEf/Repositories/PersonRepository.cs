using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.RepositoryEf.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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

        public async Task<List<PersonEntity>> GetAsync(PagerEntity search)
        {
            List<PersonEntity> list;
            IQueryable<PersonEntity> queryable;

            queryable = _appDbContext.Person.Include(x => x.Agency);
            queryable = queryable.Where(x => x.IsActive);
            search.TotalRecords = queryable.Count();
            if (string.IsNullOrEmpty(search.Search) == false)
                queryable = queryable.Where(
                    x => string.Concat(x.Name, x.LastName, x.Agency.Name, x.Agency.Code).Contains(search.Search)
                );
            if (string.IsNullOrEmpty(search.SortColumn) == false && string.IsNullOrEmpty(search.SortColumnDir) == false)
            {
                queryable = queryable.OrderBy(char.ToUpper(search.SortColumn[0]) + search.SortColumn.Substring(1) + " " + search.SortColumnDir);
            }
            var query = queryable.ToString();
            list = await queryable
            .Skip((search.PageCurrent - 1) * search.RecordsPerPage)
            .Take(search.RecordsPerPage)
            .ToListAsync();
            search.TotalRecordsFiltered = await queryable.CountAsync();

            return list;
        }

        public async Task UpdateAsync(PersonEntity entity)
        {
            _appDbContext.Person.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}