namespace FactoryProject.Models;

public class PendingOrderDto
{
    public int id { get; set; }
    public string username { get; set; } = string.Empty;
    public bool delivered { get; set; }
    public DateTime orderDate { get; set; }
}
public class TopProductDto
{
    public string name { get; set; } = string.Empty;
    public long orderCount{ get; set; }
}