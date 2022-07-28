using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Mvc.Api
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AgencyDtoOut item;

            item = await _unitOfWorkBl.Agency.GetAsync((int)id);
            if (item is null)
                return NotFound();
            else
                return Ok(item);
        }


        [HttpGet]
        public async Task<IActionResult> SearchAgency([FromQuery] AgencySearchDtoIn agencySearchDtoIn)
        {
            AgencyListDtoOut agencyListDto;

            agencyListDto = await _unitOfWorkBl.Agency.GetAsync(agencySearchDtoIn);

            return Ok(agencyListDto.ListAgencies);
        }
    }
}