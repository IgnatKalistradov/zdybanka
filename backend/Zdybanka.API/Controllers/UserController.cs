using Microsoft.AspNetCore.Mvc;
using Zdybanka.Application.Services;

namespace Zdybanka.API.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
}