using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSportsStore.Models
{
    public interface IOrderRepository
    {
        // P r o p e r t i e s
        public IQueryable<Order> Orders { get; }//most interfaces do not have properties, we must implement this property
        // F i e l d s 
        public Order GetOrderById(int orderId);
        public void SaveOrder(Order order);

    }
}
