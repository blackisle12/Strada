using AutoMapper;
using Strada.Models.Employment;
using Strada.Repository.Interface;
using Strada.Repository.Models;
using Strada.Service.Interface;

namespace Strada.Service
{
    public class EmploymentService : IEmploymentService
    {
        private readonly IRepository<Employment> _repository;
        private readonly IMapper _mapper;

        public EmploymentService(
            IRepository<Employment> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CreateEmploymentRequest employment)
        {
            var entity = _mapper.Map<Employment>(employment);

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateEmploymentRequest employment)
        {
            var entity = await _repository.GetByIdAsync(employment.Id);

            if (entity == null)
            {
                return false;
            }

            _repository.Detach(entity);

            entity = _mapper.Map<Employment>(employment);
            _repository.Update(entity);

            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();

            return true;
        }

        public bool ValidateUserEmployments(IEnumerable<EmploymentDateRange>? employments, out List<string> errors)
        {
            errors = new List<string>();

            if (employments == null)
            {
                return true;
            }

            foreach (var employment in employments)
            {
                if (employment.StartDate != null && employment.EndDate != null)
                {
                    if (employment.EndDate <= employment.StartDate)
                    {
                        errors.Add($"Employment has an EndDate ({employment.EndDate.Value}) that is earlier than or equal to StartDate ({employment.StartDate.Value}).");
                    }
                }
            }

            return !errors.Any();
        }
    }
}
