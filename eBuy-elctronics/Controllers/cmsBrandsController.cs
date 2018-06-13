using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eBuy_elctronics.Controllers
{
    public class cmsBrandsController : Controller
    {
        #region DB EF Ref
        Entities DB = new Entities();
        #endregion

        #region Brands list
        /// <summary>
        /// Get all brands list
        /// </summary>        
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<Brand> _Brands = DB.Brands.OrderByDescending(x => x.CreatedDate).ToList();
                    ViewBag.BrandsCount = _Brands.Count();

                    return View(_Brands);
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

        #region Create brand
        /// <summary>
        /// Create the brand 
        /// </summary>
        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                ViewBag.ErrorEx = "Session is expired.";
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Create(Brand obj, HttpPostedFileBase file)
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
                        obj.BrandImgUrl = file.FileName;
                        //get server path and set path to save location
                        Filepath = Path.Combine(Server.MapPath("~/Images/BrandLogos"), obj.BrandImgUrl);
                        //save file
                        file.SaveAs(Filepath);
                    }
                    obj.CreatedBy = "Admin";
                    obj.CreatedDate = DateTime.Now;
                    obj.IsActive = false;
                    obj.IsDeleted = false;
                    DB.Brands.Add(obj);
                    DB.SaveChanges();
                    ViewBag.sucMsg = "New brand added success.";
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

        #region Edit brand
        /// <summary>
        /// Edit the selected brands
        /// </summary>
        public ActionResult Edit(int Id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Brand _Brands = DB.Brands.Where(x => x.BrandID == Id).FirstOrDefault();
                    return View(_Brands);
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
        public ActionResult Edit(Brand obj, HttpPostedFileBase file)
        {
            try
            {
                if (Session["user"] != null)
                {
                    // set file path string is empty
                    string Filepath = string.Empty;
                    var brands = DB.Brands.Find(obj.BrandID);
                    if (file != null)
                    {
                        // append file name to obj image url
                        obj.BrandImgUrl = file.FileName;
                        //get server path and set path to save location
                        Filepath = Path.Combine(Server.MapPath("~/Images/BrandLogos"), obj.BrandImgUrl);
                        //save file
                        file.SaveAs(Filepath);
                        brands.BrandImgUrl = obj.BrandImgUrl;
                    }

                    if (brands != null)
                    {
                        brands.BrandName = obj.BrandName;
                        brands.BrandDesc = obj.BrandDesc;
                        brands.UpdatedBy = "Admin";
                        brands.UpdatedDate = DateTime.Now;
                        DB.SaveChanges();
                    }
                    ViewBag.sucMsg = "Brand updated success.";
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

        #region Delete brand
        /// <summary>
        /// Delete the selected record from brand
        /// </summary>
        public ActionResult Delete(int Id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    var brands = DB.Brands.Find(Id);
                    if (brands != null)
                    {
                        brands.IsDeleted = true;
                        DB.SaveChanges();
                    }
                    ViewBag.sucMsg = "Brand deleted success.";
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
