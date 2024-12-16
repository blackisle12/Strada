using Strada.Models.User;

namespace Strada.Service.Interface
{
    public interface IUserService
    {
        Task<bool> EmailExistsAsync(string email);
        Task<bool> EmailExistsAsync(string email, int id);
        Task<IEnumerable<GetUserResponse>> GetAsync();
        Task<GetUserResponse?> GetAsync(int id);
        Task<int> AddAsync(CreateUserRequest user);
        Task<bool> UpdateAsync(UpdateUserRequest user);
        Task<bool> DeleteAsync(int id);
    }
}
