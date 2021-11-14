using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.MapGet("/users/{id:guid}", (Guid id) => { throw new UserExistsException(); });

app.UseExceptionHandler("/error");

app.Map("/error", (IHttpContextAccessor httpContextAccessor) =>
{
    Exception? exception = httpContextAccessor.HttpContext?
        .Features.Get<IExceptionHandlerFeature>()?
        .Error;

    var customProperties = new Dictionary<string, object?>
    {
        { "myCustomProperty", "myCustomPropertyValue"}
    };

    return exception is ServiceException e
        ? Results.Problem(
            title: e.ErrorMessage,
            statusCode: e.HttpStatusCode,
            extensions: customProperties)
        : Results.Problem(
            title: "An error occurred while processing your request.",
            statusCode: StatusCodes.Status500InternalServerError,
            extensions: customProperties);
});

app.Run();

abstract class ServiceException : Exception
{
    public abstract int HttpStatusCode { get; }
    public abstract string ErrorMessage { get; }
}

class UserExistsException : ServiceException
{
    public override int HttpStatusCode => StatusCodes.Status409Conflict;
    public override string ErrorMessage => "User already exists.";
}