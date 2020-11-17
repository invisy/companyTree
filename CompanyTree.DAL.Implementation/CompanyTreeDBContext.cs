using Microsoft.EntityFrameworkCore;
using CompanyTree.Entities;
using System.Configuration;

namespace CompanyTree.DAL.Implementation
{
    public class CompanyTreeDBContext : DbContext
    {
        public CompanyTreeDBContext(DbContextOptions<CompanyTreeDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var employeeOne = new EmployeeEntity
            {
                Id = 1,
                Name = "Ivan Ivanov"
            };
            
            modelBuilder.Entity<EmployeeEntity>().HasData(employeeOne);
        }
    }
}
