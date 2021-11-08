using System;
using NetSix.Models;

namespace NetSix.Services;

public interface IUsersService
{
    User Get(Guid id);
}
