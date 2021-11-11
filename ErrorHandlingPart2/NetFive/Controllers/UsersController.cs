using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetFive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            return this.Problem(
                title: "The given user id doesn't exist.",
                 statusCode: StatusCodes.Status404NotFound);
        }
    }
}