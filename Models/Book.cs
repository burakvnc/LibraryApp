

using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public ICollection<LibraryBook> LibraryBooks { get; set; } = new List<LibraryBook>();
    }
}
