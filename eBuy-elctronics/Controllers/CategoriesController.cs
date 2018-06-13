using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class CategoriesController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Categories
        /// <summary>
        /// Get Selected Categories's list
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<Category> _Category = DB.Categories.ToList();
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

        #region Categories items
        /// <summary>
        /// Get selected all Categories items
        /// </summary>

        [HttpGet]
        public ActionResult CategoriesItems(int Id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<cGet_Items> _Get_Items = DB.sp_Get_Items().Where(x => x.CategoryID == Id).ToList();
                    ViewBag.count = _Get_Items.Count();
                    return View(_Get_Items);
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
