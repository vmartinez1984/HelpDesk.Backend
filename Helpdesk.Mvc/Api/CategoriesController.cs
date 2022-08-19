using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;
using Tickets.Core.Dtos;

namespace Helpdesk.Mvc.Api
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CategoriesController : ControllerBase
    {
       private IUnitOfWorkBl _unitOfWorkBl;

        public CategoriesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet("{categoryId}/Subcategories")]
        public async Task<IActionResult> Get(string categoryId)
        {
            List<SubcategoryDto> list;

            list = await _unitOfWorkBl.Subcategory.GetByCategoryAsync(categoryId);

            return Ok(list);
        }      
    }
}