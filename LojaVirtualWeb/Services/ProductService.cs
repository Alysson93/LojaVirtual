using System.Net.Http.Json;
using LojaVirtualModels.Dtos;

namespace LojaVirtualWeb.Services;

public class ProductService : IProductService
{
    public HttpClient _httpClient;
    public ILogger<ProductService> _logger;

    public ProductService(HttpClient httpClient, ILogger<ProductService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<ProductDTO>> Get()
    {
        try
        {
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDTO>>("/api/products");
            return products;
        } catch(Exception)
        {
            _logger.LogError("Erro ao acessar /api/products");
            throw;
        }
    }
}