using Microsoft.EntityFrameworkCore;

namespace Learn.API.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>option):base(option)
        {

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movies> movies { get; set; }
    }
}
