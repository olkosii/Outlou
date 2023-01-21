using Microsoft.EntityFrameworkCore;

namespace Outlou.DataModels
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<ReadNews> ReadNews { get; set; }
    }
}
