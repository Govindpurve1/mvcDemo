using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class cmsOrdersController : Controller
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
                    IList<cGet_AllOrders> _AllOrders = DB.sp_Get_AllOrders(0).ToList();
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

    }
}
