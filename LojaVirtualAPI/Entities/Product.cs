using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtualAPI.Entities;

public class Product
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(200)]
    public string ImageURL { get; set; } = string.Empty;

    [Column(TypeName ="decimal(10, 2)")]
    public decimal Price { get; set; }
    public int Qtd { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public ICollection<Item> Items { get; set; } = new List<Item>();
}
