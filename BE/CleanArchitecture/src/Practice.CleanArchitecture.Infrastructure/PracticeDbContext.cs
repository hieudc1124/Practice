using Microsoft.EntityFrameworkCore;

namespace Practice.CleanArchitecture.Infrastructure;

public class PracticeDbContext : DbContext
{
    public PracticeDbContext(DbContextOptions<PracticeDbContext> options)
           : base(options)
    {
    }

    //public DbSet<TodoItem> TodoItems { get; set; } = null!;
}