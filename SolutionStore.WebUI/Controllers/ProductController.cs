using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolutionStore.Domain.Abstract;
using SolutionStore.WebUI.Models;

namespace SolutionStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myrepository;

        public ProductController(IProductRepository productRepository)
        {
            this.myrepository = productRepository;
        }

        public int PageSize = 5;
        public ViewResult List(string category, string system, int page = 1 )
        {
            if (ViewBag.SelectedCategory != null)
            {
                category = ViewBag.SelectedCategory;
            }
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = myrepository.Products.Where(p => category == null && system == null || (system == null && p.Category == category) || p.System == system && category == null || p.Category == category && p.System == system).OrderBy(p => p.Name).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    // TotalItems = myrepository.Products.Count()
                    //TotalItems = category == null ? myrepository.Products.Count() : myrepository.Products.Where(e => system == null ? e.Category == category : e.Category == category && e.System == system).Count(),
                    TotalItems = category == null ? (system == null ? myrepository.Products.Count() : myrepository.Products.Where(e => e.System == system).Count()) : (system == null ? myrepository.Products.Where(e => e.Category == category).Count() : myrepository.Products.Where(x => x.Category == category && x.System == system).Count()) ,
                },
                CurrentCategory = category,
                CurrentSystem = system
            };
            return View(model);
        }
    }
}