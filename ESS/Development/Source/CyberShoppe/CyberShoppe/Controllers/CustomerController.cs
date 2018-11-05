
/// <summary>
/// AUTHOR-DHANA RAAJ 
/// DATE-29/10/2018
/// PUPROSE- CONTROLLER FOR CART
/// </summary>


namespace CyberShoppe.Controllers
{
    using CyberShoppe.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CustomerController : Controller
    {
        Entities db = new Entities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer
        [HttpGet]
        public ActionResult RegisterCustomer(int id = 0)
        {
            Customer customer = new Customer();
            return View(customer);
        }

       [HttpPost]
        public ActionResult RegisterCustomer(Customer cust)
        {
            try
            {
                using (Entities entities = new Entities())
                {
                    entities.Customers.Add(cust);
                    entities.SaveChanges();
                }
                ModelState.Clear();

                return View("Insert", new Customer());
            }
            catch (DbEntityValidationException ex)
            {
                var query = from entityValidationErrors in ex.EntityValidationErrors
                            from validationError in entityValidationErrors.ValidationErrors
                            select validationError.ErrorMessage;
                ViewData["errorMsg"] = query.ToList();
                return View();
            }
            catch (Exception ex)
            {

                if (ex.InnerException.InnerException.Message.Contains("UNIQUE KEY constrain"))
                    ViewData["errorMsg"] = new List<string>() { "Enter valid value" };
                else
                    ViewData["errorMsg"] = new List<string>() { ex.Message, " " };
                return View(cust);

            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer cust)
        {
            using (Entities dc = new Entities())
            {
                var custDetails = dc.Customers.Where(a => a.Email.Equals(cust.Email) && a.Password.Equals(cust.Password)).FirstOrDefault();
                if (custDetails == null)
                {
                    ViewBag.LoginError = "Email and password doesn't match. Please provide correct Email and Password.";
                    //return View("Index", cust);
                }
                else if (custDetails != null)
                {
                    return RedirectToAction("ShowAllProducts","Cart");
                }
                else
                {
                    ViewBag.Message = "Login Unsuccessful";
                }
            }
            return View();
        }

        //public ActionResult ShowAllProducts()
        //{
        //    return View();
        //}
    }

}