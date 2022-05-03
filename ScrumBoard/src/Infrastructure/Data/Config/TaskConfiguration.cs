using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate.Task;

namespace Infrastructure.Data.Config;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("Task");

        builder.HasKey(ci => ci.TaskId);

        builder.Property(ci => ci.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ci => ci.Description)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(ci => ci.Priority)
            .IsRequired();
    }
}
