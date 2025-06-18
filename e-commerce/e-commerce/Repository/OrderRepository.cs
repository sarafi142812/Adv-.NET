using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using e_commerce.EF;

namespace e_commerce.Repository
{
    public class OrderRepository
    {
        static Entities1 db;
        static OrderRepository()
        {
            db = new Entities1();
        }

        public static void PlaceOrder(List<Product> products, string uId)
        {
            Order o = new Order();
            o.Ammount = products.Sum(p => p.Price * p.Qty);
            o.CustomerId = uId;
            o.Status = "Ordered";
            db.Orders.Add(o);
            db.SaveChanges();

            foreach (var p in products)
            {
                var od = new Orderdetail
                {
                    OrderId = o.Id,
                    ProductId = p.Id,
                    Unitprice = p.Price,
                    Qty = p.Qty,
                };
                db.Orderdetails.Add(od);
            }
            db.SaveChanges();
        }
    }
}
