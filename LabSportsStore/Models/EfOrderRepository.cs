using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSportsStore.Models
{
    public class EfOrderRepository : IOrderRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext context;
        public IQueryable<Order> Orders
        {
            get { return context.Orders; }
        }

        //   C o n s t r u c t o r s

        public EfOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        //   M e t h o d s


        public Order GetOrderById(int orderId)
        {
            return context.Orders
                          .Include(o => o.Items)
                          .ThenInclude(i => i.Product)
                          .FirstOrDefault
                             (o => o.OrderId == orderId);
        }

        public void SaveOrder(Order order)
        {
            // Don't add new Products to the Database.
            if (order.OrderId == 0)
            {
                context.AttachRange(order.Items.Select(i => i.Product));
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
