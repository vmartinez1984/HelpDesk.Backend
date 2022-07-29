using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Mvc.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpdesk.Mvc.Controllers
{    
    public class PersonsController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public PersonsController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        public async Task<IActionResult> Index([FromQuery] PersonSearchDtonIn personSearch)
        {

            PersonPagerDtoOut personPagerDtoOut;

            personPagerDtoOut = await _unitOfWorkBl.Person.GetAsync(personSearch);
            ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");            

            //return View(personPagerDtoOut);
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonDtoIn person)
        {
            person.UserId = SessionHelper.GetNameIdentifier(User);

            await _unitOfWorkBl.Person.AddAsync(person);

            return RedirectToAction(nameof(Index));
            
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}