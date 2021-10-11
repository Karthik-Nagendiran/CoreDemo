using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBookStore.Models
{
    public class Book : BaseEntity
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [DisplayName("Book Name")]
        public string Title { get; set; }

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }


        [DisplayName("Language")]
        public int LanguageId { get; set; }

        [DisplayName("Publisher")]
        public int PublisherId { get; set; }

        [Required]
        [DisplayName("Author")]
        public int AuthorId { get; set; }

        public int Pages { get; set; }

        [DisplayName("Year Published")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublicationDate { get; set; }

        [ForeignKey("LanguageId")]
        public virtual BookLanguage Language { get; set; }

        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

    }
}
