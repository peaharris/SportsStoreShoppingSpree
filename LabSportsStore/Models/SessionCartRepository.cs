using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSportsStore.Models
{
    public class SessionCartRepository : ICartRepository
    {
        // F i e l d s
        private IHttpContextAccessor httpContextAccessor;
        // C o n s t r u c t o r
        public SessionCartRepository(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            string cartJsonString = httpContextAccessor.HttpContext.Session.GetString("_CartJson");
            if (cartJsonString != null)
            {
                Cart myCart = JsonConvert.DeserializeObject<Cart>(cartJsonString);
                return myCart;
            }
            return new Cart();
        }

        public void SaveCart(Cart cart)
        {
            string cartJsonString = JsonConvert.SerializeObject(cart);
            httpContextAccessor.HttpContext.Session.SetString("_CartJson", cartJsonString);
        }
        public void Remove(int productId)
        {
            Cart cart = GetCart();
            cart.RemoveItem(productId);
            SaveCart(cart);
        }
        public void Remove(Product product)
        {
            Remove(product.ProductId);
        }
    }
}
