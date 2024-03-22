using LojaVirtualAPI.Entities;
using LojaVirtualModels.Dtos;

namespace LojaVirtualAPI.Repositories;

public interface ICartRepository
{
    Task<Item> AddItem(AddItemDTO itemDTO);
    Task<Item> UpdateQtd(int id, UpdateQtdItemDTO qtdItemDTO);
    Task<Item> DeleteItem(int id);
    Task<Item> GetItem(int id);
    Task<IEnumerable<Item>> GetItems(string userId);
}