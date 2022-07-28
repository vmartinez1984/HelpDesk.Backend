using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Mvc.Api
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ZipCodesController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public ZipCodesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

      
        //https://localhost:7018/Api/zipcodes/42950
        [Route("/Api/Zipcodes/{zipCode}")]
        public async Task<IActionResult> ZipCodes(string zipCode)
        {
            List<ZipCodeDto> list;

            list = await _unitOfWorkBl.ZipCode.GetAsync(zipCode);

            return Ok(list);
        }

    }
}