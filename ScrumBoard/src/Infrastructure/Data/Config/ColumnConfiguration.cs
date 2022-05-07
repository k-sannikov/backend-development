using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate;

namespace Infrastructure.Data.Config;

public class ColumnConfiguration : IEntityTypeConfiguration<Column>
{
    public void Configure(EntityTypeBuilder<Column> builder)
    {
        builder.ToTable("Column");

        builder.HasKey(c => c.ColumnId);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}