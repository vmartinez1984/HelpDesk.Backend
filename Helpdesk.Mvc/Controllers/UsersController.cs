using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

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

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}