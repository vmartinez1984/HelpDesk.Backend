using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Mvc.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpdesk.Mvc.Controllers
{
    public class UsersController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public UsersController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        public async Task<IActionResult> Index(int? projectId, int? agencyId)
        {
            UserListDtoOut userListDtoOut;

            userListDtoOut = new UserListDtoOut();
            userListDtoOut.ListUsers = await _unitOfWorkBl.User.GetAsync(projectId, agencyId);

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
        //public async Task<IActionResult> Create(Helpdesk.Dtos.Inputs.UserDtoIn user1)
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
    }
}