using Microsoft.EntityFrameworkCore;
using backend.Data.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoList> TodoList { get; set; } 
    }
}