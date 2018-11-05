
/// <summary>
/// AUTHOR-DHANA RAAJ 
/// DATE-30/10/2018
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

    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        ///  LOGIN CODE FOR ADMIN
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Login(Admin u)
        {
            using (Entities dc = new Entities())
            {
                var v = dc.Admins.Where(a => a.username.Equals(u.username) && a.password.Equals(u.password)).FirstOrDefault();
                if (v != null)
                {
                    return RedirectToAction("ShowDetails","Product");
                }
                else
                {
                    ViewBag.Message = "Login Unsuccessful";
                }
            }
            return View();
        }

    }
}