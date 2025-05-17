namespace FactoryProject.Models.OrderDtos;

public class UpdateOrderDto
{
    public int order_id { get; set; }
    public bool status{ get; set; }
    public DateTime? delivery_date { get; set; }
}