

using DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Controllers;

[ApiController]
[Route("/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService service;

    public ProductController(IProductService productService)
    {
        service = productService;
    }

    /*
    /CreateProduct. Permite al vendedor crear un nuevo producto y ponerlo a la venta. Campos requeridos: nombre, codigo, precio y cantidad.
    /DeleteProduct/{id}: Permite al vendedor eliminar un producto y sacarlo de la venta.Campos requeridos: código del producto.
    /UpdateProduct: Permite al vendedor modificar un producto.
    /GetProduct/{id} : Permite al vendedor/comprador obtener un producto en especifico. Campos requeridos: código del producto. Solo debe traer el producto si hay stock.
    /GetAllProducts: Permite al comprador obtener todos los productos a la venta. Solo debe traer productos en stock.
    */

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateProduct(ProductDTO product)
    {
        try
        {
            return Ok(await service.Create(product));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            return Ok(await service.Delete(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateProduct(ProductDTO product)
    {
        try
        {
            return Ok(await service.Update(product));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        try
        {
            return Ok(await service.GetById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            return Ok(await service.GetAll());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    //GetAllProductsBySeller/{id}: Permite al vendedor/comprador obtener los productos de un vendedor determinado.Solo debe traer productos en stock. Campos requeridos: código del vendedor.
    

    [HttpGet]
    [Route("GetAllBySeller/{id}")]
    public async Task<IActionResult> GetAllProductsBySeller(int id)
    {
        try
        {
            return Ok(await service.GetAllBySellerId(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



}
