using Microsoft.EntityFrameworkCore;
using UniCMMS.Domain.Entities;

namespace UniCMMS.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<WorkOrder> WorkOrders => Set<WorkOrder>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<User> Users => Set<User>();
    public DbSet<WorkOrderAssignee> WorkOrderAssignees => Set<WorkOrderAssignee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WorkOrderAssignee>()
            .HasKey(x => new { x.WorkOrderId, x.UserId });

        modelBuilder.Entity<WorkOrderAssignee>()
            .HasOne(x => x.WorkOrder)
            .WithMany(x => x.WorkOrderAssignees)
            .HasForeignKey(x => x.WorkOrderId);

        modelBuilder.Entity<WorkOrderAssignee>()
            .HasOne(x => x.User)
            .WithMany(x => x.WorkOrderAssignees)
            .HasForeignKey(x => x.UserId);
    }
}
