using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LabSportsStore.Models;
using LabSportsStore.Infrastructure;
using LabSportsStore.Models.ViewModels;
using Newtonsoft.Json;

namespace LabSportsStore.Controllers
{
    public class CartController : Controller
    {

        //   F i e l d s   &   P r o p e r t i e s
        private ICartRepository repository;
        private IProductRepository productRepository;

        //   C o n s t r u c t o r s
        public CartController(ICartRepository repository, IProductRepository productRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
        }

        //   M e t h o d s
        //   C r e a t e 
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = productRepository.GetProductById(productId);
            if (product != null)
            {
                Cart cart = repository.GetCart();
                cart.AddItem(product, 1);
                repository.SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        //   R e a d 
        public IActionResult Index(string returnUrl)
        {
            CartIndexViewModel model = new CartIndexViewModel();
            model.Cart = repository.GetCart();
            model.ReturnUrl = returnUrl;
            return View(model);
        }
        // D e l e t e
        [HttpPost]
        public IActionResult Remove(int productId, string returnUrl)
        {
            repository.Remove(productId);
            return RedirectToAction("Index", "Cart", new { returnUrl });
        }

        //private Cart GetCart()
        //{
        //    string cartJsonString = HttpContext.Session.GetString("_CartJson");
        //    if (cartJsonString != null)
        //    {
        //        Cart myCart = JsonConvert.DeserializeObject<Cart>(cartJsonString);
        //        return myCart;
        //    }
        //    return new Cart();
        //}

        //   U p d a t e
        //private void SaveCart(Cart cart)
        //{
        //    string cartJsonString = JsonConvert.SerializeObject(cart);
        //    HttpContext.Session.SetString("_CartJson", cartJsonString);
        //    //HttpContext.Session.SetInt32("UserId", 35);
        //    //HttpContext.Session.SetInt32("UserId", -1);
        //    //HttpContext.Session.Clear();
        //}
    }
}
