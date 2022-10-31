namespace BLL.Dto;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public IEnumerable<OrderDto> Orders { get; set; }
        
}