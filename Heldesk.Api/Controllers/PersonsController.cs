using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Heldesk.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public PersonsController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PersonDtoIn item)
        {
            int id;

            id = await _unitOfWorkBl.Person.AddAsync(item);

            return Ok(new { Id = id });
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _unitOfWorkBl.AgencyType.GetAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWorkBl.AgencyType.DeleteAsync(id);

            return Accepted();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, AgencyTypeDtoIn item){
            await _unitOfWorkBl.AgencyType.UpdateAsync(item, id);

            return Accepted();
        }
    }
}