using Microsoft.AspNetCore.Mvc;
using ProductSevice.Data;
using ProductSevice.Entities;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProdAsync(int id)
    {
        var prod = await _context.Products.FindAsync(id);
        if (prod == null) return NotFound();
        return Ok(prod);
    }
}
