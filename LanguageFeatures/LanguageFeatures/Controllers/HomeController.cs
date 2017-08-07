using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            Product p = new Product();
            p.Name = "Kayak";
            return View("Result",(object)p.Name);
        }
        public ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.Products = new List<Product>
            {
                new Product() {Name="raw hide bone", Price=5},
                new Product() { Name="Tug Toy", Price=8},
                new Product() { Name="Goughnut", Price=16}
            };
            var total = cart.TotalPrices();
            return View("Result", (object)String.Format("Total: {0:c}", total));
        }
    }
}