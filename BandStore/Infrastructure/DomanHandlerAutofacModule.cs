using AbstraktApp.Domain.Abstract;
using AbstraktApp.Domain.Concrete;
using AbstraktApp.Domain.Entities;
using Autofac;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandStore.Infrastructure
{
    /// Adding AutoFac(3/3)
    public class DomanHandlerAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Dodatkowo dodajemy obiekt moq - będzie imitacją repozytorium
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product{ Name = "Limbosis CD", Price = 35M },
                new Product { Name = "Limbosis Flac", Price = 20M },
                new Product { Name = "Koszulka czarna z logo", Price = 20M }

            }.AsQueryable());


            // Add Bindings here:            
            builder.RegisterType<EFProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();

            //builder.RegisterInstance(mock.Object).As<IProductRepository>(); // <= odwołujemy się do imitacji repozytorium Moq

            base.Load(builder);
        }      
    }
}