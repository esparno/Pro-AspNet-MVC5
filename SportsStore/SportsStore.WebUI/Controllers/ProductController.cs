using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4; 

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            var model = new ProductsListViewModel()
            {
                Products = repository.Products
                            .Where(p => category == null || String.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase) )
                            .OrderBy(p => p.ProductID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    TotalItems = repository.Products.Count(),
                    CurrentPage = page,
                    ItemsPerPage = PageSize
                },
                CurrentCategory = category
            };
            return View(model);
            
        }

    }
}