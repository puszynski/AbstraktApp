using AbstraktApp.Domain.Entities;

namespace AbstraktApp.WebUI.Models
{
    public class CartIndexViewModel 
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}