using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using e_commerce.EF;
using System.Web.Mvc;
using e_commerce.Repository;
using System.Web.Script.Serialization;
using e_commerce.DTOs;


namespace e_commerce.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;



        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        // GET: Product
        
        public ActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public ActionResult AddToCart(int id)
        {
            var p = _productRepository.Get(id);
            var pm = new ProductDto
            {

                Name = p.Name, // Added Name property to ProductDto
                Id = p.Id,
                Qty = 1, // Default quantity for cart
                Price = p.Price,
                

            };
            List<ProductDto> products;
            if (Session["cart"] == null)
            {
                products = new List<ProductDto>();
            }
            else
            {
                var json = Session["cart"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<ProductDto>>(json);
            }
            p.Qty = 1;
            products.Add(pm);
            var json2 = new JavaScriptSerializer().Serialize(products);
            Session["cart"] = json2; // Fixed missing semicolon
            return RedirectToAction("Index");
        }
        public ActionResult Cart()
        {

            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);

            return View(products);
        }

        public ActionResult Checkout()
        {
            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
            OrderRepository.PlaceOrder(products, User.Identity.Name);
            return RedirectToAction("Index");
        }

        public ActionResult IncreaseQty(int id)
        {
            var json = Session["cart"]?.ToString();
            if (json != null)
            {
                var cart = new JavaScriptSerializer().Deserialize<List<ProductDto>>(json);
                var product = cart.FirstOrDefault(x => x.Id == id);
                if (product != null)
                {
                    product.Qty += 1;
                }
                Session["cart"] = new JavaScriptSerializer().Serialize(cart);
            }
            return RedirectToAction("Cart");
        }

        public ActionResult DecreaseQty(int id)
        {
            var json = Session["cart"]?.ToString();
            if (json != null)
            {
                var cart = new JavaScriptSerializer().Deserialize<List<ProductDto>>(json);
                var product = cart.FirstOrDefault(x => x.Id == id);
                if (product != null && product.Qty > 1) // prevent zero or negative
                {
                    product.Qty -= 1;
                }
                Session["cart"] = new JavaScriptSerializer().Serialize(cart);
            }
            return RedirectToAction("Cart");
        }

        public ActionResult RemoveFromCart(int id)
        {
            if (Session["cart"] == null)
                return RedirectToAction("Cart");

            var json = Session["cart"].ToString();
            var cart = new JavaScriptSerializer().Deserialize<List<ProductDto>>(json) ?? new List<ProductDto>();

            var productToRemove = cart.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                cart.Remove(productToRemove);
            }

            Session["cart"] = new JavaScriptSerializer().Serialize(cart);

            return RedirectToAction("Cart");
        }


    }
}