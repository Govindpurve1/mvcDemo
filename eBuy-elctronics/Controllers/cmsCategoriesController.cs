using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class cmsCategoriesController : Controller
    {
        #region DB EF Ref
        Entities DB = new Entities();
        #endregion

        #region Categories list
        /// <summary>
        /// Get all categories list
        /// </summary>        
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<Category> _Category = DB.Categories.Where(x=>x.IsDeleted==false).OrderBy(x => x.CreatedDate).ToList();
                    ViewBag.CategoryCount = _Category.Count();
                    return View(_Category);
                }
                else
                {
                    ViewBag.ErrorEx = "Session is expired.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorEx = ex.Message;
                return View("Error");
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// Create categories 
        /// </summary>        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category obj, HttpPostedFileBase file)
        {
            try
            {
                if (Session["user"] != null)
                {
                    // set file path string is empty
                    string Filepath = string.Empty;
                    if (file != null)
                    {
                        // append file name to obj image url
                        obj.CategoryImgUrl = file.FileName;
                        //get server path and set path to save location
                        Filepath = Path.Combine(Server.MapPath("~/Images/CategoryLogos"), obj.CategoryImgUrl);
                        //save file
                        file.SaveAs(Filepath);
                    }
                    obj.CreatedBy = "Adamin";
                    obj.CreatedDate = DateTime.Now;
                    obj.IsActive = false;
                    obj.IsDeleted = false;
                    DB.Categories.Add(obj);
                    DB.SaveChanges();
                    ViewBag.sucMsg = "Category created success.";
                    return View();
                }
                else
                {
                    ViewBag.ErrorEx = "Session is expired.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorEx = ex.Message;
                return View("Error");
            }
        }
        #endregion

        #region Edit
        public ActionResult Edit(int Id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Category _Category = DB.Categories.Where(x => x.CategoryID == Id).FirstOrDefault();
                    return View(_Category);
                }
                else
                {
                    ViewBag.ErrorEx = "Session is expired.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorEx = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(Category obj, HttpPostedFileBase file)
        {
            try
            {
                if (Session["user"] != null)
                {
                    // set file path string is empty
                    string Filepath = string.Empty;
                    var Categry = DB.Categories.Find(obj.CategoryID);
                    if (file != null)
                    {
                        // append file name to obj image url
                        obj.CategoryImgUrl = file.FileName;
                        //get server path and set path to save location
                        Filepath = Path.Combine(Server.MapPath("~/Images/CategoryLogos"), obj.CategoryImgUrl);
                        //save file
                        file.SaveAs(Filepath);
                        Categry.CategoryImgUrl = obj.CategoryImgUrl;
                    }

                    if (Categry != null)
                    {
                        Categry.CategoryName = obj.CategoryName;
                        Categry.CategoryDesc = obj.CategoryDesc;
                        Categry.UpdatedBy = "Admin";
                        Categry.UpdatedDate = DateTime.Now;
                        DB.SaveChanges();
                    }
                    Category _Category = DB.Categories.Where(x => x.CategoryID == obj.CategoryID).FirstOrDefault();
                    ViewBag.sucMsg = "Category updated success.";
                    return View(_Category);
                }
                else
                {
                    ViewBag.ErrorEx = "Session is expired.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorEx = ex.Message;
                return View("Error");
            }
        }
        #endregion

        #region Delete
        public ActionResult Delete(int Id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    var brands = DB.Categories.Find(Id);
                    if (brands != null)
                    {
                        brands.IsDeleted = true;
                        DB.SaveChanges();
                    }
                    ViewBag.sucMsg = "Category deleted success.";
                    return View("Index");
                }
                else
                {
                    ViewBag.ErrorEx = "Session is expired.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorEx = ex.Message;
                return View("Error");
            }
        }
        #endregion

    }
}
