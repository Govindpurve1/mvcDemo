using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class CartController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion

        #region Cart list
        /// <summary>
        /// Get all stored cart list
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    Logindetail LogInfo = Session["user"] as Logindetail;
                    IList<cGet_AllCart> _AllCart = DB.sp_Get_AllCart(LogInfo.Loginid).ToList();
                    ViewBag.Count = _AllCart.Count();
                    return View(_AllCart);
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
