using System.ComponentModel.DataAnnotations;

namespace LojaVirtualModels.Dtos;

public class AddItemDTO
{
    [Required]
    public int CartId { get; set; }
    [Required]
    public int Product { get; set; }
    [Required]
    public int Qtd { get; set; }
}