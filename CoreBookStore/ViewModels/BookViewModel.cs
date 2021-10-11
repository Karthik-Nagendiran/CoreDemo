using CoreBookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoreBookStore.ViewModels
{

    public class BookViewModel
    { 
        public Book BookModel { get; set; }
        
        [DisplayName("Language")]
        public IEnumerable<SelectListItem> Languages { get; set; }

        public IEnumerable<SelectListItem> Publishers { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }

        public int SelectedLanguage { get; set; }

        public int SelectedPublisher { get; set; }

        public int SelectedAuthor { get; set; }
    }
    //public class BookViewModel
    //{
    //    public int BookId { get; set; }
    //    [DisplayName("Book Name")]
    //    public string Title { get; set; }
    //    public string ISBN { get; set; }

    //    [DisplayName("Language")]
    //    public int LangId { get; set; }        
    //    public IEnumerable<SelectListItem> Languages { get; set; }
    //    public int Pages { get; set; }

    //    [DisplayName("Year Published")]
    //    public DateTime PublicationDate { get; set; }

    //    [DisplayName("Publication")]
    //    public int PublisherId { get; set; }
    //    public List<SelectListItem> Publisher { get; set; }
    //}
}
