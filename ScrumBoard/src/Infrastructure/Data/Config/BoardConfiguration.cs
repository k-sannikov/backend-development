using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate;

namespace Infrastructure.Data.Config;

public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.ToTable("Board");

        builder.HasKey(ci => ci.BoardId);

        builder.Property(ci => ci.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
