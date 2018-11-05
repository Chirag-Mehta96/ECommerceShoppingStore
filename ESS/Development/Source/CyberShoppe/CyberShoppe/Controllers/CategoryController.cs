/// <summary>
/// AUTHOR-DIPALI MALI
/// DATE-29/10/2018
/// PUPROSE- CONTROLLER FOR CATEGORIES
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

    public class CategoryController : Controller
    {
        private Entities db = new Entities();
        Category cat = new Category();

        // GET: Product
        public ActionResult Index()
        {
           return View();
        }

        // GET: Category
        /// <summary>
        /// SHOWS ALL THE CATEGORIES IN THE DATABASE
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAll()
        {
            Entities ent = new Entities();
            return View(db.Categories.ToList());
        }

        public ActionResult DetailsCategory(string id)
        {
            return View(db.Categories.FirstOrDefault());
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        /// <summary>
        /// ADD CATEGORIES TO THE DATABASE
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult AddCategory(Category cat)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Categories.Add(cat);
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
                return RedirectToAction("ShowDetails");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("UNIQUE KEY constrain"))
                    ViewData["errorMsg"] = new List<string>() { "Category Name already exists.", " " };
                else
                    ViewData["errorMsg"] = new List<string>() { ex.Message, " " };
                return View();
            }
        }

        /// <summary>
        /// METHOD TO GET DETAILS OF CATEGORIES TO BE EDITED IN THE TABLE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult EditCategory(string id)
        {
            
            var result = (from edit in db.Categories
                          where edit.Category_Id == id
                          select edit).SingleOrDefault();

            return View(result);
        }

        /// <summary>
        /// POST METHOD TO EDIT CATEGORIES IN THE TABLE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult EditCategory(string id, FormCollection collection)
        {
             cat = db.Categories.Single(u => u.Category_Id == id);
            try
            {
                if (ModelState == null)
                {
                    ViewData["errorMsg"] = new List<string>() { "Model is null", " " };
                }
                if (ModelState.IsValid)
                {
                    //cat.Category_Id = collection["Category_Id"];
                    cat.Category_Name = collection["Category_Name"];
                    cat.C_Description = collection["C_Description"];
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
                return RedirectToAction("ShowDetails", cat);
            }

            catch (DbEntityValidationException ex)
            {
                var query = from entityValidationErrors in ex.EntityValidationErrors
                            from validationError in entityValidationErrors.ValidationErrors
                            select validationError.ErrorMessage;
                ViewData["errorMsg"] = query.ToList();
                return View(cat);
            }

        }

        /// <summary>
        /// GETTING DETAILS OF THE CATEGORIES TO BE DELETED
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult DeleteCategory(string id)
        {
            cat = db.Categories.Single(u => u.Category_Id == id);
            return View(cat);
        }

        /// <summary>
        /// DELETING CATEGORIES
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult DeleteCategory(string id, FormCollection collection)
        {
            try
            {
                cat = db.Categories.Single(u => u.Category_Id == id);
                db.Categories.Remove(cat);
                db.SaveChanges();
                return RedirectToAction("ShowDetails");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// SHOWING  DETAILS OF ALL THE CATEGORIES TO BE DELETED
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult ShowDetails()
        {
            return View(db.Categories.ToList());
        }
    }
}