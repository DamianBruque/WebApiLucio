
using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Utilities.Exceptions;

namespace Controllers;

[ApiController]
[Route("/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService service;
    private readonly IJwtService jwt;
    public AuthController(IAuthService authService, IJwtService jwtService)
    {
        service = authService;
        jwt = jwtService;
    }
    
    // POST /login devuelve un token
    [HttpPost("login")]
    public IActionResult Login(string email, string password)
    {
        ActionResult result;
        try
        {
            var user = service.Login(email, password);
            user.Result.Token = jwt.CreateToken(user.Result);
            result = Ok(user);
        }
        catch (UserNotFoundException ex)
        {
            result = NotFound(ex.Message);
        }
        catch (InvalidPasswordException ex)
        {
            result = BadRequest(ex.Message);
        }
        catch (InvalidFieldsException ex)
        {
            result = BadRequest(ex.Message);
        }
        return result;
    }

    [HttpPost("register")]
    public IActionResult Register(UserDTO userDTO, string password)
    {
        ActionResult result;

        try
        {
            var user = service.Register(userDTO, password);
            user.Result.Token = jwt.CreateToken(user.Result);
            result = Ok(user);
        }
        catch (InvalidFieldsException ex)
        {
            result = BadRequest(ex.Message);
        }
        catch (RoleNotFoundException ex)
        {
            result = BadRequest(ex.Message);
        }
        catch (DatabaseQueryErrorException ex)
        {
            result = BadRequest(ex.Message);
        }
        catch (UserAlreadyExistsException ex)
        {
            result = BadRequest(ex.Message);
        }



        return result;
    }
    
}
