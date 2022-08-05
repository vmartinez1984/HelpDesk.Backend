using Helpdesk.Core.Dtos;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Mvc.Api
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DataTableDto dataTablesIn)
        {
            try
            {
                PersonPagerDtoOut response;

                response = await _unitOfWorkBl.Person.GetAsync(new SearchDtoIn
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
                    data = response.ListPersons
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }//end class
}