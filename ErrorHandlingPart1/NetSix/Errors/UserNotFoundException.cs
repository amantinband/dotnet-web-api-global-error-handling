using Microsoft.AspNetCore.Http;

namespace NetSix.Errors;

public class UserNotFoundException : ServiceException
{
    public override int HttpStatusCode => StatusCodes.Status404NotFound;

    public override string ErrorMessage => "The given user id doesn't exist.";
}
