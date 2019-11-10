using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogAPI.Models;

namespace BlogAPI.DataContext.EntityConfigurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.Property(p => p.Title)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.RawContent)
                .HasColumnType("TEXT");

            builder.Property(p => p.ParsedContent)
                .HasColumnType("TEXT");
        }
    }
}