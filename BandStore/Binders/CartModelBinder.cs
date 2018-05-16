using AbstraktApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstraktApp.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // pobranie obiektu Cart z sesji
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];

            // utworzenie obiektu Cart, jeśeli nie został znaleziony w danych sesji
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            // zwróć koszyk
            return cart;
        }
    }
}