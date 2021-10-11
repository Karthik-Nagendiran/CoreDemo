using System.ComponentModel.DataAnnotations;

namespace CoreBookStore.Models
{
    public class Publisher : BaseEntity
    {
        [Key]
        public int PublisherId { get; set; }
        public string  PublisherName { get; set; }
    }
}
