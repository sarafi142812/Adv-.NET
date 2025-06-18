using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; } // for cart quantity
    }

}