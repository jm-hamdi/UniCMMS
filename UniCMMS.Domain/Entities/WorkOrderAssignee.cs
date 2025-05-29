namespace UniCMMS.Domain.Entities;

public class WorkOrderAssignee
{
    public int WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
