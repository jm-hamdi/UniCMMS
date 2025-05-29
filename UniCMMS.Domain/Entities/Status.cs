namespace UniCMMS.Domain.Entities;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
