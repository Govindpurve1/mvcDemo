using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class OrderController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Orders list
        /// <summary>
        /// Get all orders to check ordered list
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    Logindetail LogInfo = Session["user"] as Logindetail;
                    IList<cGet_AllOrders> _AllOrders = DB.sp_Get_AllOrders(LogInfo.Loginid).ToList();
                    return View(_AllOrders);
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

        #region Add Orders
        /// <summary>
        /// Add Orders to place the ordered product
        /// </summary>
        public ActionResult AddOrder(int Id)
        {
            try
            {
                if (Session["user"] != null)
                {
                   // Logindetail LogInfo = Session["user"] as Logindetail;
                   // DB.sp_Save_Orders(Id, 5, LogInfo.Loginid);
                    ViewBag.sucMsg = "Added new order success.";
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

        #region Add Cart
        /// <summary>
        /// Add Cart to store selected product
        /// </summary>
        public ActionResult AddCart(int Id)
        {
            try
            {
                if (Session["user"] != null)
                {
                    Logindetail LogInfo = Session["user"] as Logindetail;

                    DB.sp_SaveCart(Id, 0, 0, LogInfo.Loginid);

                    ViewBag.sucMsg = "Added new cart success.";
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

    }
}
