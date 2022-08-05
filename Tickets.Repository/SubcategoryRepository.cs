using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.Repository
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        public Task<List<SubcategoryEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubcategoryEntity> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SubcategoryEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}