namespace LojaVirtualModels.Dtos;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageURL { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Qtd { get; set; }
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
}