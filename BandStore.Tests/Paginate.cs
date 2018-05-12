using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AbstraktApp.Domain.Abstract;
using AbstraktApp.Domain.Entities;
using AbstraktApp.WebUI.Controllers;
using BandStore.Controllers;
using BandStore.HtmlHelpers;
using BandStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BandStore.Tests
{
    [TestClass]
    public class Paginate
    {
        /// <summary>
        /// w celu przetesowania stronnicowania:
        /// - tworzymy imitacje repozytorium
        /// - wstrzykujemy ją do ctor kotrolera NewProductController
        /// </summary>
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ ProductID = 1, Name = "P1" },
                new Product{ ProductID = 2, Name = "P2" },
                new Product{ ProductID = 3, Name = "P3" },
                new Product{ ProductID = 4, Name = "P4" },
                new Product{ ProductID = 5, Name = "P5" },
            }.AsQueryable());

            NewProductController controller = new NewProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;

            // Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        /// <summary>
        /// Sprawdza poprawność ręcznie dodanej metody pomocniczej Html obsługującej ViewModel: PagingHelpers
        /// </summary>
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange
            // definiowanie metody pomocnicznej - potrzebne aby użyć metody rozszeżajacej:
            HtmlHelper myHelper = null;

            // Act - data
            PagingInfoViewModel paginginfo = new PagingInfoViewModel
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Act - delegate
            Func<int, string> pageUrlDelegate = i => "Strona" + i;
            // Act
            MvcHtmlString result = myHelper.PageLinks(paginginfo, pageUrlDelegate);

            // Assert
            Assert.AreEqual(result.ToString(), @"<a href=""Strona1"">1</a>"
+ @"<a class=""selected""href=""Strona2"">2</a>"
+ @"<a class=""Strona3"">3</a>");
        }
    }
}
