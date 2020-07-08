using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSportsStore.Models
{
    public class CartItem // POCO
    {
        public int CartItemID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal
        { 
            get { return Quantity * Product.Price; }
        }
    }
}
