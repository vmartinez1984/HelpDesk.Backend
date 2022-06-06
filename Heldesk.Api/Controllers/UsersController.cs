﻿using Helpdesk.Core.Interfaces.InterfaceBl;
using Microsoft.AspNetCore.Mvc;

namespace Heldesk.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public UsersController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWorkBl.User.GetAsync());
        }
    }
}