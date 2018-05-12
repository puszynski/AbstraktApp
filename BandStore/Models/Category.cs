using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbstraktApp.WebUI.Models
{
    public class Category : Base
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}