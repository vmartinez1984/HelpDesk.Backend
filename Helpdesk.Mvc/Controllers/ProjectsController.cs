using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Mvc.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Mvc.Controllers
{
    public class ProjectsController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public ProjectsController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = SessionHelper.GetNameIdentifier(User);
            List<ProjectDtoOut> list;

            list = await _unitOfWorkBl.Project.GetAsync();

            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectDtoOut item;

            item = await _unitOfWorkBl.Project.GetAsync((int)id);

            return View(item);
        }

        [Authorize]
        public IActionResult Create()
        {

            return View();
        }        

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectDtoIn item)
        {
            item.UserId = SessionHelper.GetNameIdentifier(User);
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Project.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
                 
        [Authorize]      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectDtoOut item;

            item = await _unitOfWorkBl.Project.GetAsync((int)id);

            return View(item);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectDtoIn item)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Project.UpdateAsync(item, id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectDtoOut item;

            item = await _unitOfWorkBl.Project.GetAsync((int)id);

            return View(item);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(ProjectDtoOut item)
        {
            await _unitOfWorkBl.Project.DeleteAsync(item.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}