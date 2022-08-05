using Microsoft.AspNetCore.Mvc;
using Tickets.Core.Dtos;
using Tickets.Core.Interfaces.IBusinessLayer;

namespace Helpdesk.Mvc.Api
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CategoriesController : ControllerBase
    {
       private IUnitOfWorkTickets _unitOfWorkTickets;

        public CategoriesController(IUnitOfWorkTickets unitOfWorkTickets)
        {
            _unitOfWorkTickets = unitOfWorkTickets;
        }

        [HttpGet("/Api/Categories/{categoryId}/Subcategories")]
        public async Task<IActionResult> Get(string categoryId)
        {
            List<SubcategoryDto> list;

            list = await _unitOfWorkTickets.Subcategory.GetByCategoryAsync(categoryId);

            return Ok(list);
        }      
    }
}