using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Strada.Models.Employment;
using Strada.Models.User;
using Strada.Repository.Models;
using Strada.Service.Interface;

namespace Strada.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentController : ControllerBase
    {
        private readonly IEmploymentService _employmentService;
        private readonly IMapper _mapper;
        private readonly ILogger<EmploymentController> _logger;

        public EmploymentController(
            IEmploymentService employmentService,
            IMapper mapper,
            ILogger<EmploymentController> logger)
        {
            _employmentService = employmentService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmploymentRequest employment)
        {
            try
            {
                if (employment == null)
                {
                    return BadRequest("Employment data is required");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!_employmentService.ValidateUserEmployments(new List<EmploymentDateRange> { _mapper.Map<EmploymentDateRange>(employment) }, out var validationErrors))
                {
                    return BadRequest(string.Join(", ", validationErrors));
                }

                await _employmentService.AddAsync(employment);

                return Ok(employment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmploymentRequest employment)
        {
            try
            {
                if (employment == null)
                {
                    return BadRequest("Employment data is required");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!_employmentService.ValidateUserEmployments(new List<EmploymentDateRange> { _mapper.Map<EmploymentDateRange>(employment) }, out var validationErrors))
                {
                    return BadRequest(string.Join(", ", validationErrors));
                }

                employment.Id = id;
                var updated = await _employmentService.UpdateAsync(employment);

                if (!updated)
                {
                    return NotFound($"Employment with id of {id} does not exists");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _employmentService.DeleteAsync(id);

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
