using CursoIndio.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoIndio.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Department = Dept.It,
                    Email = "Peter@gmail.com",
                    Name = "Peter"
                },
                new Employee
                {
                    Id = 2,
                    Department = Dept.Payroll,
                    Name = "John",
                    Email = "John@gmail.com"
                }
            );
        }
    }
}
