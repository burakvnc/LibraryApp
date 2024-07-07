
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public ICollection<LibraryBook> LibraryBooks { get; set; } = new List<LibraryBook>();
        public ICollection<LibraryAuthor> LibraryAuthors { get; set; } = new List<LibraryAuthor>();
    }
}
