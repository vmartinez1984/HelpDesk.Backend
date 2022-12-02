using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Heldesk.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProjectsController : ControllerBase
    {        
        private IUnitOfWorkBl _unitOfWorkBl;

        public ProjectsController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool isActivate = true)
        {
            return Ok(await _unitOfWorkBl.Project.GetAsync(isActivate));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProjectDtoIn item)
        {
            int id;

            id = await _unitOfWorkBl.Project.AddAsync(item);

            return Ok(new { Id = id });
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ProjectDtoIn item)
        {
            await _unitOfWorkBl.Project.UpdateAsync(item, id);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){

            await _unitOfWorkBl.Project.DeleteAsync(id);

            return NoContent();
        }
    }
}