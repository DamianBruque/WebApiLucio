
using Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Controllers;

[ApiController]
[Route("/user")]
//[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService service;
    public UserController(IUserService userService)
    {
        service = userService;
    }
    
}
