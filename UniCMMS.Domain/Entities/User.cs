namespace UniCMMS.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public ICollection<WorkOrderAssignee> WorkOrderAssignees { get; set; } = new List<WorkOrderAssignee>();
}
