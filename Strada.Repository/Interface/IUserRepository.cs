using Strada.Repository.Models;

namespace Strada.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> EmailExistsAsync(string email);
        Task<bool> EmailExistsAsync(string email, int id);
    }
}
