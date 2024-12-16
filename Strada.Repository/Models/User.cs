using System.ComponentModel.DataAnnotations;

namespace Strada.Repository.Models
{
    public class User
    {
        public User()
        {
            Employments = new List<Employment>();
        }
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; } //MANDATORY

        [Required]
        public string? LastName { get; set; } //MANDATORY

        [Required]
        public string? Email { get; set; } //MANDATORY, UNIQUE


        public Address? Address { get; set; }

        public List<Employment> Employments { get; set; } //  add, update an existing employment,
                                                          // delete an existing employment
    }
}
