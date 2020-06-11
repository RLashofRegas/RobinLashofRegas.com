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

            builder.ToTable("Blogs");

            builder.HasIndex(b => b.Name)
                .IsUnique();

            builder.Property(b => b.Name)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(b => b.TileImagePath)
                .HasMaxLength(255);
        }
    }
}
