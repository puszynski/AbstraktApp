using AbstraktApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstraktApp.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
