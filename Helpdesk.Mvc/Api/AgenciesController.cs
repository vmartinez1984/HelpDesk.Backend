using Helpdesk.Core.Dtos;
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
        public async Task<IActionResult> SearchAgency([FromQuery] DataTableDto dataTablesIn)
        {
            AgencyListDtoOut response;

            response = await _unitOfWorkBl.Agency.GetAsync(new SearchDtoIn
            {
                RecordsPerPage = dataTablesIn.RecordsPerPage,
                PageCurrent = dataTablesIn.PageCurrent,
                Search = dataTablesIn.SearchValue,
                SortColumn = dataTablesIn.SortColumn,
                SortColumnDir = dataTablesIn.SortColumnDir
            });

            return Ok(new
            {
                draw = dataTablesIn.Draw,
                recordsFiltered = response.TotalRecordsFiltered,
                recordsTotal = response.TotalRecords,
                data = response.ListAgencies
            });
        }

        [HttpGet]
        [Route("/Api/Agencies/{agencyId}/Persons")]
        public async Task<IActionResult> GetPersons(int agencyId)
        {
            List<PersonDtoOut> list;

            list = await _unitOfWorkBl.Person.GetByAgencyAsync(agencyId);

            return Ok(list);
        }
    }
}