using Dapper.Contrib.Extensions;
using System.ComponentModel;

namespace CoreBookStore.Models
{
    [Table("Authors")]
    public class Author : BaseEntity
    {   
        [Dapper.Contrib.Extensions.Key]
        public int AuthorId { get; set; }

        [DisplayName("Author Name")]
        public string AuthorName { get; set; }
    }
}
