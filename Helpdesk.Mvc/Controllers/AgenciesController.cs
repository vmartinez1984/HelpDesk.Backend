using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpdesk.Mvc.Controllers
{
    public class AgenciesController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public AgenciesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        public async Task<IActionResult> Index(int? projectId)
        {
            List<AgencyDtoOut> list;

            list = await _unitOfWorkBl.Agency.GetListAsync(projectId);

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");
            ViewData["ListAgencyType"] = new SelectList(await _unitOfWorkBl.AgencyType.GetAsync(), "Id", "Name");

            return View();
        }

        //https://localhost:7018/Api/zipcodes/42950
        [Route("/Api/Zipcodes/{zipCode}")]
        public async Task<IActionResult> ZipCodes(string zipCode)
        {
            List<ZipCodeDto> list;

            list = await _unitOfWorkBl.ZipCode.GetAsync(zipCode);

            return Ok(list);
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}