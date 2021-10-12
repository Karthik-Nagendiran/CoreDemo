﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreBookStore.Models
{
    public class Author : BaseEntity
    {   
        [Key]
        public int AuthorId { get; set; }
        [DisplayName("Author Name")]
        public string AuthorName { get; set; }
    }
}
