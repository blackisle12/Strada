namespace Strada.Models.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public GetUserAddressResponse? Address { get; set; }
        public List<GetUserEmploymentResponse>? Employments { get; set; }
    }

    public class GetUserAddressResponse
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public int? PostCode { get; set; }
    }

    public class GetUserEmploymentResponse
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public uint? MonthsOfExperience { get; set; }
        public uint? Salary { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
