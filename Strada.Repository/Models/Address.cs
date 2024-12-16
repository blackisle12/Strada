using System.ComponentModel.DataAnnotations;

namespace Strada.Repository.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string? Street { get; set; } //MANDATORY

        [Required]
        public string? City { get; set; } //MANDATORY
        public int? PostCode { get; set; }
    }

}
