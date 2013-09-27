using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03.InformationalSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}