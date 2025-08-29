using Microsoft.EntityFrameworkCore;

namespace Employee_Web_Api.Models.AppDb
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<UserAuth> UserAuths { get; set; }
    }
}
