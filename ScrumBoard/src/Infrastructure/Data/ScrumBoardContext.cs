using ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate;
using Task = ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate.Task;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class ScrumBoardContext : DbContext
{
    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public ScrumBoardContext(DbContextOptions<ScrumBoardContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}