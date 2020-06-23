using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogAPI.Models;
using System;

namespace BlogAPI.DataContext.EntityConfigurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException($"{nameof(builder)}");
            }

            _ = builder.ToTable("Posts");

            _ = builder.Property(p => p.Title)
                .HasMaxLength(48)
                .IsRequired();

            _ = builder.Property(p => p.RawContent)
                .HasColumnType("TEXT");

            _ = builder.Property(p => p.ParsedContent)
                .HasColumnType("TEXT");
        }
    }
}
