using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpdesk.Mvc.Controllers
{
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public PersonsController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // public async Task<IActionResult> Index()
        // {
        //     ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");

        //     List<PersonDtoOut> list;

        //     list = await _unitOfWorkBl.Person.GetAsync(projectId, agencyId);

        //     return View(list);
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}