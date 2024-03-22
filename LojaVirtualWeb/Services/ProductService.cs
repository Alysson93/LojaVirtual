using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
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

    public async Task<ProductDTO> GetBy(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/products/{id}");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NoContent) return default;
                return await response.Content.ReadFromJsonAsync<ProductDTO>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Erro ao ler produto pelo id {id}: {message}");
                throw new Exception($"Status code: {response.StatusCode} - {message}");
            }
        }
        catch (Exception)
        {
            _logger.LogError($"Erro ao acessar /api/products/{id}");
            throw;
        }
    }
}