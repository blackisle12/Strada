using System.ComponentModel.DataAnnotations;

namespace Strada.Repository.Models
{
    public class Employment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string? Company { get; set; } //MANDATORY

        [Required]
        public uint? MonthsOfExperience { get; set; } //MANDATORY

        [Required]
        public uint? Salary { get; set; } //MANDATORY

        [Required]
        public DateTime? StartDate { get; set; } //MANDATORY

        public DateTime? EndDate { get; set; }
    }
}
