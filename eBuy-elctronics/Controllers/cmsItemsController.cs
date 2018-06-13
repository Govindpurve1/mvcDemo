using eBuy_elctronics.Models;
using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class cmsItemsController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Items
        /// <summary>
        /// Get all items list
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<cGet_Items> _Items = DB.sp_Get_Items().ToList();
                    ViewBag.ItemsCount = _Items.Count();
                    return View(_Items);
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
        /// Create the items 
        /// </summary>
        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                LoadDDL();
                return View();
            }
            else
            {
                ViewBag.ErrorEx = "Session is expired.";
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult Create(Items Obj, HttpPostedFileBase file)
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
                        Obj.ItemImageURL = file.FileName;
                        //get server path and set path to save location
                        Filepath = Path.Combine(Server.MapPath("~/Images/Items/"), Obj.ItemImageURL);
                        //save file
                        file.SaveAs(Filepath);
                    }
                    //save items in db
                    DB.sp_SaveItems(Obj.BrandId, Obj.CategoryId, Obj.ItemName, Obj.ItemDesc, Obj.ItemImageURL, Obj.ItemPrice, Obj.ItemQuantity, 1, 0);
                    LoadDDL();
                    ViewBag.sucMsg = "Item created success.";
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
        /// <summary>
        /// Edit the selected item 
        /// </summary>
        public ActionResult Edit(int Id)
        {
            if (Session["user"] != null)
            {
                cGet_Items _Items = DB.sp_Get_Items().Where(x => x.ItemID == Id).FirstOrDefault();
                LoadDDL();
                return View(_Items);
            }
            else
            {
                ViewBag.ErrorEx = "Session is expired.";
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(cGet_Items Obj, HttpPostedFileBase file)
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
                        Obj.ImageURL = file.FileName;
                        //get server path and set path to save location
                        Filepath = Path.Combine(Server.MapPath("~/Images/Items/"), Obj.ImageURL);
                        //save file
                        file.SaveAs(Filepath);
                    }
                    else
                    {
                        Obj.ImageURL = DB.Items.Where(x => x.ItemID == Obj.ItemID && x.IsDeleted == false && x.IsActive == true).Select(x => x.ImageURL).FirstOrDefault();
                    }
                    //save items in db
                    DB.sp_SaveItems(Obj.BrandID, Obj.CategoryID, Obj.ItemName, Obj.ItemDesc, Obj.ImageURL, Obj.Price, Obj.Quantity, 1, Obj.ItemID);
                    LoadDDL();
                    ViewBag.sucMsg = "Item created success.";
                    cGet_Items _Items = DB.sp_Get_Items().Where(x => x.ItemID == Obj.ItemID).FirstOrDefault();
                    return View(_Items);
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

        #region DDL
        /// <summary>
        /// Load the brands and category to bind the data to drop down list
        /// </summary>
        public void LoadDDL()
        {
            var Category = DB.Categories.ToList();
            ViewBag.CategoryId = new SelectList(Category, "CategoryID", "CategoryName");


            var brands = DB.Brands.ToList();
            ViewBag.BrandId = new SelectList(brands, "BrandID", "BrandName");
        }
        #endregion
    }
}
