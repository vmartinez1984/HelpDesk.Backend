using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Mvc.bin
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ZipCodesController //: ControllerBase
    {
        private readonly ILogger<ZipCodesController> _logger;

        public ZipCodesController(ILogger<ZipCodesController> logger)
        {
            _logger = logger;
        }

       // [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}