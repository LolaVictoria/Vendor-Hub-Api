using Microsoft.AspNetCore.Mvc;
using VendorHub.DTOs;
using VendorHub.Services;

namespace VendorHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetAllProducts();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id)
    {
        var product = await _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(
        [FromBody] CreateProductDto dto)
    {
        var createdProduct = await _productService.AddProduct(dto);

        if (createdProduct == null)
        {
            return NotFound("Vendor not found.");
        }

        return CreatedAtAction(
            nameof(GetProductById),
            new { id = createdProduct.Id },
            createdProduct
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(
        [FromRoute] Guid id,
        [FromBody] CreateProductDto dto)
    {
        var updatedProduct = await _productService.UpdateProduct(id, dto);

        if (updatedProduct == null)
        {
            return NotFound();
        }

        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        var deleted = await _productService.DeleteProduct(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}