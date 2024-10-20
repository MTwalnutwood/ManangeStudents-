
using Microsoft.EntityFrameworkCore;

using WebApplication10.Models;

namespace WebApplication10.Dbset
{
    public class ApplicationDbContext : DbContext
     
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
