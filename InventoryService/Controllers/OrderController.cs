using OrderService.Services;
using Microsoft.AspNetCore.Mvc;
using ProductSevice.Entities;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ProductService _prodClient;

    public OrderController(ProductService prodClient)
    {
        _prodClient = prodClient;
    }

    [HttpGet("getproduct/{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _prodClient.GetProduxtAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }
}
