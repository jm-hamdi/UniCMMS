using Microsoft.AspNetCore.Mvc;
using UniCMMS.Application.Interfaces;
using UniCMMS.Domain.Entities;

namespace UniCMMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service) => _service = service;

    // [HttpGet]
    // public async Task<IActionResult> GetAll()
    // {
    //     var users = await _service.GetAllAsync();
    //     return Ok(users);
    // }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        var created = await _service.CreateAsync(user);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User user)
    {
        var updated = await _service.UpdateAsync(id, user);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }

    [HttpGet]
public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
{
    var (users, totalCount) = await _service.GetPagedAsync(pageNumber, pageSize);
    return Ok(new { totalCount, users });
}
}