using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Configurations
{
    public class LibraryBookConfiguration : IEntityTypeConfiguration<LibraryBook>
    {
        public void Configure(EntityTypeBuilder<LibraryBook> builder)
        {
            builder.HasKey(lb => new { lb.LibraryBookId });

            builder.HasOne(lb => lb.Library)
                .WithMany(l => l.LibraryBooks)
                .HasForeignKey(lb => lb.LibraryId);

            builder.HasOne(lb => lb.Book)
                .WithMany(b => b.LibraryBooks)
                .HasForeignKey(lb => lb.BookId);
        }
    }
}
