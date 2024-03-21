using LojaVirtualAPI.Entities;

namespace LojaVirtualAPI.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> Get();
    Task<Product> GetBy(int id);
    Task<IEnumerable<Product>> GetByCategory(int id);
}
