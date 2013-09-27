using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace _03.InformationalSystem.ViewModel
{
    public class CreateBookVewModel
    {
        public List<SelectListItem> BookCategories { get; set; }

        public string SelectedValue { get; set; }

        [Required]
        [StringLength(100,MinimumLength=4)]
        public string Title { get; set; }

        [Required]
        [StringLength(200,MinimumLength=10)]
        public string Content { get; set; }
        public CreateBookVewModel()
        {
            this.BookCategories = new List<SelectListItem>();
        }
    }

}