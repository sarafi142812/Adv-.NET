using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using e_commerce.EF;

namespace e_commerce.Repository
{
    public class ProductRepository
    {
        static Entities1 db;
        static ProductRepository()
        {
            db = new Entities1();
        }

        public Product Get(int id)
        {
            var p = db.Products.FirstOrDefault(e => e.Id == id);
            return p;
        }


        public List<Product> GetAll()
        {
            var products = db.Products.ToList();
            return products;
        }
    }
}