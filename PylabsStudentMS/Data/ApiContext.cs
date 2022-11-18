using Microsoft.EntityFrameworkCore;
using PylabsStudentMS.Entity;

namespace PylabsStudentMS.Data
{
    public class ApiContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApiContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("ExamDb"));
        }
        public DbSet<User> User { get; set; }
        public DbSet<ExamResult> ExamResult { get; set; }
    }
}
