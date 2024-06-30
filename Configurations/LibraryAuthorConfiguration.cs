using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Configurations
{
    public class LibraryAuthorConfiguration : IEntityTypeConfiguration<LibraryAuthor>
    {
        public void Configure(EntityTypeBuilder<LibraryAuthor> builder)
        {
            builder.HasKey(la => new { la.LibraryId, la.AuthorId });

            builder.HasOne(la => la.Library)
                .WithMany(l => l.LibraryAuthors)
                .HasForeignKey(la => la.LibraryId);

            builder.HasOne(la => la.Author)
                .WithMany(a => a.LibraryAuthors)
                .HasForeignKey(la => la.AuthorId);
        }
    }
}
