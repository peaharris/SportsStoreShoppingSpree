using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSportsStore.Models
{
    public interface ICartRepository
    {
        public Cart GetCart();
        public void SaveCart(Cart cart);
        public void Remove(int productId);
        public void Remove(Product product);
    }
}
