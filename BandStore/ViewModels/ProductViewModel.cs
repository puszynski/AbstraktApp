using AbstraktApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstraktApp.WebUI.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [MaxLength(60), MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}