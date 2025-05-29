using Microsoft.AspNetCore.Mvc;
using UniCMMS.Application.Interfaces;
using UniCMMS.Domain.Entities;

namespace UniCMMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkOrdersController : ControllerBase
{
    private readonly IWorkOrderService _service;

    public WorkOrdersController(IWorkOrderService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? status, [FromQuery] int? assigneeId)
    {
        var workOrders = await _service.GetAllAsync(status, assigneeId);
        return Ok(workOrders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _service.GetByIdAsync(id);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WorkOrder workOrder)
    {
        var created = await _service.CreateAsync(workOrder);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] WorkOrder workOrder)
    {
        var updated = await _service.UpdateAsync(id, workOrder);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }
}