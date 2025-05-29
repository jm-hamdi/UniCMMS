using UniCMMS.Domain.Entities;

namespace UniCMMS.Application.Interfaces;

public interface IWorkOrderService
{
    Task<IEnumerable<WorkOrder>> GetAllAsync(string? status = null, int? assigneeId = null);
    Task<WorkOrder?> GetByIdAsync(int id);
    Task<WorkOrder> CreateAsync(WorkOrder workOrder);
    Task<WorkOrder?> UpdateAsync(int id, WorkOrder updatedWorkOrder);
    Task<bool> DeleteAsync(int id);
}
