namespace DAL.Entities;

public class Product
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public double Price { get; set; }
    public Shop Shop { get; set; }


}