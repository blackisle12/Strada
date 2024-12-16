using Microsoft.EntityFrameworkCore;
using Strada.Repository.Models;

namespace Strada.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employment> Employments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data with a loop
            var users = new List<User>();
            var addresses = new List<Address>();
            var employments = new List<Employment>();

            for (int i = 1; i <= 5; i++) // Generate 5 users
            {
                // Add user
                users.Add(new User
                {
                    Id = i,
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    Email = $"user{i}@test.com"
                });

                addresses.Add(new Address
                {
                    Id = i,
                    UserId = i,
                    Street = $"{i * 100} Main St",
                    City = $"City{i}",
                    PostCode = 10000 + i
                });

                employments.Add(new Employment
                {
                    Id = (i * 10) + 1,
                    UserId = i,
                    Company = $"CompanyA_User{i}",
                    MonthsOfExperience = (uint?)(12 * i),
                    Salary = (uint?)(50000 + (i * 1000)),
                    StartDate = new DateTime(2024, 1, 1),
                    EndDate = new DateTime(2025, 1, 1)
                });

                employments.Add(new Employment
                {
                    Id = (i * 10) + 2,
                    UserId = i,
                    Company = $"CompanyB_User{i}",
                    MonthsOfExperience = (uint?)(6 * i),
                    Salary = (uint?)(40000 + (i * 1000)),
                    StartDate = new DateTime(2024, 2, 1),
                    EndDate = new DateTime(2026, 2, 1)
                });
            }

            // Add data to the model
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Address>().HasData(addresses);
            modelBuilder.Entity<Employment>().HasData(employments);
        }
    }
}
