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

        public ViewResult List(int page =1)
        {
            var products = repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
            var model = new ProductsListViewModel()
            {
                Products = products,
                PagingInfo = new PagingInfo()
                {
                    TotalItems = products.Count(),
                    CurrentPage = page,
                    ItemsPerPage = PageSize
                }
            };
            return View(model);
            
        }

    }
}