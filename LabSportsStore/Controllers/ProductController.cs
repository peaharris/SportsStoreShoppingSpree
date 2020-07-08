using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSportsStore.Models;
using LabSportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabSportsStore.Controllers
{
    public class ProductController : Controller
    {
        //   F i e l d s   &   P r o p e r t i e s
        public int PageSize = 4;
        private IProductRepository repository; //interface

        //   C o n s t r u c t o r s

        public ProductController(IProductRepository repository) //implements the interface passes FakeProductRepository
        {
            this.repository = repository;
        }

        //   M e t h o d s - C r u d

        // C r e a t e
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            Product p = repository.Create(product);
            return RedirectToAction("Index");

        }

        // R e a d
        public IActionResult Index(string category, int productPage = 1)
        {
            ProductListViewModel someProducts = new ProductListViewModel();
            someProducts.PagingInfo = new PagingInfo //this is a data transfer object
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.GetAllProducts().Count() //gives the total number of items via count

            };

            if (category == null)
            {
                someProducts.PagingInfo.TotalItems =
                    repository.GetAllProducts().Count();

                someProducts.Products = //this is call Link (Language Integrated Query)
                    repository.GetAllProducts()
                              .OrderBy(p => p.ProductId)
                              .Skip((productPage - 1) * PageSize) //skiping these products 
                              .Take(PageSize); //showing next products
            }
            else
            {
                someProducts.PagingInfo.TotalItems =
                    repository.GetAllProducts()
                              .Where(p => p.Category == category)
                              .Count();

                someProducts.Products = //this is call Link (Language Integrated Query)
                    repository.GetProductsByCategory(category)
                              .Skip((productPage - 1) * PageSize)
                              .Take(PageSize);
                    //repository.GetAllProducts()
                    //          .Where(p => p.Category == category)
                    //          .OrderBy(p => p.ProductId)
                    //          .Skip((productPage - 1) * PageSize) //skiping these products 
                    //          .Take(PageSize); //showing next products
            }

            someProducts.CurrentCategory = category;
           return View(someProducts);
        }

        public IActionResult Detail(int id)
        {
            Product p = repository.GetProductById(id);
            if (p != null)
            {
                return View(p); //returns detail view in details.cshtml
            }
            return RedirectToAction("Index"); //going back to index view if searchable p is null
        }

        public IActionResult Search(string id)
        {
            IQueryable<Product> products =
               repository.GetProductsByKeyword(id);
            return View(products);
        }

        // U p d a t e
        [HttpGet] //reading from the database
        public IActionResult Update(int id)
        {
            Product p = repository.GetProductById(id);
            if (p != null)
            {
                return View(p); //sends that product into the view
            }
            return RedirectToAction("Index");
        }

        [HttpPost] //post = adding and creating in db ; put/patch = updating an existing record
        public IActionResult Update(Product p)//, int id)
        {
            //p.ProductId = id;
            Product p2 = repository.UpdateProduct(p); //making p2 the new p
            return RedirectToAction("Index");
        }

        // D e l e t e
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            repository.DeleteProduct(product.ProductId);
            return RedirectToAction("Index");
        }
    }
}
