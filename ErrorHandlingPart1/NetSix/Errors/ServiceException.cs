using System;

namespace NetSix.Errors;

public abstract class ServiceException : Exception
{
    public abstract int HttpStatusCode { get; }

    public abstract string ErrorMessage { get; }
}
