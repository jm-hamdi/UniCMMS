namespace UniCMMS.Domain.Entities;

public class WorkOrder
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    public DateTime DueDate { get; set; }
    public ICollection<WorkOrderAssignee> WorkOrderAssignees { get; set; } = new List<WorkOrderAssignee>();
}
