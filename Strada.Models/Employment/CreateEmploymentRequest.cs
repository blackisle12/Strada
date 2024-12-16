using System.ComponentModel.DataAnnotations;

namespace Strada.Models.Employment
{
    public class CreateEmploymentRequest
    {
        [Required]
        public int UserId { get; set; }

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
