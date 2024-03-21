namespace LojaVirtualAPI.Entities;

public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ICollection<Item> Items { get; set; } = new List<Item>();
}