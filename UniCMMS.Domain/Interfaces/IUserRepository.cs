using UniCMMS.Domain.Entities;

namespace UniCMMS.Domain.Interfaces;

public interface IUserRepository
{
    IQueryable<User> Query();
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);

}