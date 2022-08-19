using Helpdesk.Core.Dtos;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Mvc.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpdesk.Mvc.Controllers
{
    [Authorize]
    public class DevicesController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public DevicesController(IUnitOfWorkBl unitOfWorkBl)
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

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceDtoIn item)
        {
            item.UserId = SessionHelper.GetNameIdentifier(User);
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Device.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     AgencyDtoOut item;

        //     item = await _unitOfWorkBl.Agency.GetAsync((int)id);
        //     ViewData["ListProjects"] = new SelectList(await _unitOfWorkBl.Project.GetAsync(), "Id", "Name");
        //     ViewData["ListAgencyType"] = new SelectList(await _unitOfWorkBl.AgencyType.GetAsync(), "Id", "Name");
        //     ViewData["ListZipCodes"] = new SelectList(await _unitOfWorkBl.ZipCode.GetAsync(item.ZipCode), "Settement", "Settement");

        //     return View(item);
        // }

        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, AgencyDtoIn item)
        // {
        //     item.UserId = SessionHelper.GetNameIdentifier(User);
        //     if (ModelState.IsValid)
        //     {
        //         await _unitOfWorkBl.Agency.UpdateAsync(item, id);

        //         return RedirectToAction(nameof(Index));
        //     }
        //     else
        //     {
        //         return View();
        //     }
        // }

        // //https://localhost:7018/Api/zipcodes/42950
        // [Route("/Api/Zipcodes/{zipCode}")]
        // public async Task<IActionResult> ZipCodes(string zipCode)
        // {
        //     List<ZipCodeDto> list;

        //     list = await _unitOfWorkBl.ZipCode.GetAsync(zipCode);

        //     return Ok(list);
        // }

        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     AgencyDtoOut item;

        //     item = await _unitOfWorkBl.Agency.GetAsync((int)id);

        //     return View(item);
        // }

        // [HttpPost]
        // public async Task<IActionResult> Delete(AgencyDtoOut item)
        // {
        //     item.UserId = SessionHelper.GetNameIdentifier(User);

        //     await _unitOfWorkBl.Agency.DeleteAsync(item.Id);

        //     return RedirectToAction(nameof(Index));
        // }

        // public async Task<IActionResult> Details(int id)
        // {
        //     AgencyDtoOut item;

        //     item = await _unitOfWorkBl.Agency.GetAsync(id);

        //     return View(item);
        // }

        //Api
        [Route("/Api/Devices/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            DeviceDto deviceDto;

            deviceDto = await _unitOfWorkBl.Device.GetAsync(id);

            return Ok(deviceDto);
        }
    }
}