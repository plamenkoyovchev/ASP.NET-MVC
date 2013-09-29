using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //[DisplayFormat(DataFormatString="{0:yyyy}",ApplyFormatInEditMode=true)]
        public DateTime Year { get; set; }

        public virtual Actor LeadingMaleRole { get; set; }

        public virtual Actor LeadingFemaleRole { get; set; }

        public string Director { get; set; }

        public string StudioAddress { get; set; }

        public string Studio { get; set; }
    }
}