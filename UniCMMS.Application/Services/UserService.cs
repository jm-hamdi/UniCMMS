using UniCMMS.Application.Interfaces;
using UniCMMS.Domain.Entities;
using UniCMMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UniCMMS.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository) => _repository = repository;

    public async Task<(IEnumerable<User>, int totalCount)> GetPagedAsync(int pageNumber, int pageSize)
    {
        var query = _repository.Query(); // il faut exposer IQueryable dans IUserRepository, ou créer méthode spécifique
        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }
    public async Task<IEnumerable<User>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<User?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<User> CreateAsync(User user)
    {
        await _repository.AddAsync(user);
        return user;
    }

    public async Task<User?> UpdateAsync(int id, User updatedUser)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return null;

        existing.Email = updatedUser.Email;
        existing.FullName = updatedUser.FullName;
        existing.PhoneNumber = updatedUser.PhoneNumber;

        await _repository.UpdateAsync(existing);
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        await _repository.DeleteAsync(existing);
        return true;
    }
}