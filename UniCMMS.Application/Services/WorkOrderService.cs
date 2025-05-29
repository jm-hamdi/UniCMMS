using UniCMMS.Application.Interfaces;
using UniCMMS.Domain.Entities;
using UniCMMS.Domain.Interfaces;

namespace UniCMMS.Application.Services;

public class WorkOrderService : IWorkOrderService
{
    private readonly IWorkOrderRepository _repository;

    public WorkOrderService(IWorkOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<WorkOrder>> GetAllAsync(string? status = null, int? assigneeId = null)
    {
        return await _repository.GetAllAsync(status, assigneeId);
    }

    public async Task<WorkOrder?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<WorkOrder> CreateAsync(WorkOrder workOrder)
    {
        await _repository.AddAsync(workOrder);
        return workOrder;
    }

    public async Task<WorkOrder?> UpdateAsync(int id, WorkOrder updatedWorkOrder)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return null;

        existing.Name = updatedWorkOrder.Name;
        existing.Description = updatedWorkOrder.Description;
        existing.StatusId = updatedWorkOrder.StatusId;
        existing.DueDate = updatedWorkOrder.DueDate;
        existing.WorkOrderAssignees = updatedWorkOrder.WorkOrderAssignees;

        await _repository.UpdateAsync(existing);
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null)
            return false;

        await _repository.DeleteAsync(existing);
        return true;
    }
}
