using LojaVirtualAPI.Mappings;
using LojaVirtualAPI.Repositories;
using LojaVirtualModels.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtualAPI.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        try
        {
            var products = await _repository.Get();
            if (products is null) return NotFound();
            else
            {
                var dtos = products.ConvertProduct();
                return Ok(dtos);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor.");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDTO>> GetBy(int id)
    {
        try
        {
            var product = await _repository.GetBy(id);
            if (product is null) return NotFound("Produto não encontrado.");
            else
            {
                var dto = product.ConvertProduct();
                return Ok(dto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor.");
        }
    }

    [HttpGet("category/{id:int}")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetByCategory(int id)
    {
        try
        {
            var products = await _repository.GetByCategory(id);
            if (products is null) return NotFound();
            else
            {
                var dtos = products.ConvertProduct();
                return Ok(dtos);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro interno do servidor.");
        }
    }
}