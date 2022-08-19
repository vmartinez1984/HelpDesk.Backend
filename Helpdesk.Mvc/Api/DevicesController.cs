using Helpdesk.Core.Dtos;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Mvc.Api
{
    [ApiController]
    [Route("Api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public DevicesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DataTableDto dataTablesIn)
        {
            try
            {
                PagerDtoOut response;

                response = await _unitOfWorkBl.Device.GetAsync(new SearchDtoIn
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
                    data = response.List
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }//end class
}