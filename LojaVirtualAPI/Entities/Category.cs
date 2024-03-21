using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtualAPI.Entities;

public class Category
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string IconCSS { get; set; } = string.Empty;
    public Collection<Product> Products { get; set; } = new Collection<Product>();
}
