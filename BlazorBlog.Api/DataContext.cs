using BlazorBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Api
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
