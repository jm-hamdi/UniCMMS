using Microsoft.EntityFrameworkCore;
using UniCMMS.Domain.Entities;
using UniCMMS.Domain.Interfaces;
using UniCMMS.Infrastructure.Persistence;

namespace UniCMMS.Infrastructure.Repositories;

public class WorkOrderRepository : IWorkOrderRepository
{
    private readonly AppDbContext _context;
    public WorkOrderRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<WorkOrder>> GetAllAsync(string? status = null, int? assigneeId = null)
    {
        var query = _context.WorkOrders
            .Include(w => w.WorkOrderAssignees).ThenInclude(wa => wa.User)
            .AsQueryable();

        if (!string.IsNullOrEmpty(status))
        {
            // Récupère l'Id du status via la table Statuses
            var statusEntity = await _context.Statuses
                .FirstOrDefaultAsync(s => s.Name == status);

            if (statusEntity != null)
            {
                query = query.Where(w => w.StatusId == statusEntity.Id);
            }
            else
            {
                // Aucun status trouvé, renvoie liste vide
                return new List<WorkOrder>();
            }
        }

        if (assigneeId.HasValue)
            query = query.Where(w => w.WorkOrderAssignees.Any(a => a.UserId == assigneeId.Value));

        return await query.ToListAsync();
    }

    public async Task<WorkOrder?> GetByIdAsync(int id) =>
        await _context.WorkOrders
            .Include(w => w.WorkOrderAssignees).ThenInclude(wa => wa.User)
            .FirstOrDefaultAsync(w => w.Id == id);

    public async Task AddAsync(WorkOrder workOrder)
    {
        _context.WorkOrders.Add(workOrder);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(WorkOrder workOrder)
    {
        _context.WorkOrders.Update(workOrder);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(WorkOrder workOrder)
    {
        _context.WorkOrders.Remove(workOrder);
        await _context.SaveChangesAsync();
    }
}
