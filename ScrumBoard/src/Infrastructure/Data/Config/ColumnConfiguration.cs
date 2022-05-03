﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate;

namespace Infrastructure.Data.Config;

public class ColumnConfiguration : IEntityTypeConfiguration<Column>
{
    public void Configure(EntityTypeBuilder<Column> builder)
    {
        builder.ToTable("Column");

        builder.HasKey(ci => ci.ColumnId);

        builder.Property(ci => ci.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}