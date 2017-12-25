using ApplicationDashboardMVC.DataAccess;
using ApplicationDashboardMVC.DataAccess.Entitites;
using ApplicationDashboardMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationDashboardMVC.Controllers
{
    public class ProductsController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<ProductsViewModel> productList = new List<ProductsViewModel>();

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductList(int id)
        {
            Session["CustomerId"] = id;

            return View();
        }

        [HttpGet]
        public ActionResult GetProductByCategory(string category)
        {
            using (DashboardContext _context = new DashboardContext())
            {
                List<ProductsViewModel> productList = _context.ProductSet
                    .Where(p => p.ProductType.ToLower().Equals(category.ToLower()))
                    .Select(p => new ProductsViewModel
                        {
                            ProductID = p.ID,
                            ProductName = p.ProductName,
                            UnitPriceProduct = p.UnitPrice,
                            UnitsInStock = p.UnitsInStock,
                            ProductImage = p.ProductImage,
                            ProductType = p.ProductType

                        }).ToList();

                 return PartialView("~/Views/Products/GetProductByCategory.cshtml", productList);
                
            }
  
        }

        [HttpPost]
        public ActionResult ShoppingCart(ProductsViewModel product)
        {
            string message = string.Empty;

            if(product != null)
            {
                productList.Add(product);
                message = "product has been added successfully !";
            }
            else
            {
                message = "something Wrong  !";
            }
            
            return Json( new { message  = message}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayShoppingCart()
        {
            List<ProductsViewModel> myShoppingCart = productList;

            return PartialView("~/Views/Products/DisplayShoppingCart.cshtml", myShoppingCart);
        }

       
        [HttpPost]
        public ActionResult AddOrder(int[] arrIdProduct, int[] arrQteProduct)
        {
            int countProduct = arrIdProduct.Length;
            int customerId = (int)Session["CustomerId"];
            bool statusTran = false;

            DashboardContext _context = new DashboardContext();

            using (DbContextTransaction dbTran = _context.Database.BeginTransaction())
            {
                try
                {
                    Customer customer = _context.CustomerSet.Find(customerId);
                    if (customer != null)
                    {
                        customer.Orders.Add(new Order { OrderDate = DateTime.Now });
                    }

                    Order orderSelected = customer.Orders.LastOrDefault();

                    if (orderSelected != null)
                    {
                        for (int i = 0; i < countProduct; i++)
                        {
                            Product selectedProduct = _context.ProductSet.Find(arrIdProduct[i]);
                            orderSelected.OrderDetail.Add(new OrderDetails { Product = selectedProduct, Quatity = arrQteProduct[i] });
                        }
                    }

                    //Save Changes
                    int countResult = _context.SaveChanges();

                    //Commit Transaction
                    dbTran.Commit();

                    if(countProduct > 0)
                    {
                        statusTran = true;
                        productList.Clear();
                    }
                    

                }
                catch (Exception)
                {
                    dbTran.Rollback();
                }
            }


            return Json(new { data = statusTran }, JsonRequestBehavior.AllowGet);
        }

 
    }
}