
namespace LibraryApp.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<LibraryAuthor> LibraryAuthors { get; set; } = new List<LibraryAuthor>();
    }
}
