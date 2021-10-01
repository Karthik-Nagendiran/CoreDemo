﻿using System.ComponentModel.DataAnnotations;

namespace CoreBookStore.Models
{
    public class Author
    {   [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
