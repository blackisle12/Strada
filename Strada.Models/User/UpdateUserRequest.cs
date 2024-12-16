using System.ComponentModel.DataAnnotations;

namespace Strada.Models.User
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        public UpdateUserAddressRequest? Address { get; set; }

        public List<UpdateUserEmploymentRequest>? Employments { get; set; }
    }

    public class UpdateUserAddressRequest
    {
        public int Id { get; set; }

        [Required]
        public string? Street { get; set; }

        [Required]
        public string? City { get; set; }

        public int? PostCode { get; set; }
    }

    public class UpdateUserEmploymentRequest
    {
        public int Id { get; set; }

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
