using System;
using System.ComponentModel;

namespace CoreBookStore.Models
{
    public abstract class BaseEntity
    {
        public bool IsDeleted { get; set; } = false;

        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [DisplayName("Modified On")]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; } = string.Empty;

        public string ModifiedBy { get; set; } = string.Empty;

    }
}
