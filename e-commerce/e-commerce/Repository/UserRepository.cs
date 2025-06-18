using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using e_commerce.EF;

namespace e_commerce.Repository
{
    public class UserRepository
    {
        static Entities1 db;
        static UserRepository()
        {
            db = new Entities1();
        }

        public static Customer Get(string cId)
        {
            var c = (from cus in db.Customers
                     where cus.Id == cId
                     select cus).FirstOrDefault();
            return c;
        }

        public static Customer Authenticate(string phone, string name)
        {

            var cus = db.Customers.FirstOrDefault(e => e.Id == phone && e.Name == name);
            return cus;
        }
    }
}