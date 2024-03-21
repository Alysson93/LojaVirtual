using LojaVirtualAPI.Entities;
using LojaVirtualModels.Dtos;

namespace LojaVirtualAPI.Mappings;

public static class MappingDTOs
{
    public static IEnumerable<CategoryDTO> ConvertCategory(this IEnumerable<Category> categories)
    {
        return (from category in categories select new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name,
            IconCSS = category.IconCSS
        }).ToList();
    }

    public static IEnumerable<ProductDTO> ConvertProduct(this IEnumerable<Product> products)
    {
        return (from product in products select new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageURL = product.ImageURL,
            Price = product.Price,
            Qtd = product.Qtd,
            CategoryId = product.Category.Id,
            CategoryName = product.Category.Name
        }).ToList();
    }

    public static ProductDTO ConvertProduct(this Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageURL = product.ImageURL,
            Price = product.Price,
            Qtd = product.Qtd,
            CategoryId = product.Category.Id,
            CategoryName = product.Category.Name
        };
    }

    public static IEnumerable<ItemDTO> ConvertItem
        (this IEnumerable<Item> items, IEnumerable<Product> products)
    {
        return (
            from item in items 
            join product in products
            on item.ProductId equals product.Id
            select new ItemDTO
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageURL = product.ImageURL,
                Price = product.Price,
                CartId = item.CartId,
                Qtd = item.Qtd,
                Total = product.Price * item.Qtd
            }).ToList();
    }

    public static ItemDTO ConvertItem(this Item item, Product product)
    {
        return new ItemDTO
        {
            Id = item.Id,
            ProductId = item.ProductId,
            ProductName = product.Name,
            ProductDescription = product.Description,
            ProductImageURL = product.ImageURL,
            Price = product.Price,
            CartId = item.CartId,
            Qtd = item.Qtd,
            Total = product.Price * item.Qtd
        };
    }
}