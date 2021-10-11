using System.ComponentModel.DataAnnotations;

namespace CoreBookStore.Models
{
    public class Author : BaseEntity
    {   
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
