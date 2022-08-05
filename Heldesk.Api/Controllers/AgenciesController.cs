using Helpdesk.Core.Dtos;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Heldesk.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AgenciesController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public AgenciesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpPost]
        public async Task<ActionResult> Post(AgencyDtoIn item)
        {
            var agencyType = await _unitOfWorkBl.AgencyType.GetAsync(item.AgencyTypeId);
            if(agencyType is null){
                ModelState.AddModelError(nameof(item.AgencyTypeId),"The agencyTypeId is not valid");
                return Conflict(ModelState);
            }
            var user = await _unitOfWorkBl.User.GetAsync(item.UserId);
            if(user is null){
                ModelState.AddModelError("UserId","ThisuserId is not valid");
                return Conflict(ModelState);
            }
            int id;

            id = await _unitOfWorkBl.Agency.AddAsync(item);

            return Ok(new { Id = id });
        }

        [HttpGet]
        public async Task<ActionResult> GetByProjectId([FromQuery] SearchDtoIn searchDto)
        {
            return Ok(await _unitOfWorkBl.Agency.GetAsync(searchDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _unitOfWorkBl.Agency.GetAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWorkBl.AgencyType.DeleteAsync(id);

            return Accepted();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, AgencyDtoIn item)
        {
            var agencyType = await _unitOfWorkBl.AgencyType.GetAsync(item.AgencyTypeId);
            if(agencyType is null){
                ModelState.AddModelError(nameof(item.AgencyTypeId),"The agencyTypeId is not valid");
                return Conflict(ModelState);
            }
            var user = await _unitOfWorkBl.User.GetAsync(item.UserId);
            if(user is null){
                ModelState.AddModelError("UserId","The userId is not valid");
                return Conflict(ModelState);
            }

            await _unitOfWorkBl.Agency.UpdateAsync(item, id);

            return Accepted();
        }
    }
}