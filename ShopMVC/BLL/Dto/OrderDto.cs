namespace BLL.Dto;

public class OrderDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public bool Status { get; set; }
    public CustomerDto Customer { get; set; }
    public IEnumerable <ProductDto> Products { get; set; }
}