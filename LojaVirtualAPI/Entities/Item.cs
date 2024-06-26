namespace LojaVirtualAPI.Entities;

public class Item
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Qtd { get; set; }
    public Cart? Cart { get; set; }
    public Product? Product { get; set; }
}