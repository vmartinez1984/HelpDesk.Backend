using Helpdesk.Core.Dtos;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Mvc.Api
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ResponsivesController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public ResponsivesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DataTableDto dataTables)
        {
            try
            {
                ResponsivePagerDtoOut response;

                response = await _unitOfWorkBl.Responsive.GetAsync(new SearchDtoIn
                {
                    RecordsPerPage = dataTables.RecordsPerPage,
                    PageCurrent = dataTables.PageCurrent,
                    Search = dataTables.SearchValue,
                    SortColumn = dataTables.SortColumn,
                    SortColumnDir = dataTables.SortColumnDir
                });

                return Ok(new
                {
                    draw = dataTables.Draw,
                    recordsFiltered = response.TotalRecordsFiltered,
                    recordsTotal = response.TotalRecords,
                    data = response.ListResponsive
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }//end class
}