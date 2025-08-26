using Microsoft.EntityFrameworkCore;

namespace Employee_Web_Api.Models.AppDb
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }

        DbSet<Employee> Employees { get; set; }
    }
}
