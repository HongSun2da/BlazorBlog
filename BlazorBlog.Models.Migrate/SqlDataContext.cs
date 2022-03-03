using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Models.Migrate
{
    public class SqlDataContext : DbContext
    {
        public SqlDataContext(DbContextOptions<SqlDataContext> options) : base(options)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
