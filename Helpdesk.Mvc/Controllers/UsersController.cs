using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Mvc.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpdesk.Mvc.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public UsersController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        public async Task<IActionResult> Index(UserSearchDtoIn userSearch)
        {
            UserListDtoOut userListDtoOut;
            
            userListDtoOut = await _unitOfWorkBl.User.GetAsync(userSearch);
            ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");
            //ViewData["ListAgencies"] = new SelectList(await _unitOfWorkBl.Agency.GetByProjectIdAsync(item.ProjectId), "Id", "Name");

            return View(userListDtoOut);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");
            ViewData["ListRoles"] = new SelectList(await _unitOfWorkBl.Role.GetAsync(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDtoIn user)        
        {
            user.UserId = SessionHelper.GetNameIdentifier(User);
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.User.AddAsync(user);

                return RedirectToAction(nameof(Index));
            }

            ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");
            //ViewData["ListAgencies"] = new SelectList(await _unitOfWorkBl.Agency.GetByAsync(user.AgencyId), "Id", "Name");
            ViewData["ListRoles"] = new SelectList(await _unitOfWorkBl.Role.GetAsync(), "Id", "Name");

            return View(user);
        }

        public async Task<IActionResult> Details(int id)
        {
            UserDtoOut item;

            item = await _unitOfWorkBl.User.GetAsync(id);

            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            UserDtoOut item;

            item = await _unitOfWorkBl.User.GetAsync(id);
            ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");
            ViewData["ListAgencies"] = new SelectList(await _unitOfWorkBl.Agency.GetByProjectIdAsync(item.ProjectId), "Id", "Name");
            ViewData["ListRoles"] = new SelectList(await _unitOfWorkBl.Role.GetAsync(), "Id", "Name");

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDtoOut item)
        {
            await _unitOfWorkBl.User.UpdateAsync(item);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            UserDtoOut item;

            item = await _unitOfWorkBl.User.GetAsync(id);

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserDtoOut item)
        {
            await _unitOfWorkBl.User.DeleteAsync(item.Id);

            return RedirectToAction(nameof(Index));
        }
    }
}