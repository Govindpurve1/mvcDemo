using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class FeedBackController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Feedback
        /// <summary>
        /// Add FeedBack to products
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    Logindetail user = Session["user"] as Logindetail;
                    LoadDDL();
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
                return View("Index");
            }
        }
        #endregion

        #region Create Feedback
        /// <summary>
        /// Create FeedBack 
        /// </summary>
        public ActionResult Create(FeedbackDesc obj)
        {
            try
            {

                if (Session["user"] != null)
                {
                    Logindetail user = Session["user"] as Logindetail;
                    obj.LoginID = user.Loginid;
                    obj.CreatedBy = user.Loginid.ToString();
                    obj.CreatedDate = DateTime.Now;
                    obj.IsDeleted = false;
                    obj.IsActive = true;
                    DB.FeedbackDescs.Add(obj);
                    DB.SaveChanges();
                    LoadDDL();
                    ViewBag.sucMsg = "Feedback sends success.";
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
                return View("Index");
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

            var item = DB.Items.ToList();
            ViewBag.ItemId = new SelectList(item, "ItemID", "ItemName");
        }
        #endregion
    }
}
