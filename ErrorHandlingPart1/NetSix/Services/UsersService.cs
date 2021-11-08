using System;
using NetSix.Errors;
using NetSix.Models;

namespace NetSix.Services;

class UsersService : IUsersService
{
    public User Get(Guid id)
    {
        throw new UserNotFoundException();
    }
}
