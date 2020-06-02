using System.Collections.Generic;

namespace _03EfCoreDemo.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        //------------------------------
        //Relationships
        public ICollection<BookAuthor> BooksLink { get; set; }
    }
}
