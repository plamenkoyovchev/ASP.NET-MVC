using Movies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string Title { get; set; }
        [Required]
        public DateTime Year { get; set; }
      
        public virtual Actor LeadingMaleRole { get; set; }
      
        public virtual Actor LeadingFemaleRole { get; set; }

        [Required]
        [AllowHtml]
        public string Director { get; set; }

        [Required]
        [AllowHtml]
        public string StudioAddress { get; set; }

        [Required]
        [AllowHtml]
        public string Studio { get; set; }
    }
}