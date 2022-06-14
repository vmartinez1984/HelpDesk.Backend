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
            int id;

            id = await _unitOfWorkBl.Agency.AddAsync(item);

            return Ok(new { Id = id });
        }

        [HttpGet("Projects/{projectId}")]
        public async Task<ActionResult> GetByProjectId(int projectId)
        {
            return Ok(await _unitOfWorkBl.Agency.GetListAsync(projectId));
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
        public async Task<IActionResult> Update(int id, AgencyTypeDtoIn item)
        {
            await _unitOfWorkBl.AgencyType.UpdateAsync(item, id);

            return Accepted();
        }
    }
}


//002028650641338820