using System.ComponentModel.DataAnnotations;

namespace Strada.Models.User
{
    public class CreateUserRequest
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        public CreateUserAddressRequest? Address { get; set; }

        public List<CreateUserEmploymentRequest>? Employments { get; set; }
    }

    public class CreateUserAddressRequest
    {
        [Required]
        public string? Street { get; set; }

        [Required]
        public string? City { get; set; }

        public int? PostCode { get; set; }
    }

    public class CreateUserEmploymentRequest
    {
        [Required]
        public string? Company { get; set; }

        [Required]
        public uint? MonthsOfExperience { get; set; }

        [Required]
        public uint? Salary { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
