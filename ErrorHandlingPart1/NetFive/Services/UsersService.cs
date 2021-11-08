using System;
using NetFive.Errors;
using NetFive.Models;

namespace NetFive.Services
{
    class UsersService : IUsersService
    {
        public User Get(Guid id)
        {
            throw new UserNotFoundException();
        }
    }
}