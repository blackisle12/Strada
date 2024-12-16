using Strada.Models.Employment;
using Strada.Models.User;
using Strada.Repository.Models;

namespace Strada.Service.Interface
{
    public interface IEmploymentService
    {
        Task<int> AddAsync(CreateEmploymentRequest employment);
        Task<bool> UpdateAsync(UpdateEmploymentRequest employment);
        Task<bool> DeleteAsync(int id);
        bool ValidateUserEmployments(IEnumerable<EmploymentDateRange>? employments, out List<string> errors);
    }
}
