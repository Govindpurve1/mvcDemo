using eBuy_elctronics_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eBuy_elctronics.Controllers
{
    public class cmsFeedBackController : Controller
    {
        #region EF Ref
        Entities DB = new Entities();
        #endregion
       

        #region Check with all feedbacks
        /// <summary>
        /// Get all customers feedback 
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                if (Session["user"] != null)
                {
                    Logindetail user = Session["user"] as Logindetail;
                    IList<cGet_AllFeedback> Feedback = DB.sp_Get_AllFeedback(user.Loginid).ToList();
                    return View(Feedback);
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
