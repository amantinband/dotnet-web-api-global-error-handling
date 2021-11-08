using System;

namespace NetFive.Errors
{
    public abstract class ServiceException : Exception
    {
        public abstract int HttpStatusCode { get; }

        public abstract string ErrorMessage { get; }
    }

}