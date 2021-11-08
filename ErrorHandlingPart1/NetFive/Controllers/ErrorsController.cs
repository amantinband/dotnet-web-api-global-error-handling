using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetFive.Errors;

namespace NetFive.Controllers
{
    public class ErrorsController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorController"/> class.
        /// </summary>
        public ErrorsController(
            IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [Route("/error")]
        public IActionResult HandleError()
        {
            Exception? exception = httpContextAccessor.HttpContext?
                .Features.Get<IExceptionHandlerFeature>()?
                .Error;

            return exception is ServiceException e
                ? Problem(title: e.ErrorMessage, statusCode: e.HttpStatusCode)
                : Problem(title: "An error occurred while processing your request", statusCode: StatusCodes.Status500InternalServerError);
        }
    }

}