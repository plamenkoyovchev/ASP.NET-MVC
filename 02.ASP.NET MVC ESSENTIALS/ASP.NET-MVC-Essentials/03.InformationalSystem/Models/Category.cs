using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03.InformationalSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }

        public Category()
        {
            this.Books = new HashSet<Book>();
        }
    }
}