using System.ComponentModel.DataAnnotations;

namespace LojaVirtualAPI.Entities;

public class User
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Password { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public Cart? Cart { get; set; }
}