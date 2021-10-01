using System.ComponentModel.DataAnnotations;

namespace CoreBookStore.Models
{
    public class BookLanguage
    {
        [Key]
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public string  LanguageName { get; set; }
        public string CultureName { get; set; }
    }
}
