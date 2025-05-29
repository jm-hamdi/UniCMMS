using UniCMMS.Domain.Entities;

namespace UniCMMS.Domain.Interfaces;

public interface IWorkOrderRepository
{
    Task<IEnumerable<WorkOrder>> GetAllAsync(string? status = null, int? assigneeId = null);
    Task<WorkOrder?> GetByIdAsync(int id);
    Task AddAsync(WorkOrder workOrder);
    Task UpdateAsync(WorkOrder workOrder);
    Task DeleteAsync(WorkOrder workOrder);
}
