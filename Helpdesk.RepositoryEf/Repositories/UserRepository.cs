using Helpdesk.Core.Entities;
using Helpdesk.RepositoryEf.Contexts;
using Helpdesk.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Helpdesk.RepositoryEf.Utilities;
using System.Linq.Dynamic.Core;

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

        public async Task<bool> ExistsAsync(string email, int? userId)
        {
            bool exists;

            if (userId == 0 || userId is null)
                exists = await _appDbContext.User.CountAsync(x => x.Email == email) == 0 ? false : true;
            else
                exists = await _appDbContext.User.CountAsync(x => x.Email == email && x.Id != userId) == 0 ? false : true;

            return exists;
        }

        public async Task<List<UserEntity>> GetAsync(UserSearchEntity search)
        {
            List<UserEntity> list;
            IQueryable<UserEntity> queryable;

            queryable = _appDbContext.User.Include(x => x.Person);
            queryable = queryable.Where(x => x.IsActive);
            if (search.ProjectId is not null)
            {
                queryable = queryable.Where(x => x.Person.Agency.ProjectId == search.ProjectId);
            }
            if (search.ProjectId is not null)
            {
                queryable = queryable.Where(x => x.Person.AgencyId == search.AgencyId);
            }
            if (!string.IsNullOrEmpty(search.UserEmail))
            {
                queryable = queryable.Where(x => x.Email.ToUpper().Contains(search.UserEmail.ToUpper()));
            }

            list = await queryable
            .OrderByDescending(x => x.Id)
            .Skip((search.PageCurrent - 1) * search.RecordsPerPage)
            .Take(search.RecordsPerPage)
            .ToListAsync();
            search.TotalRecords = await queryable.CountAsync();

            return list;
        }

        public async Task<UserEntity> GetAsync(int id)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserEntity> GetAsync(string userName)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(x => x.Email == userName);
        }

        public async Task<List<UserEntity>> GetAsync(PagerEntity search)
        {
            List<UserEntity> list;
            IQueryable<UserEntity> queryable;

            queryable = _appDbContext.User.Include(x => x.Person);
            queryable = queryable.Where(x => x.IsActive);
            search.TotalRecords = queryable.Count();
            if (string.IsNullOrEmpty(search.Search) == false)
            {
                queryable = queryable.Where(
                    x => string.Concat(x.Email, x.Person.Name).Contains(search.Search)
                );
            }
            if (string.IsNullOrEmpty(search.SortColumn) == false && string.IsNullOrEmpty(search.SortColumnDir) == false)
            {
                search.SortColumn = search.SortColumn == "fullName" ? "Person.Name" : search.SortColumn;
                queryable = queryable.OrderBy(search.SortColumn.GetSortColumn() + " " + search.SortColumnDir);
            }
            list = await queryable
              .Skip((search.PageCurrent - 1) * search.RecordsPerPage)
              .Take(search.RecordsPerPage)
              .ToListAsync();
            search.TotalRecordsFiltered = await queryable.CountAsync();

            return list;
        }

        public async Task<string> GetNameAsync(int userId)
        {
            UserEntity userEntity;
            PersonEntity personEntity;

            userEntity = await GetAsync(userId);
            personEntity = await _appDbContext.Person.Where(x => x.Id == userEntity.PersonId).FirstAsync();

            return $"{personEntity.Name} {personEntity.LastName}";
        }

        public async Task UpdateAsync(UserEntity entity)
        {
            _appDbContext.User.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}