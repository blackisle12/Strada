using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Strada.Models.Employment;
using Strada.Models.User;
using Strada.Service.Interface;

namespace Strada.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmploymentService _employmentService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserService userService,
            IEmploymentService employmentService,
            IMapper mapper,
            ILogger<UserController> logger)
        {
            _userService = userService;
            _employmentService = employmentService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userService.GetAsync(id);

                if (user is null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User data is required");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (user.Employments != null && !_employmentService.ValidateUserEmployments(_mapper.Map<List<EmploymentDateRange>>(user.Employments), out var validationErrors))
                {
                    return BadRequest(string.Join(", ", validationErrors));
                }

                if (await _userService.EmailExistsAsync(user.Email))
                {
                    return BadRequest($"A user with email {user.Email} already exists.");
                }

                var result = await _userService.AddAsync(user);

                return CreatedAtAction(nameof(GetById), new { id = result }, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User data is required");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (user.Employments != null && !_employmentService.ValidateUserEmployments(_mapper.Map<List<EmploymentDateRange>>(user.Employments), out var validationErrors))
                {
                    return BadRequest(string.Join(", ", validationErrors));
                }

                if (await _userService.EmailExistsAsync(user.Email, id))
                {
                    return BadRequest($"A user with email {user.Email} already exists.");
                }

                user.Id = id;
                var updated = await _userService.UpdateAsync(user);

                if (!updated)
                {
                    return NotFound($"User {user.Email} is invalid.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
