using Tickets.Core.Dtos;

namespace Tickets.Core.Interfaces.IBusinessLayer
{
    public interface ICategoryBl
    {
        Task<List<CategoryDto>> GetAsync();
    }
    
    public interface IStateBl
    {
        Task<List<StateDto>> GetAsync();
    }

    public interface ISubcategoryBl
    {
        Task<List<SubcategoryDto>> GetAsync();
        
        Task<List<SubcategoryDto>> GetByCategoryAsync(string categoryId);
    }
}