using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class LibraryAuthor
    {
        [Key]
        public int LibraryAuthorId { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; } = null!;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
