using Heldesk.Api.Helpers;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Heldesk.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public UsersController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserSearchDtoIn userSearch)
        {
            UserListDtoOut item;

            item = await _unitOfWorkBl.User.GetAsync(userSearch);
            HttpContext.AddHeaderTotalRecords(item.TotalRecords);

            return Ok(item.ListUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _unitOfWorkBl.User.GetAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserDtoIn item)
        {
            await _unitOfWorkBl.User.UpdateAsync(item, id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDtoIn item)
        {
            int id;

            id = await _unitOfWorkBl.User.AddAsync(item);

            return Created($"/Api/Users/{id}", new { Id = id });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWorkBl.User.DeleteAsync(id);

            return Accepted();
        }
    }
}
