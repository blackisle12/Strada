using AutoMapper;
using Strada.Models.User;
using Strada.Repository.Interface;
using Strada.Repository.Models;
using Strada.Service.Interface;

namespace Strada.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _userRepository.EmailExistsAsync(email);
        }

        public async Task<bool> EmailExistsAsync(string email, int id)
        {
            return await _userRepository.EmailExistsAsync(email, id);
        }

        public async Task<IEnumerable<GetUserResponse>> GetAsync()
        {
            var response = new List<GetUserResponse>();
            var users = await _userRepository.GetAllAsync(u => u.Address, u => u.Employments);

            response = _mapper.Map<List<GetUserResponse>>(users);

            return response;
        }

        public async Task<GetUserResponse?> GetAsync(int id)
        {
            GetUserResponse response = null;

            var user = await _userRepository.GetByIdAsync(id, u => u.Address, u => u.Employments);

            if (user != null)
            {
                response = _mapper.Map<GetUserResponse>(user);
            }

            return response;
        }

        public async Task<int> AddAsync(CreateUserRequest user)
        {
            var entity = _mapper.Map<User>(user);

            await _userRepository.AddAsync(entity);
            await _userRepository.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(UpdateUserRequest user)
        {
            var entity = await _userRepository.GetByIdAsync(user.Id);

            if (entity == null)
            {
                return false;
            }

            _userRepository.Detach(entity);

            entity = _mapper.Map<User>(user);
            _userRepository.Update(entity);

            await _userRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveChangesAsync();

            return true;
        }
    }
}
