using System.Security.Claims;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public LoginController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto login)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index", login);
            }

            UserDtoOut user;

            user = await _unitOfWorkBl.User.Login(login);
            if (user is null)
            {
                ViewBag.Error = "Usuario y/o contraseña erroneos";
                return View();
            }
            else
            {

                //Registrar la autenticación                
                ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
        }

        private IEnumerable<Claim> GetUserClaims(UserDtoOut user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            //claims.Add(new Claim(ClaimTypes.Email, user.UserEmail));
            //claims.AddRange(this.GetUserRoleClaims(user));
            return claims;
        }

        // private IEnumerable<Claim> GetUserRoleClaims(UserDbModel user)
        // {
        //     List<Claim> claims = new List<Claim>();

        //     claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id().ToString()));
        //     claims.Add(new Claim(ClaimTypes.Role, user.UserPermissionType.ToString()));
        //     return claims;
        // }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("Index");
        }
    }
}