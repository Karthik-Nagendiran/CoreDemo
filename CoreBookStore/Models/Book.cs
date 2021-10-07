using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreBookStore.Models
{
    public class Book : BaseEntity
    {
        [Key]
        public int BookId { get; set; }
        [DisplayName("Book Name")]
        public string Title { get; set; }
        public string ISBN { get; set; }
        
        public BookLanguage Language { get; set; }
        public int Pages { get; set; }
        
        [DisplayName("Year Published")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublicationDate { get; set; }        
        
        [DisplayName("Publisher")]
        public Publisher Publisher { get; set; }

    }
}
