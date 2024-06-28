using Microsoft.EntityFrameworkCore;
namespace Symbiote.Server.Models
{
    public class Context : DbContext
    {
        public DbSet<TodoItem> Items { get; set; } = null!;
        public Context(DbContextOptions<Context> options)
        : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                    new TodoItem { Id = Guid.NewGuid().ToString(), Name = "Breakfast", IsComplete = "Yes" },
                    new TodoItem { Id = Guid.NewGuid().ToString(), Name = "Dinner", IsComplete = "No" },
                    new TodoItem { Id = Guid.NewGuid().ToString(), Name = "Business lunch", IsComplete = "Neither yes nor no" }
            );
        }

        
    }
}
