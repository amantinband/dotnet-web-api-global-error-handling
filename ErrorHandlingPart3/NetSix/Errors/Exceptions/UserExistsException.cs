namespace NetSix.Errors.Exceptions;

class UserExistsException : ServiceException
{
    public override int HttpStatusCode => StatusCodes.Status409Conflict;
    public override string ErrorMessage => "User already exists.";
}