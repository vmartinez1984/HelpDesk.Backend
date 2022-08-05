using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Mvc.Api
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

      
        [Route("/Api/Projects/{projectId}/Agencies")]
        public async Task<IActionResult> Get(int projectId)
        {
            List<AgencyDtoOut> list;

            list = await _unitOfWorkBl.Agency.GetByProjectIdAsync(projectId);

            return Ok(list);
        }

    }
}