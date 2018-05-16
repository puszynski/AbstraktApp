using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstraktApp.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Proszę podać imie i nazwisko.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać adres.")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage ="Proszę podać miasto.")]
        public string City { get; set; }

        [Required(ErrorMessage ="Proszę podać województwo.")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage ="Proszę podać nazwę kraju.")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
