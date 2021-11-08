using System;
using Microsoft.AspNetCore.Mvc;
using NetFive.Services;

namespace NetFive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            return this.Ok(this.usersService.Get(id));
        }
    }
}