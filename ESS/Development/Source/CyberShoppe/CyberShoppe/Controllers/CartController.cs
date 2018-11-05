
/// <summary>
/// AUTHOR-CHIRAG MEHTA
/// DATE-29/10/2018
/// PUPROSE- CONTROLLER FOR CART
/// </summary>

namespace CyberShoppe.Controllers
{
    using CyberShoppe.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CartController : Controller
    {
        Entities db = new Entities();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// FETCHING THE DATA RELATED TO THE SELECTED PRODUCT
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PRODUCT DETAILS</returns>

        public ActionResult ProductDescription(string id)
        {
            Entities entities = new Entities();
            var details = from Product in entities.Products
                          where Product.Product_Id == id
                          select Product;
            return View(details);

        }

        /// <summary>
        /// FETCHING THE DATA RELATED TO THE  PRODUCT
        /// </summary>
        /// <returns>PRODUCT DETAILS</returns>

        public ActionResult ShowAllProducts()
        {
            return View(from Product in db.Products
                        select Product);
        }
    }
}