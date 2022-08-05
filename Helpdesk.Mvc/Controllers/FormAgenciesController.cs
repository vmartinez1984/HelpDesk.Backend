using Helpdesk.Core.Dtos;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Mvc.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;

namespace Helpdesk.Mvc.Controllers
{
    [Authorize]
    public class FormAgenciesController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public FormAgenciesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");
            ViewData["ListAgencyType"] = new SelectList(await _unitOfWorkBl.AgencyType.GetAsync(), "Id", "Name");
            ViewData["ListDevices"] = new SelectList((await _unitOfWorkBl.Device.GetAsync(new DeviceSearchDtoIn { })).ListDevices, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormAgencyDtoIn item)
        {
            item.UserId = SessionHelper.GetNameIdentifier(User);
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.FormAgency.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [AllowAnonymous]
        [Route("/FormAgencies/{id}/Register/")]
        public async Task<IActionResult> Register(string id)
        {
            FormAgencyDto dto;

            dto = await _unitOfWorkBl.FormAgency.GetAsync(id);

            return View(dto);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ConfirmRegister(FormAgencyRegisterDtoIn item)
        {
            FormAgencyDto dto;

            dto = await _unitOfWorkBl.FormAgency.GetAsync(item.FormAgencyId);
            dto.Person = item.Person;

            return new ViewAsPdf(dto);
        }
    }
}