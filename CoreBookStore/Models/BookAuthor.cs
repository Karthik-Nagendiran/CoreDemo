using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBookStore.Models
{
    public class BookAuthor : BaseEntity
    {
        [Key]
        public int BookAuthorId { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
    }
}
