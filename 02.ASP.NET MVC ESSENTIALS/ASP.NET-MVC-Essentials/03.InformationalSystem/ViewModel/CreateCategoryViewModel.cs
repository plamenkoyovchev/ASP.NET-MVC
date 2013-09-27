using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03.InformationalSystem.ViewModel
{
    public class CreateCategoryViewModel
    {
        [Required]
        [StringLength(50,MinimumLength=3)]
        public string CategoryName { get; set; }
    }
}