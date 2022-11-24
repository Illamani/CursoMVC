using CursoIndio.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoIndio.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Employee> employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
