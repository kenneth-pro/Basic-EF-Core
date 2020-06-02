﻿namespace _03EfCoreDemo.Models
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public byte Order { get; set; }
        //-----------------------------
        //Relationships
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
