using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AbstraktApp.WebUI.Models
{
    public class Review : Base
    {
        [Range(0,10)]
        public int Rating { get; set; }
        public string Comment { get; set; }


        public string Author { get; set; }
        public int ProductId { get; set; }
    }
}