using System;
using NetFive.Models;

namespace NetFive.Services
{
    public interface IUsersService
    {
        User Get(Guid id);
    }
}