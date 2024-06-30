namespace LibraryApp.Models
{
    public class LibraryBook
    {
        public int LibraryId { get; set; }
        public Library Library { get; set; } = null!;
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}
