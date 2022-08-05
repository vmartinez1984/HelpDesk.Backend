using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task UpdateAsync(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryEntity> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}