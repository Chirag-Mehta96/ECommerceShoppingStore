
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
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ProductController : Controller
    {
        Entities db = new Entities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddDetails()
        {
           return View();
        }

        /// <summary>
        /// ADD PRODUCTS TO THE DATABASE
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>


        [HttpPost]
        public ActionResult AddDetails(Product product, HttpPostedFileBase image)
        {
            try {
                if (ModelState.IsValid)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(image.InputStream))
                    {
                        bytes = br.ReadBytes(image.ContentLength);
                    }
                    Product data = new Product() { Product_Id = product.Product_Id, Category_Id = product.Category_Id, Model_Number = product.Model_Number, Model_Name = product.Model_Name, Unit_Cost = product.Unit_Cost, P_Description = product.P_Description, P_Image = bytes };
                    db.Products.Add(data);
                    db.SaveChanges();
                }
                
            }catch(Exception exception)
            {
                ViewBag.Message(exception.Message);
            }
            return View();
        }

        /// <summary>
        /// SHOW PRODUCT DETAILS FROM  THE DATABASE
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>

        public ActionResult ShowDetails()
        {
           return View(db.Products.ToList());
        }
        [HttpGet]


        /// <summary>
        /// METHOD TO GET DETAILS OF CATEGORIES TO BE EDITED IN THE TABLE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult EditProduct(string id)
        {
            Product prod = new Product();
            var result = (from u in db.Products
                          where u.Product_Id == id
                          select u).SingleOrDefault();

            return View(result);
        }

        /// <summary>
        /// POST METHOD TO EDIT PRODUCTS IN THE TABLE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult EditProduct(string id, FormCollection collection)
        {
            Product prod = db.Products.Single(u => u.Product_Id == id);
            try
            {
                if (ModelState == null)
                {
                    ViewData["errorMsg"] = new List<string>() { "Model is null", " " };
                }
                if (ModelState.IsValid)
                {
                   
                    //prod.Category_Id = collection["Category_Id"];
                    prod.Model_Number = collection["Model_Number"];
                    prod.Model_Name = collection["Model_Name"];
                    prod.Unit_Cost = Convert.ToInt32(collection["Unit_Cost"]);
                    prod.P_Description = collection["P_Description"];
                    db.SaveChanges();
                }
                else
                {
                    var query = from state in ModelState.Values
                                from error in state.Errors
                                select error.ErrorMessage;
                    ViewData["errorMsg"] = query.ToList();
                    return View();
                }
                return RedirectToAction("ShowDetails", prod);
            }

            catch (DbEntityValidationException ex)
            {
                var query = from entityValidationErrors in ex.EntityValidationErrors
                            from validationError in entityValidationErrors.ValidationErrors
                            select validationError.ErrorMessage;
                ViewData["errorMsg"] = query.ToList();
                return View(prod);
            }

        }
       
        /// <summary>
        /// GETTING DETAILS OF THE PRODUCTS TO BE DELETED
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult DeleteProduct(string id)
        {
            Product prod = db.Products.Single(u => u.Product_Id == id);
            return View(prod);
        }

        /// <summary>
        /// DELETING PRODUCTS
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult DeleteProduct(string id, FormCollection collection)
        {
            try
            {
                Product prod = db.Products.Single(u => u.Product_Id == id);
                db.Products.Remove(prod);
                db.SaveChanges();
                return RedirectToAction("ShowDetails");
            }
            catch
            {
                return View();
            }
        }

       
    }
}