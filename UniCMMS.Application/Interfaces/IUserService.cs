using UniCMMS.Domain.Entities;

namespace UniCMMS.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<User?> UpdateAsync(int id, User updatedUser);
    Task<bool> DeleteAsync(int id);
    Task<(IEnumerable<User>, int totalCount)> GetPagedAsync(int pageNumber, int pageSize);

}