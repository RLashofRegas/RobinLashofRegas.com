using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogAPI.Models;
using System;

namespace BlogAPI.DataContext.EntityConfigurations
{
    public class BlogEntityConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException($"{nameof(builder)}");
            }

            _ = builder.ToTable("Blogs");

            _ = builder.HasIndex(b => b.Name)
                .IsUnique();

            _ = builder.Property(b => b.Name)
                .HasMaxLength(48)
                .IsRequired();

            _ = builder.Property(b => b.TileImagePath)
                .HasMaxLength(255);
        }
    }
}
