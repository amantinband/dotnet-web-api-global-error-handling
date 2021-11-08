using Microsoft.AspNetCore.Diagnostics;
using NetSix.Errors;
using NetSix.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUsersService, UsersService>();

var app = builder.Build();

app.UseExceptionHandler("/error");

app.MapGet("users/{id}", (Guid id, IUsersService usersService) => usersService.Get(id));

app.Map("/error", (IHttpContextAccessor httpContextAccessor) =>
{
    Exception? exception = httpContextAccessor.HttpContext?
        .Features.Get<IExceptionHandlerFeature>()?
        .Error;

    return exception is ServiceException e
        ? Results.Problem(title: e.ErrorMessage, statusCode: e.HttpStatusCode)
        : Results.Problem(title: "An error occurred while processing your request", statusCode: StatusCodes.Status500InternalServerError);
});

app.Run();
