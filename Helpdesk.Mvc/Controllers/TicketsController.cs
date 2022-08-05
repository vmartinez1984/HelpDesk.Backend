using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Mvc.Helpers;
using Tickets.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tickets.Core.Interfaces.IBusinessLayer;

namespace Helpdesk.Mvc.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;
        private IUnitOfWorkTickets _unitOfWorkTickets;

        public TicketsController(
            IUnitOfWorkBl unitOfWorkBl,
            IUnitOfWorkTickets unitOfWorkTickets
        )
        {
            _unitOfWorkBl = unitOfWorkBl;
            _unitOfWorkTickets = unitOfWorkTickets;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");
            ViewData["Categories"] = new SelectList(await _unitOfWorkTickets.Category.GetAsync(),"Id","Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketDtoIn item)
        {
            item.UserId = SessionHelper.GetNameIdentifier(User);
            if (ModelState.IsValid)
            {
                await _unitOfWorkTickets.Ticket.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}