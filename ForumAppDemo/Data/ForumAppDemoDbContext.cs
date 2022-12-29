using ForumAppDemo.Data.Configure;
using ForumAppDemo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumAppDemo.Data
{
    public class ForumAppDemoDbContext : DbContext
    {

        public ForumAppDemoDbContext(DbContextOptions<ForumAppDemoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostConfiguration());
            
            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; } 

    }
}
