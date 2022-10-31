namespace DAL.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public bool Status { get; set; }
    public Customer Customer { get; set; }
    public IEnumerable <Product> Products { get; set; }
}