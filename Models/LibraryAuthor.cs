namespace LibraryApp.Models
{
    public class LibraryAuthor
    {
        public int LibraryId { get; set; }
        public Library Library { get; set; } = null!;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
