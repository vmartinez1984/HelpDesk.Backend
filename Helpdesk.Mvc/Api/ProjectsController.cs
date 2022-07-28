using Helpdesk.Core.Dtos.Inputs;
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

      
        [Route("/Api/Projects/{id}/Agencies")]
        public async Task<IActionResult> Get(int projectId)
        {
            var response = await _unitOfWorkBl.Agency.GetAsync(new AgencySearchDtoIn
            {
                ProjectId = projectId
            });

            return Ok(response.ListAgencies);
        }

    }
}