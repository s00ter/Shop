namespace BLL.Dto;

public class ProductDto
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public double Price { get; set; }
    public ShopDto Shop { get; set; }
}