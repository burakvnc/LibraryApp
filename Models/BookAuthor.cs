using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class BookAuthor
    {
        [Key]
        public int BookAuthorId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
