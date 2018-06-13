using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class SearchController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Search list
        /// <summary>
        /// Get all search items
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    IList<cGet_Items> _getallitem = GetItems();
                    return View(_getallitem);
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

        #region Add Cart
        /// <summary>
        /// Add Cart to store selected product
        /// </summary>
        public ActionResult AddCart(int Id, int price)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Logindetail LogInfo = Session["user"] as Logindetail;

                    DB.sp_SaveCart(Id, 0, price, LogInfo.Loginid);
                    ViewBag.sucMsg = "Item added in cart success.";
                    IList<cGet_Items> _getallitem = GetItems();
                    return View("Index", _getallitem);
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

        #region Get all items
        public IList<cGet_Items> GetItems()
        {

            IList<cGet_Items> _getallitem = DB.sp_Get_Items().ToList();
            ViewBag.Count = _getallitem.Count();
            return _getallitem;

        }
        #endregion
    }
}
