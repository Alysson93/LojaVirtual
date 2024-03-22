using LojaVirtualModels.Dtos;

namespace LojaVirtualWeb.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> Get();

    Task<ProductDTO> GetBy(int id);
}