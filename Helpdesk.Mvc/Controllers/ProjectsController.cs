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
        public async Task<IActionResult> Index(bool isActivate = true)
        {
            var userId = SessionHelper.GetNameIdentifier(User);
            List<ProjectDtoOut> list;

            list = await _unitOfWorkBl.Project.GetAsync(isActivate);
            ViewBag.IsActivate = isActivate;

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
            ProjectDeleteDtoIn projectDeleteDtoIn;

            item = await _unitOfWorkBl.Project.GetAsync((int)id);
            projectDeleteDtoIn = new ProjectDeleteDtoIn
            {
                DateRegistration = item.DateRegistration,
                Id = item.Id,
                Name = item.Name,
                Notes = item.Notes,
                UserId = item.UserId
            };

            return View(projectDeleteDtoIn);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(ProjectDeleteDtoIn item)
        {
            if (ModelState.IsValid)
            {
                item.DeleteUserId = SessionHelper.GetNameIdentifier(User);
                await _unitOfWorkBl.Project.DeleteAsync(item);

                return RedirectToAction(nameof(Index));
            }


            ProjectDeleteDtoIn projectDeleteDtoIn;

            var item1 = await _unitOfWorkBl.Project.GetAsync(item.Id);
            projectDeleteDtoIn = new ProjectDeleteDtoIn
            {
                DateRegistration = item.DateRegistration,
                Id = item1.Id,
                Name = item1.Name,
                Notes = item1.Notes,
                UserId = item1.UserId
            };

            return View(projectDeleteDtoIn);
        }

        [Authorize]
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjectDtoOut item;
            ProjectDeleteDtoIn projectDeleteDtoIn;

            item = await _unitOfWorkBl.Project.GetAsync((int)id);
            projectDeleteDtoIn = new ProjectDeleteDtoIn
            {
                DateRegistration = item.DateRegistration,
                Id = item.Id,
                Name = item.Name,
                Notes = item.Notes,
                UserId = item.UserId
            };

            return View(projectDeleteDtoIn);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Activate(ProjectDeleteDtoIn item)
        {
            if (ModelState.IsValid)
            {
                item.DeleteUserId = SessionHelper.GetNameIdentifier(User);
                await _unitOfWorkBl.Project.ActivateAsync(item);

                return RedirectToAction(nameof(Index));
            }


            ProjectDeleteDtoIn projectDeleteDtoIn;

            var item1 = await _unitOfWorkBl.Project.GetAsync(item.Id);
            projectDeleteDtoIn = new ProjectDeleteDtoIn
            {
                DateRegistration = item.DateRegistration,
                Id = item1.Id,
                Name = item1.Name,
                Notes = item1.Notes,
                UserId = item1.UserId
            };

            return View(projectDeleteDtoIn);
        }
    }
}