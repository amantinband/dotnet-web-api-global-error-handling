using Microsoft.AspNetCore.Diagnostics;
using NetSix.Errors.ErrorPropertiesFactory;
using NetSix.Errors.Exceptions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IErrorPropertiesFactory, ErrorPropertiesFactory>();

var app = builder.Build();

app.MapGet("/users/{id:guid}", (Guid id) => { throw new UserExistsException(); });

app.UseExceptionHandler("/error");

app.Map("/error", (IHttpContextAccessor httpContextAccessor, IErrorPropertiesFactory errorPropertiesFactory) =>
{
    Exception? exception = httpContextAccessor.HttpContext?
        .Features.Get<IExceptionHandlerFeature>()?
        .Error;

    var commonErrorProperties = errorPropertiesFactory.CreateCommonProperties();

    return exception is ServiceException e
        ? Results.Problem(
            title: e.ErrorMessage,
            statusCode: e.HttpStatusCode,
            extensions: commonErrorProperties)
        : Results.Problem(
            title: "An error occurred while processing your request.",
            statusCode: StatusCodes.Status500InternalServerError,
            extensions: commonErrorProperties);
});

app.Run();

