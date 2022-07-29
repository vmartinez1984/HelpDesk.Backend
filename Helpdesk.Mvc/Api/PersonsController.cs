using Helpdesk.Core.Dtos.Inputs;
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
        public async Task<IActionResult> Get()
        {
            try
            {

                var query = Request.Query;
                var draw = Request.Query["draw"].FirstOrDefault();
                var start = Request.Query["start"].FirstOrDefault();
                var length = Request.Query["length"].FirstOrDefault();
                var sortColumn = Request.Query["columns[" + Request.Query["order[0][column]"].FirstOrDefault() + "][data]"].FirstOrDefault();
                var sortColumnDir = Request.Query["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Query["search[value]"].FirstOrDefault();
                var pageSize = length == null ? 0 : Convert.ToInt32(length);
                var skip = start == null ? 0 : Convert.ToInt32(start);
                sortColumn = sortColumn == "agencyName"? "Agency.Name": sortColumn;

                PersonPagerDtoOut response = await _unitOfWorkBl.Person.GetAsync(new PersonSearchDtonIn
                {
                    RecordsPerPage = pageSize,
                    PageCurrent = skip + 1,
                    Search = searchValue,
                    SortColumn = sortColumn,
                    SortColumnDir = sortColumnDir
                });

                return Ok(new
                {
                    draw = draw,
                    recordsFiltered = response.PersonSearch.TotalRecordsFiltered,
                    recordsTotal = response.PersonSearch.TotalRecords,
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