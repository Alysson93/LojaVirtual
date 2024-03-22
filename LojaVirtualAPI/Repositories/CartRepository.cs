using LojaVirtualAPI.Context;
using LojaVirtualAPI.Entities;
using LojaVirtualModels.Dtos;

namespace LojaVirtualAPI.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;

    public CartRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Item> AddItem(AddItemDTO itemDTO)
    {
        throw new NotImplementedException();
    }

    public Task<Item> DeleteItem(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Item> GetItem(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Item>> GetItems(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Item> UpdateQtd(int id, UpdateQtdItemDTO qtdItemDTO)
    {
        throw new NotImplementedException();
    }
}