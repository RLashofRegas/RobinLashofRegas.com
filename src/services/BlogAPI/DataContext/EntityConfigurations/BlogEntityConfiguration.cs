using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogAPI.Models;

namespace BlogAPI.DataContext.EntityConfigurations
{
    public class BlogEntityConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
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