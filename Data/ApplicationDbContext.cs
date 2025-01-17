using HMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS_API.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }


    }
}
