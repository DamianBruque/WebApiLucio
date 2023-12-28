
using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Abstractions;
using Utilities.Exceptions;

namespace Controllers;

[ApiController]
[Route("/rol")]
public class RoleController : ControllerBase
{
    private readonly IRoleService roleService;
    //private readonly IBaseService<RoleEntity,RoleDTO> baseService;
    public RoleController(IRoleService roleService)//, IBaseService<RoleEntity,RoleDTO> baseService)
    {
        this.roleService = roleService;
        //this.baseService = baseService;
    }
    /*
    [HttpGet("testConnection")]
    public IActionResult TestConnection()
    {
        return Ok(baseService.TestConnection().Result ? "Conexión a base de datos exitosa" : "Conexión a base de datos fallida");
    }
    */
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        ActionResult result;
        try
        {

            result = Ok(await roleService.GetAll());
        }
        catch (DatabaseQueryErrorException e)
        {
            result = BadRequest(e.Message);
        }
        return result;
    }
}
