using LojaVirtualAPI.Context;
using LojaVirtualAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtualAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> Get()
    {
        var products = await _context.Products
        .Include(p => p.Category)
        .ToListAsync();
        return products;
    }

    public async Task<Product> GetBy(int id)
    {
        var product = await _context.Products
        .Include(p => p.Category)
        .SingleOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public async Task<IEnumerable<Product>> GetByCategory(int id)
    {
        var products = await _context.Products
        .Include(p => p.Category)
        .Where(p => p.CategoryId == id).ToListAsync();
        return products;
    }
}