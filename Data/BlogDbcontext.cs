using BlogApi.Models;
using Microsoft.EntityFrameworkCore;


namespace BlogApi.Data
{
    public class BlogDbcontext: DbContext
    {
        public BlogDbcontext(
            DbContextOptions<BlogDbcontext> options)
            : base(options)
        { 
        }
        public DbSet<Post> Posts { get; set; }
    }
}
