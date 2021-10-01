using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBookStore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int LangId { get; set; }
        public int Pages { get; set; }
        public DateTime PublicationDate { get; set; }
        public int PublisherId { get; set; }

    }
}
